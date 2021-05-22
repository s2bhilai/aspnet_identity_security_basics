using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController: Controller
    {
        private IHttpClientFactory _httpClientFactory;
        private HttpClient _client;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _client = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async  Task<IActionResult> Secret()
        {
            var serverResponse = await AccessTokenRefreshWrapper(
                () => SecuredGetRequest("http://localhost:59353/secret/index"));

            var apiResponse = await AccessTokenRefreshWrapper(
                () => SecuredGetRequest("http://localhost:56565/secret/index"));
        
            return View();
        }

        private async Task<HttpResponseMessage> SecuredGetRequest(string url)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            return await client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> AccessTokenRefreshWrapper(
            Func<Task<HttpResponseMessage>> initialRequest)
        {
            var respose = await initialRequest();

            if(respose.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await RefreshAccessToken();
                respose = await initialRequest();
            }

            return respose;
        }

        private async Task RefreshAccessToken()
        {
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var refreshTokenClient = _httpClientFactory.CreateClient();

            var requestData = new Dictionary<string, string>
            {
                ["grant_type"] = "refresh_token",
                ["refresh_token"] = refreshToken
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:59353/oauth/token")
            {
                Content = new FormUrlEncodedContent(requestData)
            };

            var basicCredentials = "username:password";
            var encodedCredentials = Encoding.UTF8.GetBytes(basicCredentials);
            var base64Credentials = Convert.ToBase64String(encodedCredentials);

            request.Headers.Add("Authorization", $"Basic {base64Credentials}");

            var response = await refreshTokenClient.SendAsync(request);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);

            var newAccessToken = responseData.GetValueOrDefault("access_token");
            var newRefreshToken = responseData.GetValueOrDefault("refresh_token");

            //Update the principal to use new access token and refresh token
            var authInfo = await HttpContext.AuthenticateAsync("ClientCookie");

            authInfo.Properties.UpdateTokenValue("access_token", newAccessToken);
            authInfo.Properties.UpdateTokenValue("refresh_token", newRefreshToken);

            await HttpContext.SignInAsync("ClientCookie",
                authInfo.Principal, authInfo.Properties);

        }
    }
}
