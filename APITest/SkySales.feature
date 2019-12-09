Feature: SkySales
		I should be able to get SkySales data
		Using the endpoints available


	Scenario: Get SkySales using PNR
		Given I use SEUCWJ as the PNR
		Then I should be able to see 200 in the Get SkySales response

	Scenario: Get Promo Code Usage
		Given I use promo100 as the promo code
		Then I should be able to see 200 in the Get SkySales response

	Scenario: Get SkySale Data
		Given I use SEUCWJ as the PNR of Get Skysale Data
		Then I should be able to see 200 in the Get SkySales response

