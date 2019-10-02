using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using static NSelene.Selene;
using OpenQA.Selenium;
using NSelene;
using System.Linq;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class SLSSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private object newWindow;

        public object Driver { get; private set; }

        public SLSSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user is on '(.*)' tab")]
        public void GivenUserIsOnTab(string tabName)
        {
            new SLSOrganizationPage(driverContext).OpenSurveyManagement(tabName);
                
                
        }
        [When(@"user searches by organization")]
        public void WhenUserSearchesByOrganization()
        {
            new SLSOrganizationPage(driverContext).SearchByOrganization("Health Corner");
        }
        [When(@"user selects organization")]
        public void WhenUserSelectsOrganization()
        {
            new SLSOrganizationPage(driverContext).SelectOrganization();
            
        }
        [Then(@"new window popups")]
        public void ThenNewWindowPopups()
        {
            new SLSOrganizationPage(driverContext);            
        }








    }
}
