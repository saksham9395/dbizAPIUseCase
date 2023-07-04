Feature: User Api Validation
	

@mytag
Scenario Outline: Validate Get Api for list of all users
	Given user creates a Get Request for list of all user API <apipath>
	When user hit the API
	Then The API should return 200 OK
	Then verify "Lindsay Ferguson" is a valid user
	Examples: 
	| apipath   |
	| api/users | 
	| api/invalidpath |

	@mytag
Scenario Outline: Validate Get Api for single user
	Given user creates a Get Request for single API for user <id>
	When user hit the API
	Then The API should return 200 OK
	Examples: 
	| id |
	| 2  |
	| -2 |


