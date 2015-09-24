namespace SystemDot.MessageRouteInspector.Server.Specifications.Steps
{
    using System.Linq;
    using SystemDot.MessageRouteInspector.Server.Queries;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class LoggingMessageProcessingSteps
    {
        private Route[] routes;
        private MessageLoggingClient client;

        [Given(@"I have setup the server")]
        public void GivenIHaveSetupTheServer()
        {
            client = Bootstrapper.InitialiseAsync().Result;
        }

        [Given(@"I have logged message proccessing for the message '(.*)'")]
        public void GivenIHaveLoggedMessageProccessingForTheMessage(string messageName)
        {
            client.LogMessageProcessingAsync(messageName).Wait();
        }

        [When(@"I get all routes")]
        public void WhenIGetAllRoutes()
        {
            routes = client.GetRoutesAsync().Result;
        }

        [Then(@"the only route should have the name '(.*)'")]
        public void ThenTheOnlyRouteShouldHaveTheName(string messageName)
        {
            routes.Single().Root.Name.Should().Be(messageName);
        }
    }
}
