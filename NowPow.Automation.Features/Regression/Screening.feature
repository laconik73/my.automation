@regression

Feature: Screening

Scenario:01. Unsaved Screening 
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user searches for a Patient
And user chooses patient card
And user chooses 'Screenings' subtab
When user clicks  'Conduct Screening' 
And user doesn't save screening
Then screening is autosaved

Scenario: 02. Verify Screening Auto Save functionality
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user searches for a Patient
And user chooses patient card
And user chooses 'Screenings' subtab
When user takes action
Then 'Complete' screening action is displayed


