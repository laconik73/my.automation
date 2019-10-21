@cpt_username
@smoke
Feature: Erx

Scenario:01.Viewing eRx from Patient Card
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses patient card
When user chooses 'View eRx' button 
Then referred services are displayed under patient 'eRx' code 
And user chooses 'Back to Patient' button
Then user is back on 'Overview' patient card

Scenario:02. Verify Building New eRx button via Patient Card
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses patient card
When user selects button 'Build New eRx'  
Then 'eRx Landing' displays 'centered pannel'
And user chooses 'Back to Patient' button
Then user is back on 'Overview' patient card

Scenario:03. Creating Automatic eRx via Patient Profile
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses patient card
When user makes a choice to 'Edit Profile'
And user inputs address into 'Contact Information' section
And user adds condition into 'Conditions' section
Then automatic eRx is generated


Scenario:04. Generating Automatic eRx via Patient Card
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user searches for a Patient
And user chooses patient card
When user navigates to 'Generate Automatic eRx'  
Then user is able to 'Add New' or 'Save' eRx
And user chooses 'Back to Patient' button
Then user is back on 'Overview' patient card

Scenario:05. Verify card toppers activation
Given 'CPT' user is logged in
And user chooses 'eRx' tab
And 'eRx Landing' displays 'centered pannel'
When user inputs address into the 'Location' 
Then card toppers 'Service Categories' and 'Conditions' are activated


Scenario:06. Viewing eRx from eRx Page
Given 'CPT' user is logged in
And user chooses 'eRx' tab
And 'eRx Landing' displays 'centered pannel'
When user chooses to 'View Existing HealtheRx'
And user inputs 'HealtheRx' code
Then displayed eRx code matches the inputted 'HealtheRx' code

Scenario:07. Build New eRx via Patient Card
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses patient card
When user selects button 'Build New eRx'
And user selects 'Conditions'
And user makes selections from 'Add Filters'
Then 'HealtheRx' is generated

Scenario: 08.Adding a Service on an Erx
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses patient card
When user chooses 'View eRx' button
And user chooses to 'Edit' eRx
And user chooses 'Add' service
And user selects a service
Then new service saved on an Erx

Scenario: 09. Deleting a Service on an Erx
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses patient card
When user chooses 'View eRx' button
And user chooses to 'Edit' eRx
And user removes services from an Erx
Then service is removed from an Erx

Scenario: 10.Creating an Erx via Service Categories
Given 'CPT' user is logged in
And user chooses 'eRx' tab
And 'eRx Landing' displays 'centered pannel'
When user inputs address into the 'Location' 
And card toppers 'Service Categories' and 'Conditions' are activated
And user selects 'Service Categories' card topper
And user makes selections from 'Add Filters'
Then 'HealtheRx' is generated

Scenario: 11.Sending Email Nudge via eRx Page
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses patient card
When user chooses 'View eRx' button
And user sends nudge
Then email nudge is sent 






















