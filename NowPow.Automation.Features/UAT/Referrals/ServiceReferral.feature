Feature: ServiceReferral
	

@uat
@regression
Scenario:01. Making a Referral via Translated Service 
	Given 'CPT11' user is logged in
	When user chooses tab 'Services'
	And user  chooses  'Favorite Services'
	And user tranlates service into 'Russian'
	And user click on button 'Refer'
	And user virifies 'org', 'service', and  'intake info' are in English
	And user refers patient information with a note
	Then referral is made
