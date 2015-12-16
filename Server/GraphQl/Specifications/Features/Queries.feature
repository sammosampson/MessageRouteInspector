Feature: Queries
Background: 
	Given I have initialised the graphql server
	
Scenario: Getting routes with no routes created
	When I send the following query 'query RouteQuery { App { routes{ } } }'
	Then I should be returned 
"""
{"data":{"app":{"routes":[]}}}
"""

Scenario: Getting routes with one route with a command processing but not processed
	Given I have sent the following query 'mutation logCommandProcessing { logCommandProcessing(name: "X", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }'
	When I send the following query 'query RouteQuery { App { routes{ createdOn, machine } } }'
	Then I should be returned 
"""
{"data":{"app":{"routes":[{"createdOn":"0001-01-01 00:00:00","machine":"CSAMPSON1700"}]}}}
"""

Scenario: Getting routes with one route with a command processing and processed
	Given I have sent the following query 'mutation logCommandProcessing { logCommandProcessing(name: "X", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }'
	And I have sent the following query 'mutation logMessageProcessed { logMessageProcessed(machine: "CSAMPSON1700", thread: 1) }'
	When I send the following query 'query RouteQuery { App { routes{ createdOn, machine, root{name, type, closeBranchCount}, messages{name} } } }'
	Then I should be returned 
"""
{"data":{"app":{"routes":[{"createdOn":"0001-01-01 00:00:00","machine":"CSAMPSON1700","root":{"name":"X","type":0,"closeBranchCount":1},"messages":[{"name":"X"}]}]}}}
"""

Scenario: Getting routes with one route with an event processing and processed
	Given I have sent the following query 'mutation logEventProcessing { logEventProcessing(name: "X", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }'
	And I have sent the following query 'mutation logMessageProcessed { logMessageProcessed(machine: "CSAMPSON1700", thread: 1) }'
	When I send the following query 'query RouteQuery { App { routes{ createdOn, machine, root{name, type, closeBranchCount}, messages{name} } } }'
	Then I should be returned 
"""
{"data":{"app":{"routes":[{"createdOn":"0001-01-01 00:00:00","machine":"CSAMPSON1700","root":{"name":"X","type":1,"closeBranchCount":1},"messages":[{"name":"X"}]}]}}}
"""

Scenario: Getting routes with a failure
	Given I have sent the following query 'mutation logCommandProcessing { logCommandProcessing(name: "X", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }'
	And I have sent the following query 'mutation logMessageProcessingFailure { logMessageProcessingFailure(name: "A failure", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }'
	When I send the following query 'query RouteQuery { App { routes{ createdOn, machine, root{name, type, closeBranchCount}, messages{name, type} } } }'
	Then I should be returned 
"""
{"data":{"app":{"routes":[{"createdOn":"0001-01-01 00:00:00","machine":"CSAMPSON1700","root":{"name":"X","type":0,"closeBranchCount":0},"messages":[{"name":"X","type":0},{"name":"A failure","type":2}]}]}}}
"""