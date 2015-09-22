Feature: LoggingMessageProcessing
  As a message logger
  I want to log the fact that a message is being processed
  So that I can see it in the inspector

Scenario: First log
    Given I have logged message proccessing for the message 'root'
    When I get all routes
    Then the only route should have the name 'root'