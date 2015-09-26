namespace SystemDot.MessageRouteInspector.Server.Specifications.Steps
{
    using System;
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

        [Given(@"I have logged message processing for the message '(.*)' from machine '(.*)' on thread (.*) dated '(.*)'")]
        public void GivenIHaveLoggedMessageProcessingForTheMessageFromMachineOnThreadDated(string name, string machine, int thread, DateTime dated)
        {
            client.LogMessageProcessingAsync(name, machine, thread, dated).Wait();
        }

        [Given(@"I have logged message processed from machine '(.*)' on thread (.*)")]
        public void GivenIHaveLoggedMessageProcessedFromMachineOnThread(string machine, int thread)
        {
            client.LogMessageProcessedAsync(machine, thread).Wait();
        }

        [When(@"I get all routes")]
        public void WhenIGetAllRoutes()
        {
            routes = client.GetRoutesAsync().Result;
        }

        [Then(@"there should not be any routes")]
        public void ThenThereShouldNotBeAnyRoutes()
        {
            routes.Should().BeEmpty();
        }

        [Then(@"the only route should have the name '(.*)' dated '(.*)'")]
        public void ThenTheOnlyRouteShouldHaveTheNameDated(string name, DateTime dated)
        {
            routes.Single().Root.Name.Should().Be(name);
            routes.Single().CreatedOn.Should().Be(dated);
        }
    }
}
