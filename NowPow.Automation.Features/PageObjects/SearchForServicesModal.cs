using System;
using System.Threading;
using NLog;
using Nowpow.Automation.Features.StepDefinitions;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using OpenQA.Selenium;
using static NSelene.Selene;

namespace NowPow.Automation.Features.StepDefinitions
{
    internal class SearchForServicesModal : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        SeleneElement inputService = S("#services-search-query");
        SeleneElement searchButton = S("#btn-search");
        SeleneElement updateButton = S("#btn-add");


        public SearchForServicesModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
        
        internal SearchForServicesModal InputQuery(string query)
        {
            WaitForNot(S("#spinnerSmall"), Be.InDom);
            inputService.Hover().SendKeys(query);
            return this;
        }
        internal SearchForServicesModal ClickSearch()
        {
            searchButton.Click();
            return this;
        }

        internal SearchForServicesModal SelectFirstService()
        {
            
            S("div.provider.row:nth-child(1) div.col-xs-1").Hover().Click();          
            return this;
        }

        internal ScreeningErxPage Update()
        {
            updateButton.Click();
            Thread.Sleep(1000);
            return new ScreeningErxPage(DriverContext); 
        }

       
    }
}