using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSelene;
using System.Collections.Generic;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class AdditionalFieldSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;
        IList<IWebElement> additionalField = SS("tbody > tr");


        public AdditionalFieldSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [When(@"user adds new field")]
        public void WhenUserAddsNewField()
        {
            new ReferralFormConfiguration(driverContext)
                .AddNewField()
                .InputFieldTitle("automation")
                .MarkRequired()
                .SelectService()
                .AddField();
        }
        [Then(@"new additional field becomes required")]
        public void ThenNewAdditionalFieldBecomesRequired()
        {
            new ReferralFormConfiguration(driverContext);

            
            foreach (var row in additionalField)
            {
                if (row.Text.Contains("automation"))
                {
                    Console.WriteLine(row.Text);

                    var tds = row.FindElements(By.TagName("td"));
                    foreach (var entry in tds)
                    {
                        Console.WriteLine(entry.Text);

                    }
                }


            }
        }
        [Then(@"'(.*)' is displayed in the section")]
        public void ThenIsDisplayedInTheSection(string requiredField)
        {
            new ReferralFormConfiguration(driverContext).VerifyTable();
           
        }
               
    }
}
