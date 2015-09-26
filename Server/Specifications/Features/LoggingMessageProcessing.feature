Feature: LoggingMessageProcessing
  As a message logger
  I want to log the fact that a message is being processed
  So that I can see it in the inspector

Background:
	Given I have setup the server

Scenario: First message log processing 
    Given I have logged message processing for the message 'root' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    When I get all routes
    Then there should only be one route
	And there should not be any messages for the route
	
Scenario: First message log processing and processed
    Given I have logged message processing for the message 'root' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    Given I have logged message processed from machine 'TestMachine' on thread 1
    When I get all routes
    Then there should only be one route
	And only one message in the route 
	And the root message in the route should be the same as that message
	And that route should be dated '09/21/1975 00:00:01'
    And only one message in the route 
	And the root message in the route should be the same as that message
	And that message should have the name 'root'
	And that message should have a close branch count of 1

Scenario: First message log processing then second then two message log processed
	Given I have logged message processing for the message 'first' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    And I have logged message processing for the message 'second' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:02'
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

Scenario: First message log processing then log processed then second log processing then log processed
	Given I have logged message processing for the message 'firstRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    And I have logged message processed from machine 'TestMachine' on thread 1
    And I have logged message processing for the message 'secondRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:02'
    And I have logged message processed from machine 'TestMachine' on thread 1
    When I get all routes
	Then there should be a route at index 0 of all the routes
	And only one message in the route
	And that message should have the name 'firstRouteFirstMessage' 
	And that message should have a close branch count of 1
	And there should be a route at index 1 of all the routes
	And only one message in the route
	And that message should have the name 'secondRouteFirstMessage' 
	And that message should have a close branch count of 1