using System;
using NLog;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
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

        internal SearchForServicesModal OpenSearchForServices()
        {
            return this;
        }
        internal SearchForServicesModal InputQuery(string query)
        {
            WaitForNot(S("#spinnerSmall"), Be.InDom);
            inputService.Hover().SendKeys(query);
            return this;
        }
        internal SearchForServicesModal Search()
        {
            searchButton.Click();
            return this;
        }
        internal SearchForServicesModal SelectFirstResult()
        {
            WaitForNot(S("#spinnerSmall"), Be.InDom);
            WaitFor(S(".provider-container"), Be.Visible);
            S(By.CssSelector("div.col-xs-1")).Click();
            return this;
        }
        internal ScreeningPage Update()
        {
            updateButton.Click();
            return new ScreeningPage(DriverContext); 
        }

        
    }
}