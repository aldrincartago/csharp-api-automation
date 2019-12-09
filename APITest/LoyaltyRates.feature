Feature: LoyaltyRates
	As a User
	I want to view all the rates per segment


	Scenario: View Loyalty Rates
		Given I view Loyalty Rates of flight from MNL to SIN
		Then I should be able to see 204 in the Get Loyalty Rates response

	Scenario: Get Mock Rates
		Given I get all valid Mock Rates 
		Then I should be able to see 200 in the Get Loyalty Rates response

	Scenario: Loyalty Rates Extension
		Given I get all Loyalty Rates Extension from MNL to SIN
		Then I should be able to see 204 in the Get Loyalty Rates Extension response