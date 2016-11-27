namespace SystemDot.MessageRouteInspector.Server.Web.Specifications.Steps
{
    using SystemDot.Akka.Testing;
    using SystemDot.MessageRouteInspector.Server.Messages;
    using SystemDot.MessageRouteInspector.Server.Queries;
    using SystemDot.MessageRouteInspector.Server.Web;
    using FluentAssertions;
    using TechTalk.SpecFlow;

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

        [Given(@"I wait for the route mutation to complete")]
        public void GivenIWaitForTheRouteMutationToComplete()
        {
            viewChangeWatcherContext.WaitForChange<RoutesView, MessageRouteStarted>();
        }

        [Given(@"I wait for the message mutation for '(.*)' to complete")]
        public void GivenIWaitForTheMessageMutationForToComplete(string expectedMessageName)
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
