using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.AuthRequirement
{
    public class JwtRequirement: IAuthorizationRequirement
    {
        
    }

    public class JwtRequirementHandler : AuthorizationHandler<JwtRequirement>
    {
        private HttpClient _client;
        private HttpContext _httpContext;

        public JwtRequirementHandler(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _client = httpClientFactory.CreateClient();
            _httpContext = httpContextAccessor.HttpContext;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            JwtRequirement requirement)
        {
            if(_httpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var accessToken = authHeader.ToString().Split(' ')[1];

                var response = await _client.GetAsync($"http://localhost:59353/oauth/validate?access_token={accessToken}");

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}
