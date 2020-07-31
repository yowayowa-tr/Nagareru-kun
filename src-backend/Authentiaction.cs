using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;

namespace src_backend
{
    public class Authentiaction
    {
        private static string ClientId = "29ce940f-4c9f-4e54-a8f9-74b981a14475";
        string[] scopes = new string[] { "user.read" };
        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";

        public async Task<GraphServiceClient> GetClient()
        {
            var app = PublicClientApplicationBuilder.Create(ClientId)
                    .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
                    .Build();

            var accounts = await app.GetAccountsAsync();
            AuthenticationResult authResult;

            try
            {
                authResult = await app.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                    .ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            {
                authResult = await app.AcquireTokenInteractive(scopes)
                                .ExecuteAsync();
            }

            string a = await GetHttpContentWithToken(graphAPIEndpoint, authResult.AccessToken);

            DeviceCodeProvider authProvider = new DeviceCodeProvider(app, scopes);
            return new GraphServiceClient(authProvider);
        }

        private async Task<string> GetHttpContentWithToken(string url, string token)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;
            try
            {
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
