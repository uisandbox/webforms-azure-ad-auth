using Microsoft.Identity.Client;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestADAuth.Utils;
using Microsoft.Graph;
using System.Net.Http.Headers;

namespace TestADAuth.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                // Get the user's claims
                ClaimsPrincipal claimsPrincipal = Context.User as ClaimsPrincipal;
                // Get the access token from the claims
                //var accessToken = claimsPrincipal.FindFirst("access_token")?.Value;
                // Get the user's email
                string email = claimsPrincipal.FindFirst(ClaimTypes.Name)?.Value;

                // Get the user's profile data
                string fullName = claimsPrincipal.FindFirst("name")?.Value;
                string firstName = claimsPrincipal.FindFirst(ClaimTypes.GivenName)?.Value;

                // Create a GraphServiceClient instance using the access token
                //var graphClient = new GraphServiceClient(
                //    new DelegateAuthenticationProvider(
                //        async (requestMessage) =>
                //        {
                //            requestMessage.Headers.Authorization =
                //                new AuthenticationHeaderValue("Bearer", accessToken);
                //        }));

                // Call the Graph API to get the user's profile information
                //var user = await graphClient.Me
                //    .Request()
                //    .GetAsync();

                // Set the control values
                //tbPhone.Text = phone;
                tbfullName.Text = fullName;
                tbfirstName.Text = firstName;
                tbEmail.Text = email;
            }
            else
            {
                Response.Redirect("~/Account/Login");
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            // Redirect to ~/Account/SignOut after signing out.
            string callbackUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Response.ApplyAppPathModifier("~/Account/SignOut");

            HttpContext.Current.GetOwinContext().Authentication.SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                CookieAuthenticationDefaults.AuthenticationType);
        }

        private async Task<string> GetAccessToken(string[] scopes)
        {
            // Get the app settings from the web.config file
            string authority = $"https://login.microsoftonline.com/{AuthConfig.TenantID}";

            // Create a ConfidentialClientApplication instance
            var app = ConfidentialClientApplicationBuilder.Create(AuthConfig.ClientId)
                .WithAuthority(authority)
                .WithClientSecret(AuthConfig.ClientSecret)
                .Build();



            // Get an access token for the Microsoft Graph API
            //var result = await app.AcquireTokenSilent(scopes, ).ExecuteAsync();
            return "";
        }

        private byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}