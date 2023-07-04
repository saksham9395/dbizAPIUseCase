Feature: PutPatchFeature
    @mytag
Scenario Outline: Validate Put Api for updating existing user
    Given user creates a Put Request for updating existing user API <apipath>
	When user hit the API
	Then The API should return 200 OK
    Examples: 
	| apipath                 |
	| api/users/2             |
	| api12/users/invalidpath |


	@mytag
Scenario: Validate Patch Api for updating existing user
    Given user creates a Patch Request for updating existing user API <apipath>
	When user hit the API
	Then The API should return 200 OK
     Examples: 
	| apipath                 |
	| api/users/2             |
	| api12/users/invalidpath |