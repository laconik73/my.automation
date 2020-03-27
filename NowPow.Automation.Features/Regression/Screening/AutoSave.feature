Feature: AutoSave
	As a user, I want my screening to be saved 
	in the case that my browser window closes.NQ-T11990


@regression
Scenario:01. Verify Screening Auto Save functionality 
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses 'Screenings' subtab
	When user clicks  'Conduct Screening' 
	And user doesn't save screening
	Then screening is autosaved
