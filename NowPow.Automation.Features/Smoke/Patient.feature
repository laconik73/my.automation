@cpt_username
@smoke

Feature: Patient

Scenario:01. Creating New Profile
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses 'Create New Profile'
When user navigates to patient's section
And user inputs 'Basic Information'
And user chooses 'Save and Create'
Then New Profile is created

Scenario:02. Verifying New Patient Card
Given 'CPT' user is logged in
And user chooses tab 'Patient'
When user inputs new patient name into 'Search' field
Then results displayed

Scenario:03. Verify Email Consent Toggles
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses patient card
When user switches toggle 'On' and 'Off'
Then patient confirms email configuration

Scenario:04. Sending Email Nudge via Patient Page
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses patient card
When user sends email nudge with an attachment
Then new interaction is displayed under patient engagement


