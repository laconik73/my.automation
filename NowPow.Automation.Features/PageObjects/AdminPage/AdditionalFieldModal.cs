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
using System.Collections;
using System.Collections.Generic;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class AdditionalFieldModal : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement inputText = S("input.form-control");
        IList<IWebElement> checkboxes = SS(".custom-checkbox");
        IList<IWebElement> buttons = SS(".modal-footer button");

        public AdditionalFieldModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal AdditionalFieldModal InputFieldTitle(string text)
        {
            inputText.SendKeys(text);
            return this;
        }       

        internal AdditionalFieldModal MarkRequired()
        {
            checkboxes.ElementAt(9).Click();
            return this;
        }
        internal AdditionalFieldModal SelectService()
        {
            checkboxes.ElementAt(11).Click();
            return this;
        }
        internal ReferralFormConfiguration AddField()
        {
            buttons.ElementAt(1).Click();
            return new ReferralFormConfiguration(DriverContext);
        }
    }
}

