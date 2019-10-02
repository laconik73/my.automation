using System;
using NLog;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using static NSelene.Selene;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class SLSOrganizationPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement surveyManagementTab = S(By.XPath("//a[contains(text(),'Survey Management')]"));
        SeleneElement inputTextbox = S("#datatable-search");
        SeleneElement organizationName = S(By.XPath("//td[contains(text(),'Health Corner - AHC')]"));
        
        
        
       

        public SLSOrganizationPage(DriverContext driverContext) : base(driverContext)
        {

        }

        internal SLSOrganizationPage OpenSurveyManagement(string tabName)
        {
            surveyManagementTab.Click();
            return new SLSOrganizationPage(DriverContext);
        }

        internal SLSOrganizationPage SearchByOrganization(string organization)
        {
            inputTextbox.SendKeys(organization);
            return new SLSOrganizationPage(DriverContext);
        }        

        internal SLSOrganizationPage SelectOrganization()
        {
            //switch to new window
            organizationName.Click();

            //verify how many browsers are open                      
            Assert.AreEqual(2, Driver.WindowHandles.Count);

            //switching to popup window 
            string newWindowHandle = Driver.WindowHandles.Last();
            var newWindow = Driver.SwitchTo().Window(newWindowHandle);

            // verify popup window title
            string expectedNewWindowTitle = "Survey | NowPow Inventory";
            Assert.AreEqual(expectedNewWindowTitle, newWindow.Title);

            return new SLSOrganizationPage(DriverContext);
        }    
                 
    }
}