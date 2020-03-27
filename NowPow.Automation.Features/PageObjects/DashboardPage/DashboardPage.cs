using System.Threading;
using NLog;
using NSelene;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using static NSelene.Selene;
using Ocaramba;
using System;
using Nowpow.Automation.Features.PageObjects;
using Nowpow.Automation.Features.StepDefinitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NowPow.Automation.Features.StepDefinitions
{
    internal class DashboardPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        
        SeleneElement addNeedButton = S("#btn-addNeed");
        SeleneElement takeActionButton = S("#btn-takeAction");
        SeleneElement addInteraction = S(By.XPath("//a[contains(text(),'Add Interaction')]"));
                
        SeleneElement referralsTab = S("#referralsMenu");
        SeleneElement screeningsTab = S("[data-link*='screenings'][type]");     
        SeleneElement erxTab = S("[data-link*='eRX'][type]");       
        SeleneElement servicesTab = S("[data-link*='services'][type]");
        SeleneElement analyticsTab = S("a[id='analyticsTabBtn'][type]");
        SeleneElement hamburgerIcon = S("#hamburger-icon");
        SeleneElement expandedNav = S(".inset-nav");
        SeleneElement notificationIcon = S("#nav-item-notifications");
        SeleneElement bellIcon = S("a[id='nav-item-notifications'][type]");
        SeleneElement referralsMenu = S("#referralsDropdown");
        SeleneElement referralsSent = S("#nav-item-referrals-sent.profile-link");
        private bool? _menuIsCollapsed = null;

        bool MenuIsCollapsed
        {
            get
            {
                if (!_menuIsCollapsed.HasValue)
                    _menuIsCollapsed = expandedNav.Size.Width < 75;

                return _menuIsCollapsed.Value;
            }
        }

        public DashboardPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        //To click on first patient card from LandingPage/DashboardPage
        

        //Open subtab "Needs" from patient details
        internal DashboardPage OpenNeeds(string subtabName)
        {
            S(By.Id(subtabName.ToLower())).Click();
            return this;
        }

        //To add needs modal
        internal AddNeedModal AddNeed()
        {
            WaitForNot(smallSpinner, Be.InDom);
            WaitFor(addNeedButton, Be.Visible).Click();
            return new AddNeedModal(DriverContext);
        }

        //To open "Take Action" dropdown menu
        internal DashboardPage TakeAction()
        {
            takeActionButton.Click();
            return this;
        }       

        internal AddInteractionModal AddInteraction()
        {
            addInteraction.Click();
            return new AddInteractionModal(DriverContext);
        }

        internal DashboardPage OpenDrawer()
        {
            WaitForNot(S(".modal-backdrop.fade"), Be.InDom);
            WaitFor(S("#drawer-809"), Be.Visible).Click();
            return new DashboardPage(DriverContext);
        }

        //Verify Patient tab
        

        //Verify Referrals tab
        internal ReferralsSentPage OpenReferrals(string tabName)
        {
            //referralsTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-referrals-sent") : S(".inset-nav #nav-item-referrals-sent");
            //ClickNavigationLink(referralsTab);
            //WaitFor(S("#main-header>div>h2"), Be.Visible);
            referralsTab.Click();
            return new ReferralsSentPage(DriverContext);
        }

        //Verify Screening Tab
        internal ScreeningPage OpenScreenings(string tabName)
        {
            //screeningsTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-screenings") : S(".inset-nav #nav-item-screenings");
            //ClickNavigationLink(screeningsTab);
            //WaitFor(S(".col-xs-12.row.card-white > div:nth-child(1)"), Be.Visible);
            screeningsTab.Click();
            return new ScreeningPage(DriverContext);
        }

        //Verify eRx tab
        internal ErxPage OpenErx(string tabName)
        {
            //erxTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-erx") : S(".inset-nav #nav-item-erx");
            //ClickNavigationLink(erxTab);
            erxTab.Click();
            return new ErxPage(DriverContext);
        }

        //Verify Services tab
        internal ServicePage OpenServices(string tabName)
        {
            //servicesTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-services") : S(".inset-nav #nav-item-services");
            //ClickNavigationLink(servicesTab);
            servicesTab.Click();
             return new ServicePage(DriverContext);
        }

        //internal void ClickNavigationLink(SeleneElement navElement)
        //{
        //    if (MenuIsCollapsed)
        //    {
        //        WaitFor(hamburgerIcon, Be.Visible);
        //        hamburgerIcon.Click();
        //    }

        //    WaitFor(navElement, Be.Visible);
        //    navElement.Click();
        //}
        internal AnalyticsPage OpenAnalytics(string tabName)
        {
            analyticsTab.Click();            
            return new AnalyticsPage(DriverContext);
        }

        internal NotificationsPage OpenNotifications()
        {           
            bellIcon.Click();
            String tableHeader = S("#table-header").GetText();
            Console.WriteLine(tableHeader);
            return new NotificationsPage(DriverContext);
        }

        internal ReferralsSentPage OpenReferralsSent()
        {            
            referralsMenu.Click();
            referralsSent.Click();
            return new ReferralsSentPage(DriverContext);
        }

        internal ReferralsReceivedPage OpenReceivedReferrals()
        {
            S("a[id='nav-item-referrals-received']").Click();
            return new ReferralsReceivedPage(DriverContext);
        }
    }
}




