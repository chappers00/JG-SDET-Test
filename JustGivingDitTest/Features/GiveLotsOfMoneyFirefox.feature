@firefox
Feature: Make some donations using the firefox browser
	As a great prospective Lead SDET
	I want to make lots of donations to the test charity
	So that you guys give me the job

Background: Open the donation page, validate header
	Given I have the home page open
	Then the 'Donate' section is displayed
	And the header should be 'Donate to The Demo Charity (JustGiving Demo)'

#There seems to be a bug if you've typed the address manually the review page doesn't show the full address
#Another scenario would use the postcode search but it's not possible to get the exact address in the screenshot
#Taking out the "Then a donation by 'Anonymous'...." step would make the scenario read clearer but it's an example of validating on each page
Scenario: Make a twenty euro donation
	Given I have entered an amount of '20' in 'EUR'
	Then a donation by 'Anonymous' is created with a message of '(no message)' and amount of '€20'
	When I enter an email address of 'hire@me.com'
	And I enter a password of 'hireme'
	And I pay with a 'Visa Credit Card' with number '4111-1111-1111-1111' expiry '01' '2020' and name 'My Name'
	And I enter billing details of 'JustGiving - Blue Fin Building (2nd floor), Southwark Street, London, SE1 0TA, United Kingdom'
	Then the 'ReviewAndDonate' section is displayed

