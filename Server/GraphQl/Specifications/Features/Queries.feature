Feature: Queries

Scenario: Getting routes with no routes created
	Given I have initialised the graphql server
	When I send the following query 'query RouteQuery { App { routes{ machine } } }'
	Then I should be returned 
"""
{"data":{"app":{"routes":null}}}
"""
