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
    public class ReferralFormConfiguration : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement addNewFieldButton = S(".add-additional-button");
        IList<IWebElement> requiredFields = SS(By.XPath("//tr//td[4]"));



        public ReferralFormConfiguration(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal AdditionalFieldModal AddNewField()
        {
            addNewFieldButton.Hover().Click();
            return new AdditionalFieldModal(DriverContext);
        }

        internal ReferralFormConfiguration VerifyTable()
        {
            
            IList<string> fields = new List<string>();
            foreach (IWebElement element in requiredFields)
            {
                fields.Add(element.ToString());
                Console.WriteLine(element.Text);
            }
            return this;
        }
    }
}