Feature: Referral
	

@regression
Scenario: 01. Make Referral with attached documents via Services
	Given 'CPT11' user is logged in
	When user chooses tab 'Services'
	And user  chooses  'Favorite Services'
	And user click on button 'Refer'
	And user makes referral with a note
	And user attaches documents
	Then service referral is made

