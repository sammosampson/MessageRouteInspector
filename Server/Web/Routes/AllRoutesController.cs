namespace SystemDot.MessageRouteInspector.Server.Web.Routes
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using SystemDot.Domain.Queries;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class AllRoutesController : ApiController
    {
        private readonly IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse> getRoutesQueryHandler;

        public AllRoutesController(IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse> getRoutesQueryHandler)
        {
            this.getRoutesQueryHandler = getRoutesQueryHandler;
        }

        public async Task<IHttpActionResult> Get()
        {
            GetRoutesQueryResponse response = await getRoutesQueryHandler.Handle(new GetRoutesQuery());
            return Ok(response.Routes);
        }
    }
}