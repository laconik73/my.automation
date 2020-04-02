using System;
using System.Globalization;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using Ocaramba.Extensions;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;
using Nowpow.Automation.Features.StepDefinitions;
using System.Collections.Generic;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class AddUserModal : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        IList<IWebElement> inputFields = SS(".form-control.invalid");
        SeleneElement usernameCheckbox = S(".custom-control.custom-checkbox");
        SeleneElement blueLink = S(".btn.existing-user-btn.btn-link");

        public AddUserModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal AddUserModal InputEmail(string email)
        {
            inputFields.ElementAt(4).SendKeys(email);

            //click anywhere inside the modal 
            inputFields.ElementAt(0).Click();
            return this;
        }
        
        internal AddUserModal CheckUsername()
        {
            usernameCheckbox.Hover().Click();
            return this;
        }

        internal AddUserModal InputUsername(string username)
        {
            //not a duplicate code. Must use data provider 'username' 
            inputFields.ElementAt(4).SendKeys(username);
            //click anywhere inside the modal 
            inputFields.ElementAt(0).Click();

            return this;
        }

        internal AddUserModal VerifyExistingUser()
        {
            Assert.IsTrue(S(".existing-user-text").Displayed);
            Assert.IsTrue(blueLink.Displayed);
            return this;
        }       
        
    }
}

