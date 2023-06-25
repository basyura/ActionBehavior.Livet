using System;
using System.Net.Http;
using System.Threading.Tasks;
using Mastonet;

namespace Livedon.Actions
{
    public class Toot : ActionBase
    {
        public override async Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            if (string.IsNullOrWhiteSpace(ViewModel.Message))
            {
                return true;
            }


            var instance = "";
            var httpClient = new HttpClient();
            var authClient = new AuthenticationClient(instance, httpClient);
            var client = new MastodonClient(instance, "", httpClient);

            var ret = await client.PublishStatus(ViewModel.Message);



            return true;
        }
    }
}
