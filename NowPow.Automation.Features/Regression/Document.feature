@regression

Feature: Document

Scenario:01. Verify N increases of Duplicate File Name
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads file
	And user clicks on 'Upload Document' 
	And user uploads file
	Then file is uploaded as 'Duplicate Name' and increases by '1' unit

Scenario: 02.Delete document from Patient Document Page
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user chooses 'Delete' action
	And user proceeds with 'Delete'	
	Then document is deleted

Scenario: 03. Verify "Upload Document" modal features
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user chooses one file to upload
	Then 'Upload' button is enabled
	And a user chooses 'Cancel' button
	Then modal is closed
	And user clicks on 'Upload Document' again
	Then any data entered on the previous modal is cleared

Scenario: 04. Verify "Add Document" button
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
	And user refers a service
	And user adds document
	And user adds another document
	Then the files display as separate lines

Scenario:05. Remove files from "Make Referral" modal
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
	And user refers a service
	And user adds document
	And user adds another document
	And user deletes a document
	Then document is removed

Scenario: 06. Upload Virus Document (Tanya's machine)
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
	And user refers a service
	And user adds virus document
	Then 'error' message  with a link is displayed
	And referral is not created

Scenario:07. Scan uploaded document for malware (Tanya's machine)
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads a virus document
	Then 'error' message  with a link is displayed
	And user uploads file with a note
	Then fie is successfully uploaded and note is displayed

Scenario: 08. Upload virus document via Services
Given 'CPT3' user is logged in
   When user chooses tab 'Services'
   And user  selects  'Favorite Service'
   And user click on button 'Refer'
   And user refers patient with virus document
	Then referral is not created

Scenario: 09. Add/Remove files from Sent Referrals
Given 'CPT3' user is logged in
And user is on 'Referrals Sent' page
When user is on referral with attached document
And user decides to delete a document
Then document is removed from Sent Referrals

Scenario: 10. Add/Remove files from Received Referrals
Given 'CPT4' user is logged in
When user is on received referrals with attached document
And user deletes document
Then document is removed from Received Referrals

Scenario: 11. Add files to Sent Referrals
Given 'CPT3' user is logged in
And user is on 'Referrals Sent' page
When user is on referral with attached document
Then file is added to Sent Referrals

Scenario: 12. Add files to Received Referrals
Given 'CPT4' user is logged in
When user is on received referrals with attached document
Then file is added to Received Referrals

Scenario: 13. Remove files from Sent Referrals
Given 'CPT3' user is logged in
And user is on 'Referrals Sent' page
When user decides to delete a document
Then document is removed from Sent Referrals

Scenario: 14. Remove files from Received Referrals
Given 'CPT4' user is logged in
And user is on Referrals Received page
When user deletes document
Then document is removed from Received Referrals

Scenario: 15. View Shared Documents of Referrals Sent
Given 'CPT3' user is logged in
And user is on 'Referrals Sent' page
When user views documents 
And user downloads document
Then document is downloaded

Scenario: 16. Verify Default Documents table sorting
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads file
	Then documents are sorted by Upload Date in Descending order
	And user refreshes page
	Then documents are sorted by Upload Date in Descending order

Scenario: 17. Verify Documents table sorting
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'	
	When user clicks on 'Document Name' column
	Then documents are displayed in Ascending order
	And user chooses 'Upload Date' column
	Then dates are displayed in Ascending order
	







   









