Feature: Email
	

@smoke
Scenario:01. Sending Email via Kiosk 
	Given 'CPT10' user is logged in
	When user sends email for a service
	Then 'email' is sent and received
