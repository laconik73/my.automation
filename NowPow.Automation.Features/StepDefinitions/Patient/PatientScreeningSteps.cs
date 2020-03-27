using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSelene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class PatientScreeningSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;

        public PatientScreeningSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [When(@"user clicks  '(.*)'")]
        public void WhenUserClicks(string button)
        {
            new PatientScreeningPage(driverContext)
                .ConductScreening(button)
                .StartButton()
                .SelectFirstSection()
                .Next();
        }
        [When(@"user doesn't save screening")]
        public void WhenUserDoesnTSaveScreening()
        {
            new ConductScreeningPage(driverContext)
                .RefreshPage()
                .BackToPatientScreening();
        }
        [When(@"user expands '(.*)'")]
        public void WhenUserExpands(string dropdown)
        {
            new PatientScreeningPage(driverContext).OpenTakeAction(dropdown);
        }

        [Then(@"screening is autosaved")]
        public void ThenScreeningIsAutosaved()
        {
            new PatientScreeningPage(driverContext);                    

            String incompleteScreening = S("span.card-label i").Text;
            Console.WriteLine(incompleteScreening.ToString());
        }
        [Then(@"'(.*)' screening action is displayed")]
        public void ThenScreeningActionIsDisplayed(string completeAction)
        {
            new PatientScreeningPage(driverContext);
            Assert.IsTrue(S(By.LinkText("Complete")).IsDisplayed());
        }


    }
}
