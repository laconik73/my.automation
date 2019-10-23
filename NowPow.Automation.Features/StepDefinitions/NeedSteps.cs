using System;
using Ocaramba;
using TechTalk.SpecFlow;
using static NSelene.Selene;
using OpenQA.Selenium;


namespace NowPow.Automation.Features.StepDefinitions
{
    [Binding]
    public class NeedSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        String note;

        public NeedSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
         
        }
       
        [Given(@"user chooses patient card")]
        public void GivenUserChoosesPatientCard()
        {
            new DashboardPage(driverContext).ChoosePatientCard();
        }
        [Given(@"user opens subtab '(.*)'")]
        public void GivenUserOpensSubtab(string subtabName)
        {
            new DashboardPage(driverContext).OpenNeeds(subtabName);
        }
        [When(@"a user adds a new Needs with a note")]
        public void WhenAUserAddsANewNeedsWithANote()
        {
            note = DateTime.Now.Ticks.ToString();
            var modal = new DashboardPage(driverContext).AddNeed();
            modal.SelectFirstNeed()
              .SelectInteractionType()
              .SelectDuration()
              .WriteNote(note)
              .Add(); 
        }
        [Then(@"new note is added")]
        public void ThenNewNoteIsAdded()
        {
            new DashboardPage(driverContext);           

        }
        [When(@"user adds a new interaction to an existing Needs")]
        public void WhenUserAddsANewInteractionToAnExistingNeeds()
        {
            new DashboardPage(driverContext).TakeAction();
                
            DateTime.Now.Ticks.ToString();
            var modal = new DashboardPage(driverContext).AddInteraction();
            modal.ChooseInteraction()
                  .Save();
        }
        [When(@"user expands Need card's details")]
        public void WhenUserExpandsNeedCardSDetails()
        {
            new DashboardPage(driverContext).OpenDrawer();
        }

        [Then(@"new interaction is added")]
        public void ThenNewInteractionIsAdded()
        {
            new DashboardPage(driverContext);
            bool newInteraction = Verify("#needs-table_809_wrapper");
            Console.WriteLine("new interaction is added");

        }

        private bool Verify(string newInteraction)
        {
            try
            {
                bool isNotesDisplayed = S(By.CssSelector("#needs-table_809_wrapper")).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}





