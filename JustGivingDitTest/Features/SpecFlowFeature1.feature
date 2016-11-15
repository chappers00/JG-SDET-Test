Feature: Make some donations
As a really good interview candidate
I want to make lots of donations to the test charity
So that you guys give me the job

Scenario: Open the donation page, validate header
	Given I have the home page open
	Then the 'Donate' section is displayed
	And the header should be 'Donate to The Demo Charity 2 (JustGiving Demo)'

@selenium
Scenario: Make a 30 pound donation
	Given I have the home page open
	When I press the continue button
	Then the 'Identity' section is displayed
	And a donation by 'Anonymous' is created with a message of '(no message)' and amount of '£30'

Scenario: Change currency to euros
	Given I have the home page open
	And I have changed currency to 'EUR'
	When I press the continue button
	Then the 'Identity' section is displayed
	And a donation by 'Anonymous' is created with a message of '(no message)' and amount of '€30'

Scenario: Make a twenty euro donation
	Given I have the home page open
	And I have entered an amount of '20'
	And I have changed currency to 'EUR'
	When I press the continue button
	Then the 'Identity' section is displayed
	And a donation by 'Anonymous' is created with a message of '(no message)' and amount of '€20'
