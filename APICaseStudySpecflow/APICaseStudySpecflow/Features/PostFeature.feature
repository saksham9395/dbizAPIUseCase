Feature: PostFeature

	@mytag
Scenario Outline: Validate Post Api for create new user
    Given user creates a Post Request for new user API <apipath>
	When user hit the API
	Then The post API should return 201 OK
	Examples: 
	| apipath           |
	| api/users         |
	| api12/invalidpath |