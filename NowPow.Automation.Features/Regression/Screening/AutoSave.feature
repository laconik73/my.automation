Feature: AutoSave
	As a user, I want my screening to be saved 
	in the case that my browser window closes


Background: 
	Given 'CPT11' user is logged in	
	And user chooses patient card
	And user chooses 'Screenings' subtab

@regression
Scenario:01. Verify Screening Auto Save functionality.NQ-T11990	
	When user clicks  'Conduct Screening' 
	And user doesn't save screening
	Then screening is autosaved
