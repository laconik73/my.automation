@regression

Feature:  Patient

Scenario:01.  Editing Patient Contact Information
   Given 'CPT' user is logged in
   And user chooses tab 'Patient'
   And user chooses patient card
   When user makes a choice to 'Edit Profile'
   And user expands 'Contact Information' section
   And user edits 'Contact Information'
   Then edited contact information is displayed in patient's 'Consent'

#Scenario:02. Editing Patient Demographics
#Given 'CPT' user is logged in
#   And user chooses tab 'Patient'
#   And user chooses patient card
#   When user makes a choice to 'Edit Profile'
#   And user expands  patient 'Demographics' section
#   And user edits patient 'Demographics'
#   Then demographics are updated in patient overview

#Scenario: 03. Editing Patient Basic Information
#Given 'CPT' user is logged in
#   And user chooses tab 'Patient'
#   And user searches for a Patient
#   And user chooses patient card
#   When user makes a choice to 'Edit Profile'
#   And user edits basic information
#   Then basic information in updated in patient overview

Scenario: 04.Verify Patient Search by MRN
Given 'CPT' user is logged in
   And user chooses tab 'Patient'
   When user searches patient by 'MRN'
   Then patient matching mrn is dispayed

Scenario: 05.Verify invalid name/mrn search
Given 'CPT' user is logged in
   And user chooses tab 'Patient'
   When user input invalid name
   Then no results are dispayed

Scenario: 06. Adding a Patient Engagement Interaction
Given 'CPT' user is logged in
   And user chooses tab 'Patient'
   And user chooses patient card
   When user adds a new interaction with a note
   Then new interaction is created
   And user chooses 'NowPow' logo
   Then patient card is listed under 'Recent Patients' section



