@cpt_username
@smoke

Feature: Screenings

Scenario: 01. Making Patient Screening
Given 'CPT' user is logged in
And user chooses a tab 'Screenings'
When user chooses  'Start'
And user answers screening questions
And saves screening with a note
Then note is displayed below screening summary

Scenario: 02.Verify Screening via Patient 
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user chooses patient card
And user chooses 'Screenings' subtab
When user clicks on 'Conduct Screening' button
Then user able to conduct screening for a patient

Scenario: 04. Verify Screeening with Code via Patient
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user searches for a Patient
And user chooses patient card
And user chooses 'Screenings' subtab
When user clicks on 'Conduct Screening' button
And user chooses to complete screening with 'Get Code'
Then user able to conduct screening for a patent with code

Scenario: 03. Saving an Incomplete Screening via Patient
Given 'CPT' user is logged in
And user chooses tab 'Patient'
And user searches for a Patient
And user chooses patient card
And user chooses 'Screenings' subtab
When user clicks on 'Conduct Screening' button
And user chooses  'Start'
And user saves screening for later
Then user returns to the Patient's Page with incomplete screening

























   