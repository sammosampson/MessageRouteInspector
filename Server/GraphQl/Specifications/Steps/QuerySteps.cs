using TechTalk.SpecFlow;

namespace SystemDot.MessageRouteInspector.Server.GraphQl.Specifications.Steps
{
    using FluentAssertions;

    [Binding]
    public class QuerySteps
    {
        private GraphQlExecuter executer;
        private string output;

        [Given(@"I have initialised the graphql server")]
        public void GivenIHaveInitialisedTheGraphqlServer()
        {
            executer = Bootstrapper.Bootstrap(1);
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
