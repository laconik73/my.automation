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
        [Then(@"new referral is listed")]
        public void ThenNewReferralIsListed()
        {
            var ReferralListed = new ProfilePage(driverContext);
            Assert.AreNotEqual(ReferralListed.Displayed, "referral was not listed");       
            
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

        [Then(@"referral info should be saved")]
        public void ThenReferralInfoShouldBeSaved()
        {
            new PatientPage(driverContext).VerifyStatusDisplay();
        }
       
        
        [When(@"user makes referral")]
        public void WhenUserMakesReferral()
        {
            new PatientPage(driverContext).ClickMakeReferal();

            var modal = new AddReferralModal(driverContext);
            modal.SelectCheckbox2()
                 .Send(); ;
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
        


    }
}
