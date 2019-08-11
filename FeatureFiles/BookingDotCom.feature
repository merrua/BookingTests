@Chrome
Feature: Booking Dot Com
	In order to book a hotel
	As a user
	I want to be view what options are available

Background: 
	Given I go to the BookingDotCom main page 

Scenario: Booking Dot Com Main Page
	Then the page title is 'Booking.com: 29,184,176 hotel and property listings worldwide. 188+ million hotel reviews.'

Scenario: Booking Dot Com Search Results 
	Given I search for the text 'Limerick'
	When I click on the submit button
	Then I see the Facilities text
	Then the page title contains 'Limerick'

Scenario: Hotel with a sauna
	Given I search for the text 'Limerick'
	Given I choose 1 night stay in 3 months
	Given I pick 2 adults
	Given I pick 1 room
	When I click on the submit button
	When I select the sauna filter
	Then we expect 'Greenhills Hotel Limerick' 'is' in the results

Scenario: Hotel without a sauna
	Given I search for the text 'Limerick'
	Given I choose 1 night stay in 3 months
	Given I pick 2 adults
	Given I pick 1 room
	When I click on the submit button
	When I select the sauna filter
	Then we expect 'George Limerick Hotel' 'is not' in the results

Scenario: Savoy is a 5 star hotel
	Given I search for the text 'Limerick'
	Given I choose 1 night stay in 3 months
	Given I pick 2 adults
	Given I pick 1 room
	When I click on the submit button
	When I select the five star filter
	Then we expect 'The Savoy Hotel' 'is' in the results

Scenario: George is not a 5 star hotel
	Given I search for the text 'Limerick'
	Given I choose 1 night stay in 3 months
	Given I pick 2 adults
	Given I pick 1 room
	When I click on the submit button
	When I select the five star filter
	Then we expect 'George Limerick Hotel' 'is not' in the results