Feature: LoggingFailures
  As a message logger
  I want to log the fact that a failure has occurred whilst sending a message
  So that I can see it in the inspector

Background:
	Given I have setup the server
	
Scenario: One route from same machine and same thread message in message then failure
	Given I have logged command processing for the message 'first' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
	And I have logged a failure with the name 'massiveException' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:02'
    When I get all routes
	Then there should only be one route
	And there should a message at index 0 of the route's messages
	And that message should have the name 'first' 
	And that message should have a close branch count of 0
	And there should a message at index 1 of the route's messages
	And that message should have the name 'massiveException' 
	And that message should have the type 'Failure'
	And that message should have a close branch count of 2

Scenario: No route creatd from failure but no previuosly logged message
	And I have logged a failure with the name 'massiveException' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    When I get all routes
	Then there should not be any routes
