using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nowpow.Automation.Features.StepDefinitions;
using Nowpow.Automation.Features.PageObjects;
using NLog;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using OpenQA.Selenium.Support.UI;
using static NSelene.Selene;
using OpenQA.Selenium;
using System.Threading;
using System.Collections.Generic;

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
        SeleneElement showFilters = S("#btn-show-filter");
        SeleneElement feeStructure = S("div.btn-group:nth-child(2)");
        SeleneElement applyFiltersButton = S("#filtersForResults");
        SeleneElement distanceLink = S("#distance-link");
        SeleneElement radiusDropdown = S(By.XPath("//span[@class='filter-option pull-left'][contains(text(),'10 miles')]"));
        SeleneElement inputZipCode = S(By.XPath("//input[@placeholder='Enter your address']"));
        SeleneElement updateResultsButton = S("#address-lookup-submit");
        SeleneElement sortDropdown = S("div.btn-group:nth-child(3)");
       

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

        internal ServicePage InputServiceType(string serviceType)
        {
            servicesSearch.Hover().SendKeys(serviceType);
            return this;
        }       

        internal ServicePage OpenFilters()
        {
            showFilters.Click();
            return this;
        }       

        internal ServicePage SelectFeeStructure()
        {
            feeStructure.Click();
            S(By.XPath("//span[@class='text'][contains(text(),'Self Pay')]")).Hover().Click();
            return this;
        }      

       
        internal ServicePage ApplyFilters()
        {
            applyFiltersButton.Click();
            return this;
        }
        internal ServicePage ChangeRadius()
        {
            WaitForNot(spinner, Be.InDom);
            distanceLink.Click();
            return this;
        }
        
        internal ServicePage SelectRadius()
        {
            radiusDropdown.Click();
            S(By.XPath("//span[contains(text(),'25 miles')]")).Click();
            return this;
        }        

        internal ServicePage ChangeZipCode(string zipCode)
        {
            inputZipCode.Hover().Clear().SendKeys(zipCode);
            return this;
        }
        internal ServicePage UpdateResults()
        {
            updateResultsButton.Click();
            return this;
        }
        internal ServicePage SortOptions(string relevance)
        {
            WaitForNot(spinner, Be.InDom);
            sortDropdown.Click();
            S(By.XPath("//span[contains(text(),'Distance')]")).Click();

            WaitForNot(spinner, Be.InDom);
            sortDropdown.Click();
            S(By.XPath("//span[contains(text(),'Name')]")).Click();

            WaitForNot(spinner, Be.InDom);
           sortDropdown.Click();
            S(By.XPath("//span[contains(text(),'Preferred')]")).Click();

            WaitForNot(spinner, Be.InDom);
            sortDropdown.Click();
            S(By.XPath("//span[contains(text(),'Recently Added')]")).Click();

            WaitForNot(spinner, Be.InDom);
            sortDropdown.Click();
            S(By.XPath("//span[contains(text(),'Ratings')]")).Click();

            WaitForNot(spinner, Be.InDom);
            sortDropdown.Click();
            S(By.XPath("//span[contains(text(),'Tracked Referrals')]")).Click();            

            return this;
        }
        internal ServicePage FavoriteTheService()
        {
            S("#services-container div:nth-child(1) button").Click();
            S("#services-container div:nth-child(2) button").Click();
            return this;
        }
        internal ServicePage OpenServices()
        {
            S("a[data-link*='services'][type]").Click();
            return new ServicePage(DriverContext);
        }

        internal ServicePage UnfavoriteTheService()
        {
            WaitForNot(smallSpinner, Be.InDom);
            S("div[class*='btn-favorite']").Click();
            return new ServicePage(DriverContext);
        }

        internal ServicePage SelectFavorite(string service)
        {
            IList<IWebElement> favorites = SS("div.favorite");
            WaitForNot(smallSpinner, Be.InDom);
            favorites.ElementAt(2).Click();
            return new ServicePage(DriverContext);
        }
    }
}