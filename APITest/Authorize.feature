Feature: Authorize API
	As a user, I should be able to
	Login using valid credentials
	Get existing users

	Scenario: Login using valid credentials
		Given I login using tester@yahoo.com , test123 as my credentials
		Then I should be able to see 200 in the Login response

	Scenario: Login using invalid credentials
		Given I login using invaliduser@invalid.com , invalidpassword123_=! as my credentials
		Then I should be able to see 401 in the Login response

	Scenario: Login using invalid password
		Given I login using tester@yahoo.com , invalidpassword123_=! as my credentials
		Then I should be able to see 401 in the Login response

	Scenario: Login using invalid username
		Given I login using invaliduser@invalid.com , test123! as my credentials
		Then I should be able to see 401 in the Login response

	Scenario: Login without a password
		Given I login using tester@yahoo.com ,  as my credentials
		Then I should be able to see 500 in the Login response

	Scenario: Login without a username
		Given I login using  , test123! as my credentials
		Then I should be able to see 400 in the Login response

	Scenario Outline: Get a valid user
		Given I find the user <username> in the Auth DB
		Then I should be able to see <username> in the Get User response

		Examples: 
		| username   |
		| 9220010023 |
		| 9275231521 |