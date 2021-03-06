﻿namespace SystemDot.MessageRouteInspector.Server.Specifications.Steps
{
    using System;
    using System.Linq;
    using SystemDot.MessageRouteInspector.Server.Messages;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class LoggingMessageProcessingSteps
    {
        MessageLogger client;
        Route[] routes;
        Route route;
        Route routeRetreivedById;
        Message message;

        [Given(@"I have setup the server with a limit of the last (.*) routes saved")]
        public void GivenIHaveSetupTheServer(int limit)
        {
            client = Bootstrapper.LimitRoutesTo(limit);
        }

        [Given(@"I have logged command processing for the message '(.*)' from machine '(.*)' on thread (.*) dated '(.*)'")]
        public void GivenIHaveLoggedCommandProcessingForTheMessageFromMachineOnThreadDated(string name, string machine, int thread, DateTime createdOn)
        {
            client.LogCommandProcessingAsync(name, machine, thread, createdOn).Wait();
        }

        [Given(@"I have logged event processing for the message '(.*)' from machine '(.*)' on thread (.*) dated '(.*)'")]
        public void GivenIHaveLoggedEventProcessingForTheMessageFromMachineOnThreadDated(string name, string machine, int thread, DateTime dated)
        {
            client.LogEventProcessingAsync(name, machine, thread, dated).Wait();
        }

        [Given(@"I have logged a failure with the name '(.*)' from machine '(.*)' on thread (.*) dated '(.*)'")]
        public void GivenIHaveLoggedAFailureWithTheNameFromMachineOnThreadDated(string name, string machine, int thread, DateTime dated)
        {
            client.LogMessageProcessingFailureAsync(name, machine, thread, dated).Wait();
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

        [When(@"I get the route by its id")]
        public void WhenIGetTheRouteByItsId()
        {
            routeRetreivedById = client.GetRouteAsync(route.Id).Result;
        }

        [Then(@"there should not be any messages for the route")]
        public void ThenThereShouldNotBeAnyMessagesForTheRoute()
        {
            route.Messages.Should().BeEmpty();
        }

        [Then(@"there should only be one route")]
        public void ThenThereShouldOnlyBeOneRoute()
        {
            routes.Count().Should().Be(1);
            route = routes.Single();
        }

        [Then(@"that route should have a valid id")]
        public void ThenThatRouteShouldHaveAValidId()
        {
            route.Id.Should().NotBeEmpty();
        }

        [Then(@"there should not be any routes")]
        public void ThenThereShouldNotBeAnyRoutes()
        {
            routes.Should().BeEmpty();
        }

        [Then(@"there should only be (.*) routes")]
        public void ThenThereShouldOnlyBeRoutes(int expectedAmount)
        {
            routes.Count().Should().Be(expectedAmount);
        }

        [Then(@"there should be a route at index (.*) of all the routes")]
        public void ThenThereShouldBeARouteAtIndexOfAllTheRoutes(int index)
        {
            routes.ElementAt(index).Should().NotBeNull();
            route = routes.ElementAt(index);
        }

        [Then(@"that route should be dated '(.*)'")]
        public void ThenThatRouteShouldBeDated(string dated)
        {
            route.CreatedOn.Should().Be(dated);
        }

        [Then(@"that route should be from machine '(.*)'")]
        public void ThenThatRouteShouldBeFromMachine(string machineName)
        {
            route.MachineName.Should().Be(machineName);
        }
        
        [Then(@"it should match the other route")]
        public void ThenItShouldMatchTheOtherRoute()
        {
            routeRetreivedById.Should().BeSameAs(route);
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

        [Then(@"that message should have a valid id")]
        public void ThenThatMessageShouldHaveAValidId()
        {
            message.Id.Should().NotBeEmpty();
        }

        [Then(@"that message should have the name '(.*)'")]
        public void ThenThatMessageShouldHaveTheName(string name)
        {
            message.Name.Should().Be(name);
        }

        [Then(@"that message should have the type '(.*)'")]
        public void ThenThatMessageShouldHaveTheType(MessageType type)
        {
            message.Type.Should().Be(type);
        }

        [StepArgumentTransformation]
        MessageType FromStringToMessageType(string from)
        {
            switch (@from)
            {
                case "Command":
                    return MessageType.Command;
                case "Event":
                    return MessageType.Event;
            }
            return MessageType.Failure;
        }
    }
}
