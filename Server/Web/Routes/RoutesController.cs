namespace SystemDot.MessageRouteInspector.Server.Web.Routes
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using SystemDot.Domain.Queries;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class RoutesController : ApiController
    {

        private readonly IAsyncQueryHandler<GetRouteQuery, GetRouteQueryResponse> getRouteQueryHandler;

        public RoutesController(IAsyncQueryHandler<GetRouteQuery, GetRouteQueryResponse> getRouteQueryHandler)
        {
            this.getRouteQueryHandler = getRouteQueryHandler;
        }

        public async Task<IHttpActionResult> Get(string id)
        {
            GetRouteQueryResponse response = await getRouteQueryHandler.Handle(new GetRouteQuery { RouteId = id });
            return Ok(response.Route);
        }
    }
}