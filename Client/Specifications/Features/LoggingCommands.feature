Feature: LoggingCommands

Background:
	Given I use a graphQL server url 'http://test.com'

Scenario: logging the fact that a command is being processed 
	When I log command processing for a command named 'TestCommand' from machine 'TestMachine' on thread 1 on '09/21/2015 00:00:00'
	Then graphQL should be posted of 'mutation logCommandProcessing { logCommandProcessing(name: "TestCommand", machine: "TestMachine", thread: 1, createdOn: "635783904000000000") }'
	And it should be posted to 'http://test.com'

Scenario: logging the fact that a event is being processed 
	When I log event processing for a command named 'TestEvent' from machine 'TestMachine' on thread 1 on '09/21/2015 00:00:00'
	Then graphQL should be posted of 'mutation logEventProcessing { logEventProcessing(name: "TestEvent", machine: "TestMachine", thread: 1, createdOn: "635783904000000000") }'
	And it should be posted to 'http://test.com'

Scenario: logging the fact that a message has failed in processing
	When I log message processing failure for a command named 'TestFailure' from machine 'TestMachine' on thread 1 on '09/21/2015 00:00:00'
	Then graphQL should be posted of 'mutation logMessageProcessingFailure { logMessageProcessingFailure(name: "TestFailure", machine: "TestMachine", thread: 1, createdOn: "635783904000000000") }'
	And it should be posted to 'http://test.com'

Scenario: logging the fact that a message has been processed
	When I log message processed for a from machine 'TestMachine' on thread 1
	Then graphQL should be posted of 'mutation logMessageProcessed { logMessageProcessed(machine: "TestMachine", thread: 1) }'
	And it should be posted to 'http://test.com'
