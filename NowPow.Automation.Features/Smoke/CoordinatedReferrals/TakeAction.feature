Feature: TakeAction
	

@smoke
Scenario:01. Verify "Take Action" actions to "download"
	Given 'CPT4' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks 'Download' action
	Then file is downloaded

Scenario:02. Delete Document from Patient Documents page
	Given 'CPT4' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user chooses 'Delete' action
	Then document is removed from patient's documents

Scenario: 03. Verify "Notes" modal
	Given 'CPT4' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Notes' action
	Then 'Notes' modal displays
