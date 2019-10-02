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
        SeleneElement patientTab = S("[data-link='private/patients'][type]");
        SeleneElement referralsTab = S("[data-link='private/referrals/sent'][type]");        
        SeleneElement screeningsTab = S("[data-link='private/screenings'][type]");     
        SeleneElement erxTab = S("[data-link='private/eRX'][type]");      
        SeleneElement servicesTab = S("[data-link='private/services'][type]");  
        SeleneElement adminTab = S("[data-link='private/admin/dataanalytics'][type]");     
      

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
            
            patientTab.Click();
            WaitFor(S("#count-top"), Be.Visible);
            return new PatientPage(DriverContext);
        }
        //Verify Referrals tab
        internal ReferralsSentPage OpenReferrals(string tabName)
        {
            referralsTab.Click();
            WaitFor(S("#main-header>div>h2"), Be.Visible);
            return new ReferralsSentPage(DriverContext);
        }
        //Verify Screening Tab
        internal ScreeningPage OpenScreenings(string tabName)
        {
            screeningsTab.Click();
            WaitFor(S(".col-xs-12.row.card-white > div:nth-child(1)"), Be.Visible);
            return new ScreeningPage(DriverContext);
        }
        //Verify eRx tab
        internal ErxPage OpenErx(string tabName)
        {
            erxTab.Click();
            return new ErxPage(DriverContext);
        }
        //Verify Services tab
        internal ServicePage OpenServices(string tabName)
        {
            WaitFor(servicesTab, Be.Visible);
            servicesTab.Click();
            return new ServicePage(DriverContext);
        }     
          
        

    }
}




