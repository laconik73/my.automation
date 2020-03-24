Feature: CompleteCoordinated
	

@uat
@regression
Scenario: 01.Complete coordinated screening with eRx (coordinated maker)
#community north org in stage(CPT1)
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses 'Screenings' subtab
	When user clicks on 'Conduct Screening' button
	And user 'completes' coordinated screening
	And user saves generated eRx
	Then eRx is saved
