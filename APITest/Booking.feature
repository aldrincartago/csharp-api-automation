Feature: Booking 
As a User, I must be able to find, add and clear a flight.

	@booking
	Scenario: Find all available flights today
		Given I find a flight from MNL to HKG using today's date
		Then I should be able to see Success. in the response description

	@booking
	Scenario: Find a flight using a past date 
		Given I find a flight from MNL to HKG using past date
		Then I should be able to see No fares found in the error detail

	@booking
	Scenario Outline: Find flights using a future date 
		Given I find a flight from <departureStation> to <arrival station> using future date
		Then I should be able to see Success. in the response description

		Examples: 
		| departureStation | arrival station |
		| MNL              | HKG             |
		| SIN              | CEB             |

	@booking
	Scenario: Find flights without an Arrival Station
		Given I find a flight from MNL to  using future date
		Then I should be able to see The ArrivalStation field is required. in the error detail

	@booking
	Scenario: Find flights without a Departure Station
		Given I find a flight from  to CEB using future date
		Then I should be able to see The DepartureStation field is required. in the error detail

	@booking
	Scenario: Find flights using an invalid Arrival Station
		Given I find a flight from XXX to KLO using future date
		Then I should be able to see Station does not exist. in the error detail

	@booking
	Scenario: Find flights using an invalid Departure Station
		Given I find a flight from MNL to XYZ using future date
		Then I should be able to see Station does not exist. in the error detail

	@booking
	Scenario: Find flights using the same Destination and Arrival station
		Given I find a flight from MNL to MNL using future date
		Then I should be able to see No fares found in the error detail

	@booking
	Scenario: Get Booking Summary without any booked flight/s
		Given I login as a user without any booked flights
		When I get the Booking Summary
		Then I should be able to see 204 in the Get Booking response

	@booking
	Scenario: Update passenger with flights
		Given I clear all booked flights of a user
		And I add a flight from MNL to HKG using future date
		When I update a passsenger's name with Automation and Tester
		Then I should see Success. in the Update response body

	@booking
	Scenario: Update passenger without flights
		Given I clear all booked flights of a user
		When I update a passsenger's name with Automation and Tester
		Then I should see No passenger booking data found, add flights first before updating passenger information in the Update response body

	@booking
	Scenario: Book a flight
		Given I find a flight from MNL to HKG using future date
		When I book the earliest flight
		Then I should be able to see my MNL to HKG Booking Summary