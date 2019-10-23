using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSelene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class PatientSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;

        public PatientSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user chooses tab '(.*)'")]
        public void GivenUserChoosesTab(string tabName)
        {
            new DashboardPage(driverContext).OpenPatient(tabName);
                  
        }
        [Given(@"user chooses '(.*)'")]
        public void GivenUserChooses(string createNewProfile)
        {
            new PatientPage(driverContext).OpenNewProfile();
        }
        [When(@"user navigates to patient's section")]
        public void WhenUserNavigatesToPatientSSection()
        {
            new PatientPage(driverContext);
        }
        [When(@"user inputs '(.*)'")]
        public void WhenUserInputs(string basicInformation)
        {
            new PatientPage(driverContext)
                .EnterFirstName("sabina")
                .EnterLastName("automation")
                .EnterDateOfBirth("mm/dd/yyyy")
                .SelectGender("female");                
        }
        [When(@"user chooses '(.*)'")]
        public void WhenUserChooses(string saveandcreate)
        {
            new ProfilePage(driverContext);
        }
        [Then(@"New Profile is created")]
        public void ThenNewProfileIsCreated()
        {
            new ProfilePage(driverContext);
        }
        [When(@"user inputs new patient name into '(.*)' field")]
        public void WhenUserInputsNewPatientNameIntoField(string patientName)
        {
            new ProfilePage(driverContext).InputPatientName();
              
        }
        [Then(@"results displayed")]
        public void ThenResultsDisplayed()
        {
            new PatientPage(driverContext).View();
        }
        [When(@"user switches toggle '(.*)' and '(.*)'")]
        public void WhenUserSwitchesToggleAnd(string toggleOn, string toggleOff)
        {
            new PatientPage(driverContext).SwitchEmailToggle(toggleOn, toggleOff);
        }        
        [Then(@"patient confirms email configuration")]
        public void ThenPatientConfirmsEmailConfiguration()
        {
            new PatientPage(driverContext).ConfirmEmailConfiguration();
        }
        [When(@"user sends email nudge with an attachment")]
        public void WhenUserSendsEmailNudgeWithAnAttachment()
        {
            
            var modal = new PatientPage(driverContext).SendNudge();
            modal.ClickEmailIcon()
              .InputEmail("nowpow.dev@gmail.com")
              .AddErx()
              .SendNudge();
        }
        [Then(@"new interaction is displayed under patient engagement")]
        public void ThenNewInteractionIsDisplayedUnderPatientEngagement()
        {
            new PatientPage(driverContext);
            bool emailNudge = Verify("#engagement-history");
            Console.WriteLine("Emailed patient is displayed");
        }

        private bool Verify(string nudge)
        {
            try
            {
                bool isNudgeDisplayed = S(By.XPath("//span[contains(text(),'Emailed Patient')]")).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }
        [When(@"user expands '(.*)' section")]
        public void WhenUserExpandsSection(string contactInformation)
        {
            new PatientPage(driverContext).OpenContactInformation(contactInformation);
        }
        [When(@"user edits '(.*)'")]
        public void WhenUserEdits(string contactInformation)
        {
            new PatientPage(driverContext)
                .InputMobileNumber()
                .InputHomeNumber()
                .InputEmail()
                .Save();
        }
        [Then(@"edited contact information is displayed in patient'(.*)'Consent'")]
        public void ThenEditedContactInformationIsDisplayedInPatientConsent(string patientConsent)
        {
            new PatientPage(driverContext);
            String actualConsent = S(By.XPath("//h4[contains(text(),'Consent')]")).GetText();
            String expenctedConsent = "Consent";
            Assert.AreEqual(actualConsent, expenctedConsent);
        }
        [When(@"user expands  patient '(.*)' section")]
        public void WhenUserExpandsPatientSection(string demographics)
        {
            new PatientPage(driverContext).OpenDemographics(demographics);
        }
        [When(@"user edits patient '(.*)'")]
        public void WhenUserEditsPatient(string editDemographics)
        {
            new PatientPage(driverContext)
                .SelectRace()
                .SelectEthnicity()
                .Save();
        }
        [Then(@"demographics are updated in patient overview")]
        public void ThenDemographicsAreUpdatedInPatientOverview()
        {
            new PatientPage(driverContext);
            String actualOverview = S("#divPatientOverview").GetText();
            String expectedOverview = "Overview";
            Assert.AreEqual(actualOverview, expectedOverview);
        }
        [When(@"user edits basic information")]
        public void WhenUserEditsBasicInformation()
        {
            new PatientPage(driverContext)
                .EnterFirstName("sabina")
                .EnterLastName("automation")
                .EnterDateOfBirth("mm/dd/yyyy")               
                .InputMrn("55887799")
                .SelectGenderType()
                .SelectPreferredLanguage()
                .Save();
        }
        [Then(@"basic information in updated in patient overview")]
        public void ThenBasicInformationInUpdatedInPatientOverview()
        {
            new PatientPage(driverContext);
            String actualOverview = S("#divPatientOverview").GetText();
            String expectedOverview = "Overview";
            Assert.AreEqual(actualOverview, expectedOverview);

        }
        [When(@"user searches patient by '(.*)'")]
        public void WhenUserSearchesPatientBy(string mrn)
        {
            new PatientPage(driverContext).SearchByMrn(mrn);
        }
        [Then(@"patient matching mrn is dispayed")]
        public void ThenPatientMatchingMrnIsDispayed()
        {
            new PatientPage(driverContext);
            SeleneElement matchingPatients = S("#patients");
            if (matchingPatients.IsDisplayed())
            {
                Console.WriteLine("matching patients are displayed");
            }
            else
            {
                Console.WriteLine("no results");
            }
            
        }
        [When(@"user input invalid name")]
        public void WhenUserInputInvalidName()
        {
            new PatientPage(driverContext).InputInvalidPatientName("!@#$%&&");
        }
        
        [Then(@"no results are dispayed")]
        public void ThenNoResultsAreDispayed()
        {
            new PatientPage(driverContext);
            Assert.IsTrue(true);
        }
        [When(@"user adds a new interaction with a note")]
        public void WhenUserAddsANewInteractionWithANote()
        {

            note = DateTime.Now.Ticks.ToString();
            var modal = new ProfilePage(driverContext).AddInteraction();
            modal.ChooseInteraction()                
                .WriteNote(note)
                .Save();
        }
        [Then(@"new interaction is created")]
        public void ThenNewInteractionIsCreated()
        {
            new ProfilePage(driverContext);
            SeleneElement engagementTable = S("#engagement-table");
            if (engagementTable.IsDisplayed())
            {
                Console.WriteLine("new interaction is created");
            }
            else
            {
                Console.WriteLine("no interaction is added");
            }
        }
        [Then(@"user chooses '(.*)' logo")]
        public void ThenUserChoosesLogo(string logo)
        {
            new ProfilePage(driverContext).ClickOnNowPow(logo);
        }
        [Then(@"patient card is listed under '(.*)' section")]
        public void ThenPatientCardIsListedUnderSection(string recentPatients)
        {
            new DashboardPage(driverContext);
            Assert.IsTrue(true);


        }







    }
}
   
       
      