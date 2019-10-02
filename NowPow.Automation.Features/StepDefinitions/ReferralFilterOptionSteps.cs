using System;
using Ocaramba;
using TechTalk.SpecFlow;

namespace Nowpow.Automation.Features.StepDefinitions
{

    [Binding]
    public class ReferralFilterOptionSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        


        public ReferralFilterOptionSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;               
                          
        }
        [When(@"user chooses '(.*)' from '(.*)' dropdown menu")]
        public void WhenUserChoosesFromDropdownMenu(string dropdownTitle, string filterOption)
        {
            new PatientPage(driverContext).FilterOption(filterOption, dropdownTitle);
        }
               
        [Then(@"dropdown menu displays options")]
        public void ThenDropdownMenuDisplaysOptions()
        {
             new PatientPage(driverContext);
        }
        [When(@"user chooses '(.*)'Status Filter' dropdown menu")]
        public void WhenUserChoosesStatusFilterDropdownMenu(string statusOption, string dropdownTitle)
        {
            new PatientPage(driverContext).StatusOption(statusOption, dropdownTitle);
        }
       


    }
}
