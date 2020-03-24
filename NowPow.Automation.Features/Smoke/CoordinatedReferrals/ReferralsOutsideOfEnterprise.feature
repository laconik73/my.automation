Feature: ReferralsOutsideOfEnterprise
	

@smoke
Scenario: 02. Referral Sender views patient referrals outside of enterprise 
	Given 'CPT4' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'	
	When referal sender views patient history
	Then referral sender can views any referals made outside of enterprise
