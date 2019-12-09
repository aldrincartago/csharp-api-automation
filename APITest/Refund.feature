Feature: Refund
		As a User with a pending flight booking
		I should be able to Refund my booking
		Using the available API endpoints


		Scenario: Refund - Reverse
			Given I use SEUCWJ for the Refund-Reverse
			Then I should be able to see 200 in the Refund Reverse response
