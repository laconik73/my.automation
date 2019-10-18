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


namespace NowPow.Automation.Features.StepDefinitions
{
    internal class DashboardPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement patientCard = S(".patient");
        SeleneElement addNeedButton = S("#btn-addNeed");
        SeleneElement takeActionButton = S("#btn-takeAction");
        SeleneElement addInteraction = S(By.XPath("//a[contains(text(),'Add Interaction')]"));
        SeleneElement patientTab;
        SeleneElement referralsReceivedTab;
        SeleneElement referralsSentTab;
        SeleneElement screeningsTab;     
        SeleneElement erxTab;      
        SeleneElement servicesTab;
        SeleneElement adminTab;
        SeleneElement hamburgerIcon = S("#hamburger-icon");
        SeleneElement expandedNav = S(".inset-nav");
        SeleneElement notificationIcon = S("#nav-item-notifications");
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
        internal DashboardPage ChoosePatientCard()
        {
            WaitForNot(spinner, Be.InDom);
            patientCard.Click();
            return this;
        }

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
            WaitForNot(S("#patientInteractionModal-container"), Be.InDom);
            WaitFor(S("#drawer-809"), Be.Visible).Click();
            return new DashboardPage(DriverContext);
        }

        //Verify Patient tab
        internal PatientPage OpenPatient(string tabName)
        {
            patientTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-patients") : S(".inset-nav #nav-item-patients");
            ClickNavigationLink(patientTab);
            WaitFor(S("#count-top"), Be.Visible);
            return new PatientPage(DriverContext);
        }

        //Verify Referrals tab
        internal ReferralsSentPage OpenReferrals(string tabName)
        {
            referralsSentTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-referrals-sent") : S(".inset-nav #nav-item-referrals-sent");
            ClickNavigationLink(referralsSentTab);
            WaitFor(S("#main-header>div>h2"), Be.Visible);
            return new ReferralsSentPage(DriverContext);
        }

        //Verify Screening Tab
        internal ScreeningPage OpenScreenings(string tabName)
        {
            screeningsTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-screenings") : S(".inset-nav #nav-item-screenings");
            ClickNavigationLink(screeningsTab);
            WaitFor(S(".col-xs-12.row.card-white > div:nth-child(1)"), Be.Visible);
            return new ScreeningPage(DriverContext);
        }

        //Verify eRx tab
        internal ErxPage OpenErx(string tabName)
        {
            erxTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-erx") : S(".inset-nav #nav-item-erx");
            ClickNavigationLink(erxTab);
            return new ErxPage(DriverContext);
        }

        //Verify Services tab
        internal ServicePage OpenServices(string tabName)
        {
            servicesTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-services") : S(".inset-nav #nav-item-services");
            ClickNavigationLink(servicesTab);
            return new ServicePage(DriverContext);
        }

        internal void ClickNavigationLink(SeleneElement navElement)
        {
            if (MenuIsCollapsed)
            {
                WaitFor(hamburgerIcon, Be.Visible);
                hamburgerIcon.Click();
            }

            WaitFor(navElement, Be.Visible);
            navElement.Click();
        }
    }
}




