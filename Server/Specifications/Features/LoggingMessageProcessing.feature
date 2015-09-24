Feature: LoggingMessageProcessing
  As a message logger
  I want to log the fact that a message is being processed
  So that I can see it in the inspector

Background:
	Given I have setup the server

Scenario: First message log processing 
    Given I have logged message processing for the message 'root' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    When I get all routes
    Then there should not be any routes

Scenario: First message log processing and processed
    Given I have logged message processing for the message 'root' from machine 'TestMachine' on thread 1 dated '09/21/1975 00:00:01'
    Given I have logged message processed from machine 'TestMachine' on thread 1
    When I get all routes
    Then the only route should have the name 'root' dated '09/21/1975 00:00:01'