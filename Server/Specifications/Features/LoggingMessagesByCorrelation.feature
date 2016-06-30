Feature: LoggingMessagesByCorrelation

Background:
	Given I have setup the server with a limit of the last 2 routes saved

Scenario: One command route with correlation id
	Given I have logged command processing for the message 'root' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01' with correlation id '{2A0997AC-BFB0-42C8-8FF7-32F637D4DB9A}'
	And I have logged message processed with correlation id '{2A0997AC-BFB0-42C8-8FF7-32F637D4DB9A}' from machine 'TestMachine1' on thread 1 
    And I wait for the message to be populated on the route in the view
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

Scenario: One event route with correlation id
	Given I have logged event processing for the message 'root' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01' with correlation id '{2A0997AC-BFB0-42C8-8FF7-32F637D4DB9A}'
	And I have logged message processed with correlation id '{2A0997AC-BFB0-42C8-8FF7-32F637D4DB9A}' from machine 'TestMachine2' on thread 1 
    And I wait for the message to be populated on the route in the view
    When I get all routes
    Then there should only be one route
	And that route should have a valid id
	And only one message in the route 
	And the root message in the route should be the same as that message
	And that route should be dated '1975-09-21 00:00:01'
    And that route should be from machine 'TestMachine'
	And that message should have a valid id
	And that message should have the name 'root'
	And that message should have the type 'Event'
	And that message should have a close branch count of 1


	
    
	
    