Feature: SurveyManagement
	

@smoke
Scenario:01. Verify Popup window
	Given 'SLS' user is logged in
	And user is on 'Survey Management' tab
	When user searches by organization
	And user selects organization
	Then new window popups

Scenario: 02. Verify Survey Management Page search box
	Given 'SLS' user is logged in
	And user is  on 'Survey Management' page
	When user searches for an organization
	Then page display matching results 
	And user cleares the input
	Then input box is cleared and page display '1 to 50' organizations
	And user searches for an invalid organization
	Then no search results are displayed
	And user cleares the input
	Then input box is cleared and page display '1 to 50' organizations

Scenario: 03. Verify Organization Preview Page
	Given 'SLS' user is logged in
	And user is  on 'Survey Management' page
	When user searches for an organization
	And user chooses to preview an organization
	Then new tab displays organization information

Scenario: 04. Updating a Service
	Given 'SLS' user is logged in
	And user is  on 'Survey Management' page
	When user searches for an organization
	And user chooses to edit organization service
	Then changes are saved
