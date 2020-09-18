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

        //string[] scopes = new string[] { "Team.ReadBasic.All", "ChannelMessage.Send", "ChannelMessage.Read.All" };

        //for demo
        string[] scopes = new string[] { "Team.ReadBasic.All", "ChannelMessage.Send" };

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

            DeviceCodeProvider authProvider = new DeviceCodeProvider(app, scopes);
            return new GraphServiceClient(authProvider);
        }
    }
}
