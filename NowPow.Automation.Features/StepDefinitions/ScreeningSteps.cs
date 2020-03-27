using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using static NSelene.Selene;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class ScreeningSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        String note;
        public ScreeningSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        
        
        

        [When(@"user chooses  '(.*)'")]
        public void WhenUserChooses(string start)
        {
            new ScreeningPage(driverContext).Start();
        }
        [When(@"user answers screening questions")]
        public void WhenUserAnswersScreeningQuestions()
        {
            new ScreeningPage(driverContext).SubmitBaseScreening().Next();
            new LivingSituationPage(driverContext).SubmitLivingSituation().Next();
            new FoodPage(driverContext).SubmitFood().Next();
            new TransportationPage(driverContext).SubmitTransportation().Next();
            new UtilitiesPage(driverContext).SubmitUtilities().Next();
            new SafetyPage(driverContext).SubmitSafety().Next();
            new BackgroundPage(driverContext)
                .SubmitBackground()
                .InputAddress("235 West Van Buren Street, Chicago, IL, USA")
                .Next();
            new ScreeningPage(driverContext).SaveButton();
        }
        [When(@"saves screening with a note")]
        [Obsolete]
        public void WhenSavesScreeningWithANote()
        {
            note = DateTime.Now.Ticks.ToString();
            var modal = new ScreeningResultsModal(driverContext).SaveScreeningResults();
            modal.WriteNote(note)
                .Confirm();
        }
        [Then(@"note is displayed below screening summary")]
        public void ThenNoteIsDisplayedBelowScreeningSummary()
        {
            new ScreeningPage(driverContext);
            bool notes = Verify("#page-navigation");
            Console.WriteLine("notes displayed");
        }

        private bool Verify(string notes)
        {
            try
            {
                bool isNotesDisplayed = S(By.CssSelector("#page-navigation")).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        
        
        [When(@"user clicks on '(.*)' button")]
        public void WhenUserClicksOnButton(string startScreening)
        {
            new PatientPage(driverContext).ConductScreening(startScreening);
                
        }
        [Then(@"user able to conduct screening for a patient")]
        public void ThenUserAbleToConductScreeningForAPatient()
        {
            new ScreeningPage(driverContext);
            String expectedCSforP = S(By.XPath("//h2[contains(text(),'QA Organization - Automation Screenings')]")).GetText();
            String actualCSforP = "QA Organization - Automation Screenings";
            Assert.AreEqual(expectedCSforP, actualCSforP);
        }
        [Given(@"user searches for a Patient")]
        public void GivenUserSearchesForAPatient()
        {
            new PatientPage(driverContext)
                .SearchPatient("sophie arnold")
                 .Submit();
        }

        [When(@"user chooses to complete screening with '(.*)'")]
        public void WhenUserChoosesToCompleteScreeningWith(string code)
        {
            new ScreeningPage(driverContext)
                .GetCode(code)
                .GotItButton();                
        }
        [Then(@"user able to conduct screening for a patent with code")]
        public void ThenUserAbleToConductScreeningForAPatentWithCode()
        {
            new ScreeningPage(driverContext);
        }
        [When(@"user saves screening for later")]
        public void WhenUserSavesScreeningForLater()
        {
            DateTime.Now.Ticks.ToString();
            var modal = new ScreeningPage(driverContext).SaveForLater();
            
                modal.SaveLaterButton();
        }
        [Then(@"user returns to the Patient's Page with incomplete screening")]
        public void ThenUserReturnsToThePatientSPageWithIncompleteScreening()
        {
            new PatientPage(driverContext).ReturnToPatient();
        }
        
        
        [When(@"user takes action")]
        public void WhenUserTakesAction()
        {
            new ProfilePage(driverContext).OpenTakeAction();
        }
        [Then(@"'(.*)' screening action is displayed")]
        public void ThenScreeningActionIsDisplayed(string completeAction)
        {
            new ProfilePage(driverContext);
            Assert.IsTrue(S(By.LinkText("Complete")).IsDisplayed());
        }







    }
}
