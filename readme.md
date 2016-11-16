## Implementation

I've used Selenium with SpecFlow for this solution.

Most dependencies should automatically be pulled down.

This has been tested using Firefox and Chrome WebDriver, there are separate feature files for each (the scenario is the same for both)

If not already set up you'll need the WebDriver(s) for Firefox and Chrome:
 
https://github.com/mozilla/geckodriver
https://sites.google.com/a/chromium.org/chromedriver/getting-started

### Features
Contains the feature files

### Pages
Contains the various page models

### Steps
Contains the step definitions

### Utils
Additional selenium functions

## Execution
I've been using the SpecRun plugin to execute the tests, hopefully it should work with other test runners


## Instructions

Write a working test that, starting from this page (https://www.justgiving.com/4w350m3/donation/direct/charity/2050), goes through the donation process and verifies that, after various steps, you end up on the page shown in the  screenshot in the solution.

Please do not make an actual donation, in other words don't make your test click on the "Donate now" button in the final step.

We are interested in seeing your approach to writing well-structured, extensbile and maintainable UI tests.

Try to timebox this to 3 hours if you can. However, it's important that you are happy with the approach you have been able to illustrate.

Please DO NOT fork this project on Github, as we want to be sure candidates' test submissions are original.

We require you to forward the link to a cloud-based solution as zip files won’t get through our firewall.

You will need Visual Studio installed to be able to undertake the challenge. Using Visual Studio and C# is recommended. If not possible, the second preferred choice is completing it in Java. Alternatively, use a language of your choice.





