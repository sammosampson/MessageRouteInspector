namespace SystemDot.MessageRouteInspector.Client
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class GraphQlServer : IGraphQlServer
    {
        readonly HttpClient client = new HttpClient();

        public async Task SendAsync(GraphQlServerUri url, string graphQl)
        {
            HttpContent body = new StringContent(graphQl);
            body.Headers.ContentType = MediaTypeHeaderValue.Parse("application/graphql");
            HttpResponseMessage response = await client.PostAsync(url, body);
            response.EnsureSuccessStatusCode();
        }
    }
}