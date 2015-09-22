namespace SystemDot.MessageRouteInspector.Server.Specifications.Steps
{
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class LoggingMessageProcessingSteps
    {
        private object response;

        [Given(@"I have logged message proccessing for the message '(.*)'")]
        public void GivenIHaveLoggedMessageProccessingForTheMessage(string messageName)
        {
            var dispatcher = new CommandDispatcher();
            response = dispatcher.DispatchCommand(new
            {
                LogMessageProcessing = new
                {
                    MessageName = messageName
                }
            }).Result;            
        }

        [When(@"I get all routes")]
        public void WhenIGetAllRoutes()
        {
            var dispatcher = new RequestDispatcher();
            response = dispatcher.DispatchRequest(new { GetAllRoutes = new {} }).Result;
        }

        [Then(@"the only route should have the name '(.*)'")]
        public void ThenTheOnlyRouteShouldHaveTheName(string messageName)
        {
            response.As<GetRoutesResponse>().Routes.Single().Root.Name.Should().Be(messageName);
        }
    }
}
