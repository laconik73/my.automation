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

namespace NowPow.Automation.Features.StepDefinitions

{
    public class AdminPage : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement configurationsSubtab = S("#configurations");
        SeleneElement referralFormSidePanel = S("#referralFormSubTab");
        SeleneElement userManagementTab = S("#user-management-tab");


        public AdminPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal AdminPage OpenConfigurations(string subPanel)
        {
            configurationsSubtab.Hover().Click();
            return this;
        }

        internal ReferralFormConfiguration OpenReferralForm()
        {
            referralFormSidePanel.Hover().Click();
            return new ReferralFormConfiguration(DriverContext);
        }

        internal UserManagement OpenUserManagement(string subPanel)
        {
            userManagementTab.Hover().Click();
            return new UserManagement(DriverContext);
        }
    }
}
