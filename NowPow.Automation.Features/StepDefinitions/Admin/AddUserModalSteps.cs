using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSelene;
using System.Collections.Generic;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class AddUserModalSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;


        public AddUserModalSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user is on '(.*)' modal")]
        public void GivenUserIsOnModal(string button)
        {
            new UserManagement(driverContext).AddUsers(button);
        }
        [When(@"user adds email '(.*)'")]
        public void WhenUserAddsEmail(string email)
        {
            new AddUserModal(driverContext).InputEmail(email);
        }
        [When(@"user adds username '(.*)'")]
        public void WhenUserAddsUsername(string username)
        {
            new AddUserModal(driverContext)
                .CheckUsername()
                .InputUsername(username);
        }
        [Then(@"user should see error message")]
        public void ThenUserShouldSeeErrorMessage()
        {
            new AddUserModal(driverContext).VerifyExistingUser();
        }






       














    }
}
