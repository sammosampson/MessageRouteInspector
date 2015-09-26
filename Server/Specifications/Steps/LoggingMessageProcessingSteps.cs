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
        MessageLoggingClient client;
        Route[] routes;
        Route route;
        Message message;

        [Given(@"I have setup the server")]
        public void GivenIHaveSetupTheServer()
        {
            client = Bootstrapper.InitialiseAsync().Result;
        }

        [Given(
            @"I have logged message processing for the message '(.*)' from machine '(.*)' on thread (.*) dated '(.*)'")]
        public void GivenIHaveLoggedMessageProcessingForTheMessageFromMachineOnThreadDated(string name, string machine,
            int thread, DateTime dated)
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

        [Then(@"there should only be one route")]
        public void ThenThereShouldOnlyBeOneRoute()
        {
            routes.Count().Should().Be(1);
            route = routes.Single();
        }

        [Then(@"that route should be dated '(.*)'")]
        public void ThenThatRouteShouldBeDated(DateTime dated)
        {
            route.CreatedOn.Should().Be(dated);
        }

        [Then(@"only one message in the route")]
        public void ThenOnlyOneMessageInTheRoute()
        {
            route.Messages.Count().Should().Be(1);
            message = route.Messages.Single();
        }

        [Then(@"there should a message at index (.*) of the route's messages")]
        public void ThenThereShouldAMessageAtIndexOfTheRouteSMessages(int index)
        {
            route.Messages.ElementAt(index).Should().NotBeNull();
            message = route.Messages.ElementAt(index);
        }

        [Then(@"that message should have a close branch count of (.*)")]
        public void ThenThatMessageShouldHaveACloseBranchCountOf(int closedBranchCount)
        {
            message.CloseBranchCount.Should().Be(closedBranchCount);
        }

        [Then(@"the root message in the route should be the same as that message")]
        public void ThenTheRootMessageInTheRouteShouldBeTheSameAsThatMessage()
        {
            route.Root.Should().BeSameAs(message);
        }

        [Then(@"that message should have the name '(.*)'")]
        public void ThenThatMessageShouldHaveTheName(string name)
        {
            message.Name.Should().Be(name);
        }
    }
}
