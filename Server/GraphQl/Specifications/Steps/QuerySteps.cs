﻿using SystemDot.Akka.Testing;
using SystemDot.MessageRouteInspector.Server.Messages;
using SystemDot.MessageRouteInspector.Server.Queries;
using TechTalk.SpecFlow;

namespace SystemDot.MessageRouteInspector.Server.GraphQl.Specifications.Steps
{
    using FluentAssertions;

    [Binding]
    public class QuerySteps
    {
        private GraphQlExecuter executer;
        private string output;
        private readonly ViewChangeWatcherContext viewChangeWatcherContext;

        public QuerySteps(ViewChangeWatcherContext viewChangeWatcherContext)
        {
            this.viewChangeWatcherContext = viewChangeWatcherContext;
        }

        [Given(@"I have initialised the graphql server")]
        public void GivenIHaveInitialisedTheGraphqlServer()
        {
            executer = Bootstrapper.Bootstrap(1);
        }

        [Given(@"I wait for the route to be populated in the view")]
        public void GivenIWaitForTheRouteToBePopulatedInTheView()
        {
            viewChangeWatcherContext.WaitForChange<RoutesView, MessageRouteStarted>();
        }

        [Given(@"I wait for the message named '(.*)' to be populated on the route in the view")]
        public void GivenIWaitForTheMessageNamedToBePopulatedOnTheRouteInTheView(string expectedMessageName)
        {
            viewChangeWatcherContext.WaitForChange<RoutesView, MessageBranchCompleted>(e => e.MessageName == expectedMessageName);
        }

        [Given(@"I have sent the following query '(.*)'")]
        [When(@"I send the following query '(.*)'")]
        public void WhenISendTheFollowingQuery(string query)
        {
            output = executer.ExecuteQueryAsync(query).Result;
        }
        
        [Then(@"I should be returned")]
        public void ThenIShouldBeReturned(string expectedOutput)
        {
            output.Should().Be(expectedOutput);
        }
    }
}
