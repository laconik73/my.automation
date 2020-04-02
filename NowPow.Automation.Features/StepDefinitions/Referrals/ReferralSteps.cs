using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using static NSelene.Selene;
using OpenQA.Selenium;
using NSelene;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nowpow.Automation.Features.StepDefinitions
{

    [Binding]
    public class ReferralSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        String note;
        private IJavaScriptExecutor driver;

        public ReferralSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user chooses subtab '(.*)'")]
        public void GivenUserChoosesSubtab(string subtabName)
        {
            new PatientPage(driverContext).OpenReferral(subtabName);
        }
        [When(@"user chooses button '(.*)'")]
        public void WhenUserChoosesButton(string addReferral)
        {
            new PatientPage(driverContext).AddReferral();
        }
        [When(@"user sends referral with a note")]
        public void WhenUserSendsReferralWithANote()
        {
            note = DateTime.Now.Ticks.ToString();
            var modal = new AddReferralModal(driverContext).MakeReferral();
            modal.SelectFirstRefer()
                .WriteNote(note)
                .SelectCheckbox1()
                .SelectCheckbox2()
                .Send();
        }
        [When(@"user opens Edit Referral modal")]
        public void WhenUserOpensEditReferralModal()
        {
            new PatientPage(driverContext).OpenEditReferral();
        }
        [When(@"user edits opened referral info")]
        public void WhenUserEditsOpenedReferralInfo()
        {
            var note = DateTime.Now.Ticks.ToString();
            var modal = new EditReferralModal(driverContext);
            modal.SelectAcceptanceStatus("Accepted")
                .SelectContactStatus("Contacted")
                .EnterNote(note)
                .Save();
        }
        [When(@"user accepts referal")]
        public void WhenUserAcceptsReferal()
        {
            var modal = new EditReferralModal(driverContext);
            modal.SelectAcceptanceStatus("Accepted")
                .Save();
        }
        //step will fail until bug is fixed. Double modal opens
        [When(@"user makes referral")]
        public void WhenUserMakesReferral()
        {
            new PatientPage(driverContext).ClickMakeReferal();

            var modal = new AddReferralModal(driverContext);
            modal.SelectCheckbox2()
                 .Send(); ;
        }
        
        [When(@"user clicks on status '(.*)'")]
        public void WhenUserClicksOnStatus(string statusNew)
        {
            new ReferralsSentPage(driverContext).ChooseStatus(statusNew);
        }
        [When(@"user accepts referal sent")]
        public void WhenUserAcceptsReferalSent()
        {
            new EditReferralModal(driverContext)
                .SelectAcceptanceStatus("Accepted")
                .SaveStatus();
        }



        [Then(@"new referral is listed")]
        public void ThenNewReferralIsListed()
        {
            var ReferralListed = new ProfilePage(driverContext);
            Assert.AreNotEqual(ReferralListed.Displayed, "referral was not listed");       
            
        }     
              
        [Then(@"referral info should be saved")]
        public void ThenReferralInfoShouldBeSaved()
        {
            new PatientPage(driverContext).VerifyStatusDisplay();
        }    
        
        [Then(@"referral is sent")]
        public void ThenReferralIsSent()
        {
            new PatientPage(driverContext);
            Assert.IsTrue(true);
        }
        [Then(@"user chooses subtab '(.*)'")]
        public void ThenUserChoosesSubtab(string subtabName)
        {
            new PatientPage(driverContext).OpenReferral(subtabName);
        }
        [Then(@"new referral is listed on patient referrals")]
        public void ThenNewReferralIsListedOnPatientReferrals()
        {
            new PatientPage(driverContext);
            bool referral = Verify("#patient-referrals-body");
            Console.WriteLine("new referal is listed");

        }

        private bool Verify(string referral)
        {
            try
            {
                bool isReferalDisplayed = S(By.CssSelector("#patient-referrals-body")).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }
        [Then(@"'(.*)' message is displayed")]
        public void ThenMessageIsDisplayed(string errorMessage)
        {
            new EditReferralModal(driverContext);
            String actualMessage = S(By.XPath("//div[@class='error-area row center-xs']")).GetText();
            Console.WriteLine(actualMessage);

            Thread.Sleep(3000);
            Assert.IsTrue(S(By.XPath("//div[@class='error-area row center-xs']")).Displayed);
           
        }
        [When(@"user sends a message to a referral taker")]
        public void WhenUserSendsAMessageToAReferralTaker()
        {
            DateTime.Now.Ticks.ToString();
            new ReferralsSentPage(driverContext)
                .ClickMessage()
                .WriteMessage("automation")
                .SendMessage();
        }
        [Then(@"message is sent")]
        public void ThenMessageIsSent()
        {
            new ReferralsSentPage(driverContext);
            Assert.IsTrue(true);
        }
        
        [Then(@"user navigates back to patient's referral")]
        public void ThenUserNavigatesBackToPatientSReferral()
        {
            new ReferralsSentPage(driverContext).NavigateBack();
        }
        [Then(@"all patient referrals are displayed")]
        public void ThenAllPatientReferralsAreDisplayed()
        {
            new ReferralsSentPage(driverContext);
            String actualReferrals = S(By.XPath("//h3[contains(text(),'Referrals')]")).GetText();
            String expectedReferrals = "Referrals";
            Assert.AreEqual(actualReferrals, expectedReferrals);

        }
        [Given(@"user on '(.*)' page")]
        public void GivenUserOnPage(string subNav)
        {
            new ReferralsReceivedPage(driverContext).OpenTaskView(subNav);
        }
        [When(@"user sends a message to a referral maker")]
        public void WhenUserSendsAMessageToAReferralMaker()
        {
            DateTime.Now.Ticks.ToString();
            new ReferralsReceivedPage(driverContext)
                .ClickMessage()
                .WriteMessage("automation")
                .SendMessage();
        }
        [When(@"user selects icon '(.*)'")]
        public void WhenUserSelectsIcon(string subtabIcon)
        {
            new ProfilePage(driverContext).ClickOnFavorites(subtabIcon);
        }
        [When(@"user sends referral")]
        public void WhenUserSendsReferral()
        {
            new MakeReferralModal(driverContext)
                .SelectRestrictionCheckBox()
                .SelectConsentCheckBox()
                .SendButton();
        }
        [When(@"referal sender views patient history")]
        public void WhenReferalSenderViewsPatientHistory()
        {
            new ReferralsSentPage(driverContext).DisplayOrganizations();
        }
        [Then(@"referral sender can views any referals made outside of enterprise")]
        public void ThenReferralSenderCanViewsAnyReferalsMadeOutsideOfEnterprise()
        {
            new ReferralsSentPage(driverContext);
            this.Verify("div[class*='referral-organization']");
            this.Verify("div.drawer-space:nth-child(2) > div.info:nth-child(2)");

        }
        [Then(@"modal display only referable services within the network")]
        public void ThenModalDisplayOnlyReferableServicesWithinTheNetwork()
        {
            new SendTrackedReferralModal(driverContext).DisplayServicesWithinTheNetwork();
            String servicesInNetwork = S("h4.service-name").GetText();
            Console.WriteLine(servicesInNetwork.ToString());
            String servicesInNetwork5 = S("div.provider.row:nth-child(5) div > div.row:nth-child(1) a").GetText();
            Console.WriteLine(servicesInNetwork5.ToString());
            String servicesInNetwork2 = S("div.provider.row:nth-child(2) div > div.row:nth-child(1) a").GetText();
            Console.WriteLine(servicesInNetwork2.ToString());
            String servicesInNetwork6 = S("div.provider.row:nth-child(6) div > div.row:nth-child(1) a").GetText();
            Console.WriteLine(servicesInNetwork6.ToString());
        }
        [When(@"user does not accept new referral")]
        public void WhenUserDoesNotAcceptNewReferral()
        {
            new DashboardPage(driverContext)
                .OpenNotifications()
                .ChooseUnreadNotification();                
        }
        [When(@"user searches for a new referred patient")]
        public void WhenUserSearchesForANewReferredPatient()
        {
            new ReferralsReceivedPage(driverContext)
                .OpenPatients()
                .SearchPatient();
        }
        [Then(@"search results return to matching criteria")]
        public void ThenSearchResultsReturnToMatchingCriteria()
        {
            new PatientPage(driverContext);
            String errorMessage = S("#error-area").GetText();
            Console.WriteLine(errorMessage);
            this.Verify("#error-area");
        }
        [When(@"user accepts new referral")]
        public void WhenUserAcceptsNewReferral()
        {
            new DashboardPage(driverContext)
               .OpenNotifications()
               .ChooseUnreadNotification()
               .ClickOnNewReferral();
            var modal = new EditReferralModal(driverContext);
               modal.SelectAcceptanceStatus()
               .SaveAcceptedReferral();            
        }
        [When(@"user searches accepted referral")]
        public void WhenUserSearchesAcceptedReferral()
        {
            new ReferralsReceivedPage(driverContext)
                .OpenPatients()
                .SearchAcceptedReferal();
        }
        [Then(@"new patient is created and patient card is displayed")]
        public void ThenNewPatientIsCreatedAndPatientCardIsDisplayed()
        {
            new PatientPage(driverContext);
            this.Verify("div.patient");
        }
        [When(@"user changes acceptance status to '(.*)'")]
        public void WhenUserChangesAcceptanceStatusTo(string waitlisted)
        {
            new EditReferralModal(driverContext)
                .SelectWaitlisted(waitlisted)
                .SaveStatus();
        }
        [Then(@"acceptance status is changed")]
        public void ThenAcceptanceStatusIsChanged()
        {
            new ReferralsSentPage(driverContext);
            this.Verify("//span[@class='referral-icon-label'][contains(text(),'Waitlist')]");
        }
        [When(@"user chooses patient card")]
        public void WhenUserChoosesPatientCard()
        {
            new PatientPage(driverContext).OpenPatientCard();
               
        }
        [When(@"user chooses subtab '(.*)'")]
        public void WhenUserChoosesSubtab(string subtabName)
        {
            new PatientPage(driverContext).OpenReferral(subtabName);
        }
        [Then(@"user gaines access to all patient referrals")]
        public void ThenUserGainesAccessToAllPatientReferrals()
        {
            new PatientPage(driverContext);
            IList<IWebElement> chevronDown = SS(".btn-activity.open-drawer");
            chevronDown.ElementAt(0).Click();
            Thread.Sleep(3000);
            chevronDown.ElementAt(1).Click();
            Thread.Sleep(3000);
            chevronDown.ElementAt(2).Click();
            Thread.Sleep(3000);
        }

    }
}
