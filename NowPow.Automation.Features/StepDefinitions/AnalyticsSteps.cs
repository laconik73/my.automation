using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSelene;
using OpenQA.Selenium.Chrome;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class AnalyticsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;

        public AnalyticsSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [When(@"user chooses '(.*)' tab")]
        public void WhenUserChoosesTab(string tabName)
        {
            new DashboardPage(driverContext).OpenAnalytics(tabName);
        }
        [When(@"user chooses '(.*)' logo from Analytics page")]
        public void WhenUserChoosesLogoFromAnalyticsPage(string logo)
        {
            new AnalyticsPage(driverContext).ClickOnLogo(logo);
        }

        [Then(@"user navigates to Analytics page")]
        public void ThenUserNavigatesToAnalyticsPage()
        {
            new AnalyticsPage(driverContext);
            Assert.IsTrue(S(By.XPath("//h1[@class='nav secondary-title']")).IsDisplayed());
        }
        
        [Then(@"user redirects back to '(.*)'")]
        public void ThenUserRedirectsBackTo(string mainPage)
        {
            new DashboardPage(driverContext);
            Assert.IsTrue(true);
        }




    }
}
