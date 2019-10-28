@regression

Feature: Document

Scenario: Verify N increases of Duplicate File Name
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads file
	And user clicks on 'Upload Document' 
	And user uploads file
	Then file is uploaded as 'Duplicate Name' and increases by '1' unit


