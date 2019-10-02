@cpt_username

Feature: Service

Scenario:01.  Making Service Referral
   Given 'CPT' user is logged in
   When user chooses tab 'Services'
   And user  chooses  'Favorite Services'
   And user click on button 'Refer'
   And user refers patient information with a note
   Then referral is made
 

