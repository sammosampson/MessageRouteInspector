Feature: LoggingFailures
  As a message logger
  I want to log the fact that a failure has occurred whilst sending a message
  So that I can see it in the inspector

Background:
	Given I have setup the server with a limit of the last 2 routes saved
	
Scenario: One route from same machine and same thread message in message then failure
	Given I have logged command processing for the message 'first' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
	And I have logged a failure with the name 'massiveException' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:02'
	And I wait for the message named 'massiveException' to be populated on the route in the view
    When I get all routes
	Then there should only be one route
	And there should a message at index 0 of the route's messages
	And that message should have the name 'first' 
	And that message should have a close branch count of 0
	And there should a message at index 1 of the route's messages
	And that message should have the name 'massiveException' 
	And that message should have the type 'Failure'
	And that message should have a close branch count of 2

Scenario: Two routes from same machine and same thread message in message then failure
	Given I have logged command processing for the message 'first' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
	And I have logged a failure with the name 'massiveException1' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:02'
    And I have logged command processing for the message 'first' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:03'
	And I have logged a failure with the name 'massiveException2' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:04'
    And I wait for the message named 'massiveException1' to be populated on the route in the view
    And I wait for the message named 'massiveException2' to be populated on the route in the view
    When I get all routes
	Then there should be a route at index 0 of all the routes
	And there should a message at index 0 of the route's messages
	And that message should have the name 'first' 
	And that message should have a close branch count of 0
	And there should a message at index 1 of the route's messages
	And that message should have the name 'massiveException2' 
	And that message should have the type 'Failure'
	And that message should have a close branch count of 2
	And there should be a route at index 1 of all the routes
	And there should a message at index 0 of the route's messages
	And that message should have the name 'first' 
	And that message should have a close branch count of 0
	And there should a message at index 1 of the route's messages
	And that message should have the name 'massiveException1' 
	And that message should have the type 'Failure'
	And that message should have a close branch count of 2

Scenario: No route created from failure but no previously logged message
	And I have logged a failure with the name 'massiveException' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    When I get all routes
	Then there should not be any routes
