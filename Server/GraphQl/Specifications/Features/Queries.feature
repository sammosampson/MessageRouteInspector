Feature: Queries
Background: 
	Given I have initialised the graphql server
	
Scenario: Getting routes with no routes created
	When I send the following query 'query RouteQuery { viewer { routes{ } } }'
	Then I should be returned 
"""
{"data":{"viewer":{"routes":[]}}}
"""

Scenario: Getting defaulte single "0" route
	When I send the following query '{"query":"query RouteQuery { viewer { route(id:0) { root { name } } } }","variables":{}}'
	Then I should be returned 
"""
{"data":{"viewer":{"route":{"root":{"name":"No route"}}}}}
"""

Scenario: Getting routes with one route with a command processing but not processed
	Given I have sent the following query '{"query":"mutation logCommandProcessing { logCommandProcessing(name: "X", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }","variables":{}}'
	And I wait for the route to be populated in the view
    When I send the following query '{"query":"query RouteQuery { viewer { routes{ createdOn, machine } } }","variables":{}}'
	Then I should be returned 
"""
{"data":{"viewer":{"routes":[{"createdOn":"0001-01-01 00:00:00","machine":"CSAMPSON1700"}]}}}
"""

Scenario: Getting routes with one route with a command processing and processed
	Given I have sent the following query '{"query":"mutation logCommandProcessing { logCommandProcessing(name: "X", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }","variables":{}}'
	And I have sent the following query '{"query":"mutation logMessageProcessed { logMessageProcessed(machine: "CSAMPSON1700", thread: 1) }","variables":{}}'
	And I wait for the message named 'X' to be populated on the route in the view
    When I send the following query '{"query":"query RouteQuery { viewer { routes{ createdOn, machine, root{name, type, closeBranchCount}, messages{name} } } }","variables":{}}'
	Then I should be returned 
"""
{"data":{"viewer":{"routes":[{"createdOn":"0001-01-01 00:00:00","machine":"CSAMPSON1700","root":{"name":"X","type":0,"closeBranchCount":1},"messages":[{"name":"X"}]}]}}}
"""

Scenario: Getting routes with one route with an event processing and processed
	Given I have sent the following query '{"query":"mutation logEventProcessing { logEventProcessing(name: "X", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }","variables":{}}'
	And I have sent the following query '{"query":"mutation logMessageProcessed { logMessageProcessed(machine: "CSAMPSON1700", thread: 1) }","variables":{}}'
	And I wait for the message named 'X' to be populated on the route in the view
    When I send the following query '{"query":"query RouteQuery { viewer { routes{ createdOn, machine, root{name, type, closeBranchCount}, messages{name} } } }","variables":{}}'
	Then I should be returned 
"""
{"data":{"viewer":{"routes":[{"createdOn":"0001-01-01 00:00:00","machine":"CSAMPSON1700","root":{"name":"X","type":1,"closeBranchCount":1},"messages":[{"name":"X"}]}]}}}
"""

Scenario: Getting routes with a failure
	Given I have sent the following query '{"query":"mutation logCommandProcessing { logCommandProcessing(name: "X", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }","variables":{}}'
	And I have sent the following query '{"query":"mutation logMessageProcessingFailure { logMessageProcessingFailure(name: "A failure", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }","variables":{}}'
	And I wait for the message named 'A failure' to be populated on the route in the view
    When I send the following query '{"query":"query RouteQuery { viewer { routes{ createdOn, machine, root{name, type, closeBranchCount}, messages{name, type} } } }","variables":{}}'
	Then I should be returned 
"""
{"data":{"viewer":{"routes":[{"createdOn":"0001-01-01 00:00:00","machine":"CSAMPSON1700","root":{"name":"X","type":0,"closeBranchCount":0},"messages":[{"name":"X","type":0},{"name":"A failure","type":2}]}]}}}
"""

Scenario: Getting routes using fragments
	Given I have sent the following query '{"query":"mutation logCommandProcessing { logCommandProcessing(name: "X", machine: "CSAMPSON1700", thread: 1, createdOn: "00000000000001") }","variables":{}}'
	And I have sent the following query '{"query":"mutation logMessageProcessed { logMessageProcessed(machine: "CSAMPSON1700", thread: 1) }","variables":{}}'
	And I wait for the message named 'X' to be populated on the route in the view
    When I send the following query '{"query":"query RouteQuery { viewer { ...first } } fragment first on App { routes { ...second } } fragment second on MessageRoute { createdOn }","variables":{}}'
	Then I should be returned 
"""
{"data":{"viewer":{"routes":[{"createdOn":"0001-01-01 00:00:00"}]}}}
"""
