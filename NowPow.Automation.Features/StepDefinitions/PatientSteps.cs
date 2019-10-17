﻿using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class PatientSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;

        public PatientSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user chooses tab '(.*)'")]
        public void GivenUserChoosesTab(string tabName)
        {
            new DashboardPage(driverContext).OpenPatient(tabName);
                  
        }
        [Given(@"user chooses '(.*)'")]
        public void GivenUserChooses(string createNewProfile)
        {
            new PatientPage(driverContext).OpenNewProfile();
        }
        [When(@"user navigates to patient's section")]
        public void WhenUserNavigatesToPatientSSection()
        {
            new PatientPage(driverContext);
        }
        [When(@"user inputs '(.*)'")]
        public void WhenUserInputs(string basicInformation)
        {
            new PatientPage(driverContext)
                .EnterFirstName("sabina")
                .EnterLastName("smoke")
                .EnterDateOfBirth("mm/dd/yyyy")
                .SelectGender("female");                
        }
        [When(@"user chooses '(.*)'")]
        public void WhenUserChooses(string saveandcreate)
        {
            new ProfilePage(driverContext);
        }
        [Then(@"New Profile is created")]
        public void ThenNewProfileIsCreated()
        {
            new ProfilePage(driverContext);
        }
        [When(@"user inputs new patient name into '(.*)' field")]
        public void WhenUserInputsNewPatientNameIntoField(string patientName)
        {
            new ProfilePage(driverContext).InputPatientName();
              
        }
        [Then(@"results displayed")]
        public void ThenResultsDisplayed()
        {
            new PatientPage(driverContext).View();
        }
        [When(@"user switches toggle '(.*)' and '(.*)'")]
        public void WhenUserSwitchesToggleAnd(string toggleOn, string toggleOff)
        {
            new PatientPage(driverContext).SwitchEmailToggle(toggleOn, toggleOff);
        }        
        [Then(@"patient confirms email configuration")]
        public void ThenPatientConfirmsEmailConfiguration()
        {
            new PatientPage(driverContext).ConfirmEmailConfiguration();
        }
        [When(@"user sends email nudge with an attachment")]
        public void WhenUserSendsEmailNudgeWithAnAttachment()
        {
            
            var modal = new PatientPage(driverContext).SendNudge();
            modal.ClickEmailIcon()
              .InputEmail("nowpow.dev@gmail.com")
              .AddErx()
              .SendNudge();
        }
        [Then(@"new interaction is displayed under patient engagement")]
        public void ThenNewInteractionIsDisplayedUnderPatientEngagement()
        {
            new PatientPage(driverContext);
            bool emailNudge = Verify("#engagement-history");
            Console.WriteLine("Emailed patient is displayed");
        }

        private bool Verify(string nudge)
        {
            try
            {
                bool isNudgeDisplayed = S(By.XPath("//span[contains(text(),'Emailed Patient')]")).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
   
       
      