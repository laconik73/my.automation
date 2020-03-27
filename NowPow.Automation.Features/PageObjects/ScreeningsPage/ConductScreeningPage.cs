using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static NSelene.Selene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    public class ConductScreeningPage : ProjectPageBase
    {

        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        IList<IWebElement> startButton = SS(".btn.btn-primary");
        IList<IWebElement> radioButton = SS("input[type='radio']");
        SeleneElement nextButton = S("#next.btn");
        SeleneElement backLink = S("#back-patient-link");



        public ConductScreeningPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
        internal ConductScreeningPage StartButton()
        {
            startButton.ElementAt(0).Click();
            return new ConductScreeningPage(DriverContext);
        }       

        internal ConductScreeningPage SelectFirstSection()
        {            
            int iSize = radioButton.Count;
            for (int i = 0; i < iSize; i++)
            {
                String Value = radioButton.ElementAt(i).GetAttribute("value");
                if (Value.Equals("Mordor"))
                {
                    WaitForNot(S(".answer"), Be.Selected);
                    radioButton.ElementAt(i).Click();
                    break;
                }
            }
            return new ConductScreeningPage(DriverContext);
        }        

        internal ConductScreeningPage Next()
        {
            nextButton.Hover().Click();
            Thread.Sleep(1000);
            return new ConductScreeningPage(DriverContext);
        }
        internal ConductScreeningPage RefreshPage()
        {
            this.Driver.Navigate().Refresh();
            Thread.Sleep(5000);
            Assert.IsTrue(S("span.card-label i").Displayed);
            return new ConductScreeningPage(DriverContext);
        }
        internal PatientScreeningPage BackToPatientScreening()
        {
            backLink.Click();
            return new PatientScreeningPage(DriverContext);
        }


    }
}
