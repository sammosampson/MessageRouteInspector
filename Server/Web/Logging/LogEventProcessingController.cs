namespace SystemDot.MessageRouteInspector.Server.Web.Logging
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using SystemDot.Domain.Commands;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogEventProcessingController : ApiController
    {
        private readonly CommandBus commandBus;

        public LogEventProcessingController(CommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        public async Task<IHttpActionResult> Post([FromBody]LogEventProcessing toPost)
        {
            await commandBus.SendCommandAsync(toPost);
            return Ok();
        }
    }
}