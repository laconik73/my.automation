using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;


namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class AnalyticsReportSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;

        public AnalyticsReportSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user chooses  tab '(.*)'")]
        public void GivenUserChoosesTab(string tabName)
        {
            new DashboardPage(driverContext).OpenAdmin(tabName);
        }
        [When(@"user chooses year and month '(.*)'")]
        public void WhenUserChoosesYearAndMonth(string february)
        {
            new OrganizationPage(driverContext).OpenYearAndMonth(february);
        }
        [Then(@"the ""(.*)"" page loads")]
        public void ThenThePageLoads(string februaryAnalytics)
        {
            new OrganizationPage(driverContext);
            bool february = Verify("#reportsHeader");
            Console.WriteLine(februaryAnalytics);
        }

        
        static private bool Verify(string februaryAnalytics)
        {
            try
            {
                bool isFebruaryAnalyticsDisplayed = S(By.CssSelector("#reportsHeader")).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
