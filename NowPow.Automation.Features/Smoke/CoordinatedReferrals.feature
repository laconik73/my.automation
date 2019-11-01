@smoke
@coordinated

Feature:  Coordinated Referrals

Scenario:01.  Sending Referral via Services
   Given 'CPT3' user is logged in
   When user chooses tab 'Services'
   And user searches for the organization in coordinated network
   And user click on button 'Refer'
   And user refers patient information with a note
   Then referral is made

Scenario: 02. Verify error message display for Referral Sender
Given 'CPT3' user is logged in
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
    And user makes coordinated referal
	And user clicks on status 'New'
	And user accepts referal sent
	Then 'error' message is displayed

Scenario: 03.Verify " Upload Document" modal display
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	Then 'Upload Document' modal pops up

Scenario:04. Verify "Take Action" actions to "download"
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks 'Download' action
	Then file is downloaded

Scenario:05. Delete Document from Patient Documents page
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user chooses 'Delete' action
	Then document is removed from patient's documents

Scenario: 06. Verify "Notes" modal
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Notes' action
	Then 'Notes' modal displays

Scenario: 07. Verify "Documents" subtab visibility
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user is on Patient's 'Overview' page
	Then 'Documents' subtab is displayed


Scenario:08. Error message display for virus document (Tanya's machine)
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads a virus document
	Then 'error' message  with a link is displayed







