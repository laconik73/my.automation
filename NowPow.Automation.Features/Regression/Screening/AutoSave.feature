Feature: AutoSave
	

@regression
Scenario:01. Unsaved Screening 
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses 'Screenings' subtab
	When user clicks  'Conduct Screening' 
	And user doesn't save screening
	Then screening is autosaved
