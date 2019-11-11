using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using NSelene;
using static NSelene.Selene;
using OpenQA.Selenium;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private object userType;

        public object Driver { get; private set; }

        public LoginSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"'(.*)' user is logged in")]
        public void GivenUserIsLoggedIn(string userType)
        {
            

            if (userType.Contains("CPT"))
            {
                var userIndex = userType.Replace("CPT", "");
                //var envConsoleParameter = TestContext.Parameters["environment"];
                //var envURL = ConfigurationManager.AppSettings[envConsoleParameter + "_url"];
                var userName = ConfigurationManager.AppSettings["cpt_username"].Replace("@", userIndex + "@");
                new LoginPage(driverContext)
                                 .GoTo()
                                 .EnterEmail(userName)
                                 .Submit()
                                 .EnterPassword(ConfigurationManager.AppSettings["cpt_password"])
                                 .SignIn();
            }
            else if (userType == "SLS")
            {

                new SLSLoginPage(driverContext)
                    .GoTo(ConfigurationManager.AppSettings["sls_url"])
                    .EnterUsername(ConfigurationManager.AppSettings["sls_username"])
                    .EnterPassword(ConfigurationManager.AppSettings["sls_password"])
                    .LoginButton();
            }           
            
        }
        [When(@"'(.*)' user is logged in a new window")]
        public void WhenUserIsLoggedInANewWindow(string userType)
        {           
           new LoginPage(driverContext).OpenNewWindow(); 
            
        }
        
        [Then(@"'(.*)' user is logged out from first window")]
        public void ThenUserIsLoggedOutFromFirstWindow(string userType)
        {
            new LoginPage(driverContext).SwitchToFirstWindow();            
        }      
        
    }
}

