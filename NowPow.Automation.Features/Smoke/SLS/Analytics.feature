Feature: Analytics
	

@smoke
Scenario: 01. Enable Analytics for CommRx user
	Given 'SLS' user is logged in
	And user on 'Organization Management' tab
	When user enables 'Analytics'
	Then checkbox is checked

Scenario: 02. Verify Analytics tab visibility for CommRx user
	Given 'CPT5' user is logged in
	When user is on Dashboard page
	Then user gains access to 'Analytics' tab

Scenario: 03. Disable Analytics for CommRx user
	Given 'SLS' user is logged in
	And user on 'Organization Management' tab
	When user disables 'Analytics'
	Then checkbox is unchecked

Scenario: 04. Verify Analytics tab is not visible for CommRx user
	Given 'CPT5' user is logged in
	When user is on Dashboard page
	Then user gains no access to 'Analytics' tab
