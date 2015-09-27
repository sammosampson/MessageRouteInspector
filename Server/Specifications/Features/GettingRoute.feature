Feature: GettingRoute
  As a message inspector
  I want to retreive a route by its identifier
  So that I can see it in the inspector

Background:
	Given I have setup the server

Scenario: Second of two routes retreived by id
	Given I have logged command processing for the message 'firstRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    And I have logged message processed from machine 'TestMachine' on thread 1
    And I have logged command processing for the message 'secondRouteFirstMessage' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:02'
    And I have logged message processed from machine 'TestMachine' on thread 1
    When I get all routes
	Then there should be a route at index 1 of all the routes
	When I get the route by its id
	Then it should match the other route
