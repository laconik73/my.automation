Feature: UploadVirusDoc
	

@regression
Scenario: 01. Upload Virus Document via Patient Referral
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
	And user refers a service
	And user adds virus document
	Then 'error' message  with a link is displayed
	And referral is not created

Scenario:02. Scan uploaded document for malware via Documents
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads a virus document
	Then 'error' message  with a link is displayed
	And user uploads file with a note
	Then fie is successfully uploaded and note is displayed

Scenario: 03. Upload virus document via Services
	Given 'CPT' user is logged in
	When user chooses tab 'Services'
	And user  selects  'Favorite Service'
	And user click on button 'Refer'
	And user refers patient with virus document
	Then 'error' message  with a link is displayed
	Then referral is not created