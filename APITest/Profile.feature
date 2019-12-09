Feature: Profile
	As a user I should be able to 
	Register, Retrieve, Update,
	Change Info, Add Card and Migrate.

	Scenario: Register a Profile
		Given I register using a valid Profile request body
		Then I should be able to see 200 in the Register response status

	Scenario: Retrieve a Profile
		Given I retrieve a valid profile
		Then I should be able to see 200 in the Retrieve response status

	Scenario: Update a Profile
		Given I update a profile
		Then I should be able to see 200 in the Update response status

	Scenario: Register a Profile using an existing email
		Given I register using an existing email address
		Then I should be able to see 400 in the Register response status

	Scenario: Register a Profile using an invalid Card ID number
		Given I register using an existing email address
		Then I should be able to see 400 in the Register response status
