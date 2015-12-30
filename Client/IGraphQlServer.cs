namespace SystemDot.MessageRouteInspector.Client
{
    using System.Threading.Tasks;

    public interface IGraphQlServer
    {
        Task SendAsync(GraphQlServerUri url, GraphQlMutation graphQl);
    }
}