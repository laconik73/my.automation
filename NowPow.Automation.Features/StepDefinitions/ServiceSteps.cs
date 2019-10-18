using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class ServiceSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        String note;


        public ServiceSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }


        [When(@"user chooses tab '(.*)'")]
        public void WhenUserChoosesTab(string tabName)
        {
            new DashboardPage(driverContext).OpenServices(tabName);
        }

        [When(@"user  chooses  '(.*)'")]
        public void WhenUserChooses(string favoriteServices)
        {
            new ServicePage(driverContext).OpenFavoriteService();
        }
        [When(@"user searches for the organization in coordinated network")]
        public void WhenUserSearchesForTheOrganizationInCoordinatedNetwork()
        {
            new ServicePage(driverContext)
                .SearchServices("moore")
                .Submit()
                .ClickServiceLink();
        }
        [When(@"user click on button '(.*)'")]
        public void WhenUserClickOnButton(string Refer)
        {
             new ServicePage(driverContext).Refer();
           
        }

        [When(@"user refers patient information with a note")]
        public void WhenUserRefersPatientInformationWithANote()
        {
            note = DateTime.Now.Ticks.ToString();
            var modal = new MakeReferralModal(driverContext).MakeReferral();
            modal.PatientMrn("john")
                .SelectFirstDataset()
                .WriteNote(note)
                .SelectCheckbox()
                .Send();
        }
        [Then(@"referral is made")]
        public void ThenReferralIsMade()
        {
            new ServicePage(driverContext);
            String expectedReferral = S(By.XPath("//h4[contains(text(),'Service Offerings')]")).GetText();
            string actualReferral = "Service Offerings";
            Assert.AreEqual(expectedReferral, actualReferral);
        }
        

    }
}


