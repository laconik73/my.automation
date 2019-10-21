using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NowPow.Automation.Features.StepDefinitions;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using static NSelene.Selene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class ServicePage : ProjectPageBase
    { 
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement favoriteService = S(".favorite.col-xs-12.col-md-12.col-lg-4");
        SeleneElement referButton = S("#btn-refer");
        SeleneElement servicesSearch = S("#services-search-query");
        SeleneElement searchButton = S("#btn-search");
        SeleneElement serviceTitle = S("a[href*='services'][data-name*='Moore']");

        public ServicePage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        //Choosing favorite service 
        internal ServicePage OpenFavoriteService()
        {
            WaitForNot(S(".overlay"), Be.Visible);            
            WaitFor(favoriteService, Be.Visible);
            WaitForNot(smallSpinner, Be.InDom);
            favoriteService.Click();
            return new ServicePage(DriverContext);
        }
        //Referring favorite service
        internal MakeReferralModal Refer()
        {
            WaitFor(referButton, Be.Visible);
            referButton.Click();
            Assert.AreNotEqual(MakeReferralModal.Displayed, " make referral modal not displayed");
            return new MakeReferralModal(DriverContext);
        }

        internal ServicePage SearchServices(string coordinatedOrgName)
        {
            servicesSearch.Hover().SendKeys(coordinatedOrgName);
            return this;
        }

        internal ServicePage Submit()
        {
            searchButton.Click();
            return new ServicePage(DriverContext);
        }

        internal ServicePage ClickServiceLink()
        {
            serviceTitle.Click();
            //switching to popup window 
            string newWindowHandle = Driver.WindowHandles.Last();
            var newWindow = Driver.SwitchTo().Window(newWindowHandle);

            // verify popup window title
            string expectedNewWindowTitle = "Moore Park Health - North | NowPow";
            Assert.AreEqual(expectedNewWindowTitle, newWindow.Title);
            return new ServicePage(DriverContext);
        }
    }      
}