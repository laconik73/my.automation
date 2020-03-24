Feature: IncompleteCoordinated
	

@uat
@regression
Scenario:01. Verify incomplete coordinated screening (maker)
#community north org in stage(CPT1)
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses 'Screenings' subtab
	When user clicks on 'Conduct Screening' button
	And user saves coordinated 'incomplete' screening
	Then patient's screening display 'incomplete' screening

Scenario:02.Verify incomplete coordinated screening (taker)
	Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	When user searches for a Patient with 'incomplete' screening
	Then patient card display 'date' and 'icon' under Last Screen
