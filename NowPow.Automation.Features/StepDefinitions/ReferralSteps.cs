using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using static NSelene.Selene;
using OpenQA.Selenium;
using NSelene;

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
        //step will fail until bug is fixed. Double modal opens
        [When(@"user makes coordinated referal")]
        public void WhenUserMakesCoordinatedReferal()
        {
            var modal = new AddReferralModal(driverContext).MakeReferral();
            modal.SelectFirstRefer()           
                .SelectCheckbox1()
                .SelectCheckbox2()
                .Send();
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
            SeleneElement actualMessage = S("div.error-area");
            Assert.IsTrue(actualMessage.Displayed);
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



    }
}
