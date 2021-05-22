using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiTwo.Controllers
{
    public class HomeController: Controller
    {
        private IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("/home")]
        public async Task<IActionResult> Index()
        {
            //Retrieve access token from IdSrv

            var serverClient = _httpClientFactory.CreateClient();
            
            var discoveryDocument = await serverClient
                .GetDiscoveryDocumentAsync("https://localhost:44369/");

            var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "client_id",
                    ClientSecret = "client_secret",
                    Scope= "ApiOne"
                });

            // Retrieve secret data from ApiOne

            var apiClient = _httpClientFactory.CreateClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);
            //http://localhost:52070/secret
            var response = await apiClient.GetAsync("https://localhost:44327/secret");

            var content = await response.Content.ReadAsStringAsync();

            return Ok(new
            {
                access_token = tokenResponse.AccessToken,
                message = content
            });
        }
    }
}
