Feature: TaskView
	

@regression
Scenario: 01.Adding Upcoming Appointment via Task View
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	And user on 'Task View' page
	When user adds appointment
	Then new appointment is listed in 'Upcoming Appts'
	And 'Upcoming Appts' index increases by 1

Scenario: 02.Deleting Upcoming Appointment via Task View
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	And user on 'Task View' page
	When user deletes upcoming appointment
	Then new appointment is deleted from 'Upcoming Appts'
	And 'Upcoming Appts' index decreases by 1
