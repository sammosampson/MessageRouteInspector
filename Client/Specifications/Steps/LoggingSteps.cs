namespace MessageRouteInpsector.Client.Specifications.Steps
{
    using System;
    using SystemDot.MessageRouteInspector.Client;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class LoggingSteps
    {
        private MessageLoggingClient client;
        private readonly GraphQlServer graphQlServer;

        public LoggingSteps()
        {
            graphQlServer = new GraphQlServer();
        }

        [Given(@"I use a graphQL server url '(.*)'")]
        public void GivenIUseAGraphQLServerUrl(string url)
        {
            client = new MessageLoggingClient(graphQlServer, GraphQlServerUri.Parse(url));
        }

        [When(@"I log command processing for a command named '(.*)' from machine '(.*)' on thread (.*) on '(.*)'")]
        public void WhenILogCommandProcessingForACommandNamedFromMachineOnThreadOn(string name, string machine, int thread, DateTime on)
        {
            client.LogCommandProcessingAsync(name, machine, thread, on).Wait();
        }

        [When(@"I log event processing for a command named '(.*)' from machine '(.*)' on thread (.*) on '(.*)'")]
        public void WhenILogEventProcessingForACommandNamedFromMachineOnThreadOn(string name, string machine, int thread, DateTime on)
        {
            client.LogEventProcessingAsync(name, machine, thread, on).Wait();
        }

        [When(@"I log message processing failure for a command named '(.*)' from machine '(.*)' on thread (.*) on '(.*)'")]
        public void WhenILogMessageProcessingFailureForACommandNamedFromMachineOnThreadOn(string name, string machine, int thread, DateTime on)
        {
            client.LogMessageProcessingFailureAsync(name, machine, thread, on).Wait();
        }

        [When(@"I log message processed for a from machine '(.*)' on thread (.*)")]
        public void WhenILogMessageProcessedForAFromMachineOnThread(string machine, int thread)
        {
            client.LogMessageProcessedAsync(machine, thread).Wait();
        }

        [Then(@"graphQL should be posted of '(.*)'")]
        public void ThenGraphQLShouldBePostedOf(string graphQl)
        {
            graphQlServer.GraphQl.Should().Be(graphQl);
        }

        [Then(@"it should be posted to '(.*)'")]
        public void ThenItShouldBePostedTo(string expectedUrl)
        {
            Uri url = graphQlServer.Url;
            url.Should().Be(new Uri(expectedUrl));
        }
    }
}
