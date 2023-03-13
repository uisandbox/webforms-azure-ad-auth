using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using Microsoft.Graph;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using TestADAuth.Utils;

namespace TestADAuth
{
    public partial class Startup
    {
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];

        string authority = AuthConfig.AADInstance + AuthConfig.TenantID + "/v2.0";

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    //This is needed for PKCE and resposne type must be set to 'code'
                    //UsePkce = true,
                    ClientId = AuthConfig.ClientId,
                    ClientSecret = AuthConfig.ClientSecret,
                    Authority = authority,
                    PostLogoutRedirectUri = postLogoutRedirectUri,
                    RedirectUri = AuthConfig.RedirectUri,
                    ResponseType = "id_token",
                    Scope = "openid email profile User.Read",
                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        AuthenticationFailed = (context) =>
                        {
                            return System.Threading.Tasks.Task.FromResult(0);
                        },

                        SecurityTokenValidated = (context) =>
                        {
                            string name = context.AuthenticationTicket.Identity.FindFirst("preferred_username")?.Value;
  
                            if (name != null)
                            {
                                context.AuthenticationTicket.Identity.AddClaim(new Claim(ClaimTypes.Name, name, string.Empty));
                            }
                            var claims = context.AuthenticationTicket.Identity.Claims;
                            //List<string> type = new List<string>();
                            //foreach (var claim in claims)
                            //{
                            //    System.Diagnostics.Debug.WriteLine("{0} = {1}", claim.Type, claim.Value);
                            //    type.Add(claim.Type);
                            //}
                            return System.Threading.Tasks.Task.FromResult(0);
                        },

                
                    },
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false
                    }
                });

            // This makes any middleware defined above this line run before the Authorization rule is applied in web.config
            app.UseStageMarker(PipelineStage.Authenticate);
        }

        private static string EnsureTrailingSlash(string value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            if (!value.EndsWith("/", StringComparison.Ordinal))
            {
                return value + "/";
            }

            return value;
        }
    }
}
