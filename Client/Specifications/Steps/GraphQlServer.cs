namespace MessageRouteInpsector.Client.Specifications.Steps
{
    using System.Threading.Tasks;
    using SystemDot.MessageRouteInspector.Client;

    public class GraphQlServer : IGraphQlServer
    {
        public GraphQlMutation GraphQl { get; private set; }
        public GraphQlServerUri Url { get; private set; }

        public async Task SendAsync(GraphQlServerUri url, GraphQlMutation graphQl)
        {
            GraphQl = graphQl;
            Url = url;
            await Task.FromResult(false);
        }
    }
}