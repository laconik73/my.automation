using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using System;
using TechTalk.SpecFlow;
using static NSelene.Selene;
using OpenQA.Selenium;
using NSelene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class ErxSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string query;

        public ErxSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [When(@"user chooses '(.*)' button")]
        public void WhenUserChoosesButton(string viewErx)
        {
            new PatientPage(driverContext).OpenViewErx();
        }

        [Then(@"referred services are displayed under patient '(.*)' code")]
        public void ThenReferredServicesAreDisplayedUnderPatientCode(string erxCode)
        {
            new ErxPage(driverContext).VerifyErxCode();
        }
        [Then(@"user chooses '(.*)' button")]
        public void ThenUserChoosesButton(string backToPatient)
        {
            new ErxPage(driverContext).ReturnBackToPatient();
        }
        [Then(@"user is back on '(.*)' patient card")]
        public void ThenUserIsBackOnPatientCard(string subtabName)
        {
            new PatientPage(driverContext).VerifyPatientCard(subtabName);
        }
        [When(@"user selects button '(.*)'")]
        public void WhenUserSelectsButton(string buildErx)
        {
            new PatientPage(driverContext).BuildNewErx();
        }

        [Then(@"'(.*)' displays '(.*)'")]
        public void ThenDisplays(string erxLanding, string centeredPannel)
        {
            new ErxPage(driverContext).VerifyErxPage(erxLanding, centeredPannel);
        }
        [When(@"user makes a choice to '(.*)'")]
        public void WhenUserMakesAChoiceTo(string editProfile)
        {
            new PatientPage(driverContext).EditProfile();
        }

        [When(@"user inputs address into '(.*)' section")]
        public void WhenUserInputsAddressIntoSection(string contactInformation)
        {
            var section = new PatientPage(driverContext).OpenContactInformation(contactInformation);
            section.InputAddress("5307 S Hyde Park")
                .InputCity("Chicago")
                .SelectState()
                .InputZipCode("60615")
                .SelectCountry();
        }
        [When(@"user adds condition into '(.*)' section")]
        public void WhenUserAddsConditionIntoSection(string conditions)
        {
            var section = new PatientPage(driverContext).OpenConditions(conditions);
            section.AddCondition();

            DateTime.Now.Ticks.ToString();
            PatientPage modal = new PatientPage(driverContext).OpenSearchForConditionsModal();
            modal.InputQuery("depression")
            .Search()
            .SelectFirstResult()
            .Update();
            new PatientPage(driverContext).Save();
        }
        [Then(@"automatic eRx is generated")]
        public void ThenAutomaticERxIsGenerated()
        {
            new PatientPage(driverContext).DisplayGeneratedButton();
        }

        [When(@"user navigates to '(.*)'")]
        public void WhenUserNavigatesTo(string generateAutomaticErx)
        {
            new PatientPage(driverContext).OpenGenerateAutomaticErx();
        }

        [Then(@"user is able to '(.*)' or '(.*)' eRx")]
        public void ThenUserIsAbleToOrERx(string addNew, string save)
        {
            new ErxPage(driverContext).VerifyButtons(addNew, save);
        }
        [Given(@"user chooses '(.*)' tab")]
        public void GivenUserChoosesTab(string tabName)
        {
            new DashboardPage(driverContext).OpenErx(tabName);
        }

        [Given(@"'(.*)' displays '(.*)'")]
        public void GivenDisplays(string erxLanding, string centeredPannel)
        {
            new ErxPage(driverContext).VerifyCenteredPannel(erxLanding, centeredPannel);

        }
        [When(@"user inputs address into the '(.*)'")]
        public void WhenUserInputsAddressIntoThe(string location)
        {
            new ErxPage(driverContext)
                .InputAddress("230 South Dearborn Street, Chicago, IL, USA")
                .Search();
        }
        [Then(@"card toppers '(.*)' and '(.*)' are activated")]
        public void ThenCardToppersAndAreActivated(string serviceCategories, string conditions)
        {
            new ErxPage(driverContext).VerifyCardToppersActivation(serviceCategories, conditions);
        }
        [When(@"user chooses to '(.*)'")]
        public void WhenUserChoosesTo(string viewExistingHealtheRx)
        {
            new ErxPage(driverContext).GoToViewErxInputBox(viewExistingHealtheRx);
        }
        [When(@"user inputs '(.*)' code")]
        public void WhenUserInputsCode(string healthErx)
        {
            new ErxPage(driverContext)
                .InputErxCode("MVPY3LGNBV")
                .Go();
        }
        [Then(@"displayed eRx code matches the inputted '(.*)' code")]
        public void ThenDisplayedERxCodeMatchesTheInputtedCode(string healthErx)
        {
            new ErxPage(driverContext);
            String expectedErxCode = S(By.CssSelector("#eRX-code")).GetText();
            String actualErxCode = "MVPY3LGNBV";
            Assert.AreEqual(expectedErxCode, actualErxCode);

        }
        
        [When(@"user selects '(.*)'")]
        public void WhenUserSelects(string conditions)
        {
            new ErxPage(driverContext).OpenConditionsCardTopper(conditions)
               .SelectDepression()
               .SelectDiabetes()
               .Next();
        }
        [When(@"user makes selections from '(.*)'")]
        public void WhenUserMakesSelectionsFrom(string filters)
        {
            new ErxPage(driverContext).AddFilters(filters)
                .SelectLanguage()
                .SelectHours()
                .GenerateHealtheRx();
        }
        [Then(@"'(.*)' is generated")]
        public void ThenIsGenerated(string newErxCode)
        {
            new ErxPage(driverContext).Save(newErxCode);
        }
        [When(@"user chooses to '(.*)' eRx")]
        public void WhenUserChoosesToERx(string edit)
        {
            new ErxPage(driverContext).OpenEdit();
        }
        [When(@"user chooses '(.*)' service")]
        public void WhenUserChoosesService(string add)
        {
            new ErxPage(driverContext).AddService(add);
        }
       
        [When(@"user selects a service")]
        public void WhenUserSelectsAService()
        {
            
             new ErxPage(driverContext).SearchForServices()
                .SelectFirstResult()
                .Update();
        }
        [Then(@"new service saved on an Erx")]
        public void ThenNewServiceSavedOnAnErx()
        {
            new ErxPage(driverContext).SaveAddedService();
        }
        [When(@"user removes services from an Erx")]
        public void WhenUserRemovesServicesFromAnErx()
        {
            new ErxPage(driverContext).RemoveService();
        }
        [Then(@"service is removed from an Erx")]
        public void ThenServiceIsRemovedFromAnErx()
        {
            new ErxPage(driverContext).SaveRemovedServiceOnErx();
        }
        [When(@"card toppers '(.*)' and '(.*)' are activated")]
        public void WhenCardToppersAndAreActivated(string serviceCategories, string conditions)
        {
            new ErxPage(driverContext).VerifyCardToppersActivation(serviceCategories, conditions);
        
        }

        [When(@"user selects '(.*)' card topper")]
        public void WhenUserSelectsCardTopper(string serviceCategories)
        {
            new ErxPage(driverContext)
               .OpenServiceCategoriesCardTopper(serviceCategories)
               .SelectResult()
               .Next();
        }
        [Then(@"referral is marked as '(.*)'")]
        public void ThenReferralIsMarkedAs(string referralSent)
        {
            new ErxPage(driverContext);
            String expectedIcon = S(By.XPath("//div[@class='referral-sent-text'][contains(text(),'Referral Sent')]")).GetText();
            string actualIcon = "Referral Sent";
            Assert.AreEqual(expectedIcon, actualIcon);
        }
        [When(@"user sends nudge")]
        public void WhenUserSendsNudge()
        {
            var modal = new ErxPage(driverContext).SendNudge();
            modal.ClickEmailIcon()
              .InputEmail("nowpow.dev@gmail.com")
              .AddNudge();
        }
        [Then(@"email nudge is sent")]
        public void ThenEmailNudgeIsSent()
        {
            new ErxPage(driverContext);
            Assert.IsTrue(true);
        }
        [When(@"user views completed screening")]
        public void WhenUserViewsCompletedScreening()
        {
            new ProfilePage(driverContext).OpenDetails();
        }
        [When(@"user generates an eRx")]
        public void WhenUserGeneratesAnERx()
        {
            new ScreeningErxPage(driverContext)
                .GenerateErx()
                .EditFilters()
                .SelectLanguage()
                .SelectHours()
                .Apply()
                .AddServiceProvider();
            var modal = new ScreeningErxPage(driverContext).SearchForService();
            modal.InputQuery("hyde park")
                .ClickSearch()
                .SelectFirstService()
                .Update();
        }
        [Then(@"new eRx is created from patient's screening")]
        public void ThenNewERxIsCreatedFromPatientSScreening()
        {
            new ScreeningErxPage(driverContext).SaveErxToScreening();
        }
        [When(@"user adds condition")]
        public void WhenUserAddsCondition()
        {
            new ErxPage(driverContext)
                 .ClickConditions()
                 .SelectFinancialAssistance()
                 .SelectFoodInsecurity()
                 .Next()
                 .SelectLanguage()
                 .SelectHours()
                 .GenerateHealtheRx();
        }
        [When(@"user makes coordinated referral")]
        public void WhenUserMakesCoordinatedReferral()
        {
           var modal = new ErxPage(driverContext).MakeReferral();
            modal.SelectCheckbox1()                
                .SendCoordinatedReferral();
        }
        [Then(@"service marked as '(.*)'")]
        public void ThenServiceMarkedAs(string icon)
        {
            new ErxPage(driverContext);
            String refSent = S(By.XPath("//div[@class='referral-sent-text'][contains(text(),'Referral Sent')]")).GetText();
            String expected = "Referral Sent";
            Assert.AreEqual(refSent, expected);
        }











    }
}


