using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Client
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(config =>
            {
                // We check the cookie to confirm we are authenticated
                config.DefaultAuthenticateScheme = "ClientCookie";
                // When we sign in we deal out a cookie
                config.DefaultSignInScheme = "ClientCookie";

                //Use this to check if we are allowed to do something
                //so redirect to authorize endpoint
                //so we have to go thru OurServer to recieve Client Cookie
                config.DefaultChallengeScheme = "OurServer";
            })
                .AddCookie("ClientCookie")
                .AddOAuth("OurServer",options =>
                {
                    options.CallbackPath = "/oauth/callback";
                    options.ClientId = "client_id";
                    options.ClientSecret = "client_secret";
                    options.AuthorizationEndpoint = "http://localhost:59353/oauth/authorize";
                    options.TokenEndpoint = "http://localhost:59353/oauth/token";

                    options.SaveTokens = true;

                    //To use the access token claims in Client application also
                    //Usually we use access token to authorize with api.
                    options.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents()
                    {
                        OnCreatingTicket = context =>
                        {
                            var accessToken = context.AccessToken;
                            var base64payload = accessToken.Split('.')[1];

                            //Some .net core bug
                            string working = base64payload.Replace('-', '+').Replace('_', '/'); ;
                            while (working.Length % 4 != 0)
                            {
                                working += '=';
                            }
                            ////

                            var bytes = Convert.FromBase64String(working);
                            var jsonPayload = Encoding.UTF8.GetString(bytes);
                            var claims = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonPayload);

                            foreach (var claim in claims)
                            {
                                context.Identity.AddClaim(new System.Security.Claims.Claim(claim.Key, claim.Value));
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddControllersWithViews();

            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCookiePolicy(new CookiePolicyOptions()
            {
                MinimumSameSitePolicy = SameSiteMode.Lax
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
