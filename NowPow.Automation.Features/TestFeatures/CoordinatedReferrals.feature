@cpt_username

Feature:  Coordinated Referrals

Scenario:01.  Sending Referral via Services
   Given 'CPT' user is logged in
   When user chooses tab 'Services'
   And user searches for the organization in coordinated network
   And user click on button 'Refer'
   And user refers patient information with a note
   Then referral is made


