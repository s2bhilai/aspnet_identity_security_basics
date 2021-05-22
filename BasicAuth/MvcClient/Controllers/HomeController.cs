﻿using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvcClient.Controllers
{
    public class HomeController: Controller
    {
        private IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            var claims = User.Claims.ToList();
            var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);
            var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);

            var result = await GetSecret(accessToken);

            await RefreshAccessToken();

            return View();
        }

        public async Task<string> GetSecret(string accessToken)
        {
            var apiClient = _httpClientFactory.CreateClient();
            apiClient.SetBearerToken(accessToken);
            
            //http://localhost:52070/secret
            var response = await apiClient.GetAsync("https://localhost:44327/secret");

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        private async Task RefreshAccessToken()
        {
            var serverClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await serverClient
                .GetDiscoveryDocumentAsync("https://localhost:44369/");

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var refreshTokenClient = _httpClientFactory.CreateClient();

            var tokenResponse = await refreshTokenClient
                .RequestRefreshTokenAsync(new RefreshTokenRequest()
                {
                    Address = discoveryDocument.TokenEndpoint,
                    RefreshToken = refreshToken,
                    ClientId = "client_id_mvc",
                    ClientSecret = "client_secret_mvc"
                });

            var authInfo = await HttpContext.AuthenticateAsync("Cookie");

            authInfo.Properties.UpdateTokenValue("access_token", tokenResponse.AccessToken);
            authInfo.Properties.UpdateTokenValue("refresh_token", tokenResponse.RefreshToken);
            authInfo.Properties.UpdateTokenValue("id_token", tokenResponse.IdentityToken);

            await HttpContext.SignInAsync("Cookie",
                authInfo.Principal, authInfo.Properties);

            var accessTokenDifferent = !accessToken.Equals(tokenResponse.AccessToken);
            var idTokenDifferent = !idToken.Equals(tokenResponse.IdentityToken);
            var refreshTokenDifferent = !refreshToken.Equals(tokenResponse.RefreshToken);

        }
    }
}