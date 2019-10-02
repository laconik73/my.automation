using NLog;
using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using static NSelene.Selene;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NowPow.Automation.Features.StepDefinitions;
using System;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class ScreeningErxPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement editFiltersButton = S("#btn-toFilters");
        SeleneElement languageFilter = S("button[data-id='languages']");
        SeleneElement hoursFilter = S("button[data-id='hours']");
        SeleneElement addServiceButton = S("#btn-add-service");
        SeleneElement addFavoritesButton = S("#add-favorites");
        SeleneElement saveErxScreening = S("#save-screening");
        public ScreeningErxPage(DriverContext driverContext) : base(driverContext)
        {
            
        }

        internal ScreeningErxPage EditFilters()
        {
            WaitForNot(spinner, Be.InDom);
            editFiltersButton.Click();
            return new ScreeningErxPage(DriverContext);
        }

        internal ScreeningErxPage SelectLanguage()
        {

            languageFilter.Click();
            S(By.XPath("//span[contains(text(),'Spanish')]")).Click();
            return this;
        }

        internal ScreeningErxPage SelectHours()
        {
            hoursFilter.Click();
            S(By.XPath("//span[contains(text(),'Open Weekends (Saturday, Sunday)')]")).Click();
            return this;
        }

        internal ScreeningErxPage Apply()
        {
            S("#btn-next").Hover().Click();
            return new ScreeningErxPage(DriverContext);
        }

        internal ScreeningErxPage AddServiceProvider()
        {
            addServiceButton.Click();
            return new ScreeningErxPage(DriverContext);
        }

        internal ScreeningErxPage AddFavorites()
        {
            addFavoritesButton.Click();
            return new ScreeningErxPage(DriverContext);
        }
        internal ScreeningErxPage SelectFirstFavorite()
        {
            WaitForNot(smallSpinner, Be.Visible);
            S(".col-xs-1").Click();
            return new ScreeningErxPage(DriverContext);
        }
        internal ScreeningErxPage Update()
        {
            S("#btn-add").Click();
            return new ScreeningErxPage(DriverContext);
        }

        internal ScreeningErxPage SaveErx()
        {
            WaitForNot(S(".modal-backdrop.fade"), Be.InDom);
            saveErxScreening.Click();
            return new ScreeningErxPage(DriverContext);
        }

        
    }
}