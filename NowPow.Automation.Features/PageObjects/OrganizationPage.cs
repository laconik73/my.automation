using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using static NSelene.Selene;
using OpenQA.Selenium;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class OrganizationPage:ProjectPageBase
    {  
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        SeleneElement februarySubpanel = S("div[data-monthname='February'][data-year='2017']");
               
        

        public OrganizationPage(DriverContext driverContext): base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        //Verify side panel year and month button
        internal OrganizationPage OpenYearAndMonth(string february)
        {
            if( february == "February2017")
            {
                februarySubpanel.Click();
            }
            
            else
            {
                Console.WriteLine("wrong month");
            }
            return new OrganizationPage(DriverContext);
        }
        

    }


    
}