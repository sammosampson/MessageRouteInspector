Feature: LoggingMessages
  As a message logger
  I want to log the fact that a message has been sent
  So that I can see it in the inspector

Background:
	Given I have setup the server with a limit of the last 2 routes saved
	
Scenario: One route from same machine and same thread one command
    Given I have logged command processing for the message 'root' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    And I have logged message processed from machine 'TestMachine' on thread 1
    When I get all routes
    Then there should only be one route
	And that route should have a valid id
	And only one message in the route 
	And the root message in the route should be the same as that message
	And that route should be dated '1975-09-21 00:00:01'
    And that route should be from machine 'TestMachine'
	And that message should have a valid id
	And that message should have the name 'root'
	And that message should have the type 'Command'
	And that message should have a close branch count of 1

	Scenario: One route from same machine and same thread one event
    Given I have logged event processing for the message 'root' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    And I have logged message processed from machine 'TestMachine' on thread 1
    When I get all routes
    Then there should only be one route
	And only one message in the route 
	And that route should have a valid id
	And the root message in the route should be the same as that message
	And that route should be dated '1975-09-21 00:00:01'
	And that route should be from machine 'TestMachine' 
	And only one message in the route 
	And the root message in the route should be the same as that message
	And that message should have a valid id
	And that message should have the name 'root'
	And that message should have the type 'Event'
	And that message should have a close branch count of 1

Scenario: One route from same machine and same thread message in message
	Given I have logged command processing for the message 'first' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    And I have logged command processing for the message 'second' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:02'
    And I have logged message processed from machine 'TestMachine' on thread 1
    And I have logged message processed from machine 'TestMachine' on thread 1
    When I get all routes
	Then there should only be one route
	And there should a message at index 0 of the route's messages
	And that message should have the name 'first' 
	And that message should have a close branch count of 0
	And there should a message at index 1 of the route's messages
	And that message should have the name 'second' 
	And that message should have a close branch count of 2

Scenario: Two routes from same machine and same thread
	Given I have logged command processing for the message 'firstRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    And I have logged message processed from machine 'TestMachine' on thread 1
    And I have logged command processing for the message 'secondRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:02'
    And I have logged message processed from machine 'TestMachine' on thread 1
    When I get all routes
	Then there should be a route at index 0 of all the routes
	And only one message in the route
	And that message should have the name 'secondRouteFirstMessage' 
	And that message should have a close branch count of 1
	And there should be a route at index 1 of all the routes
	And only one message in the route
	And that message should have the name 'firstRouteFirstMessage' 
	And that message should have a close branch count of 1

Scenario: Two routes from same machine but different threads
	Given I have logged command processing for the message 'firstRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    And I have logged command processing for the message 'secondRouteFirstMessage' from machine 'TestMachine' on thread 2 dated '09/21/1975 00:00:02'
    And I have logged message processed from machine 'TestMachine' on thread 1
    And I have logged message processed from machine 'TestMachine' on thread 2
    When I get all routes
	Then there should be a route at index 0 of all the routes
	And only one message in the route
	And that message should have the name 'secondRouteFirstMessage' 
	And that message should have a close branch count of 1
	And there should be a route at index 1 of all the routes
	And only one message in the route
	And that message should have the name 'firstRouteFirstMessage' 
	And that message should have a close branch count of 1

Scenario: Two routes from different machines but same thread
	Given I have logged command processing for the message 'firstRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    And I have logged command processing for the message 'secondRouteFirstMessage' from machine 'TestMachine' on thread 2 dated '09/21/1975 00:00:02'
    And I have logged message processed from machine 'TestMachine' on thread 1
    And I have logged message processed from machine 'TestMachine' on thread 2
    When I get all routes
	Then there should be a route at index 0 of all the routes
	And only one message in the route
	And that message should have the name 'secondRouteFirstMessage' 
	And that message should have a close branch count of 1
	And there should be a route at index 1 of all the routes
	And only one message in the route
	And that message should have the name 'firstRouteFirstMessage' 
	And that message should have a close branch count of 1

Scenario: Three routes logged limited to two
	Given I have logged command processing for the message 'firstRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    And I have logged message processed from machine 'TestMachine' on thread 1
    And I have logged command processing for the message 'secondRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:02'
    And I have logged message processed from machine 'TestMachine' on thread 1
    And I have logged command processing for the message 'thirdRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:03'
    And I have logged message processed from machine 'TestMachine' on thread 1
    When I get all routes
	Then there should only be 2 routes

Scenario: No log processed yet so no route
    Given I have logged command processing for the message 'root' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    When I get all routes
    Then there should only be one route
	And there should not be any messages for the route

Scenario: log processed but no log processing so no route
    Given I have logged message processed from machine 'TestMachine' on thread 1
    When I get all routes
    Then there should not be any routes