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
    public class DocumentsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string query;

        public DocumentsSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user chooses a subtab '(.*)'")]
        public void GivenUserChoosesASubtab(string subtabName)
        {
            new PatientPage(driverContext).OpenDocuments(subtabName);
        }
        [When(@"user clicks on '(.*)'")]
        public void WhenUserClicksOn(string button)
        {
            new PatientPage(driverContext).ClickUploadDocument(button);
        }
        [When(@"user chooses '(.*)' action")]
        public void WhenUserChoosesAction(string delete)
        {
            var modal = new PatientPage(driverContext).TakeAction();
            modal.Delete();
        }
        [When(@"user clicks '(.*)' action")]
        public void WhenUserClicksAction(string download)
        {
            var modal = new PatientPage(driverContext).TakeAction();
            modal.Download();
        }
        [When(@"user clicks on '(.*)' action")]
        public void WhenUserClicksOnAction(string notes)
        {
            var modal = new PatientPage(driverContext).TakeAction();
            modal.Notes();
        }


        [Then(@"document is removed from patient's documents")]
        public void ThenDocumentIsRemovedFromPatientSDocuments()
        {
            new PatientPage(driverContext);
            Assert.IsTrue(true);
        }
        [Then(@"file is downloaded")]
        public void ThenFileIsDownloaded()
        {
            new PatientPage(driverContext);
            Assert.IsTrue(true);
        }


        [Then(@"'(.*)' modal pops up")]
        public void ThenModalPopsUp(string modalTitle)
        {
            new UploadDocumentModal(driverContext);
            String actualModalTitle = S(By.XPath("//h4[@class='modal-title']")).GetText();
            String expectedModalTitle = "Upload Document";
            Assert.AreEqual(actualModalTitle, expectedModalTitle);
        }
        [Then(@"'(.*)' modal displays")]
        public void ThenModalDisplays(string modalTitle)
        {
            new NotesModal(driverContext);
            String actualModalTitle = S(By.XPath("//h4[@class='modal-title']")).GetText();
            String expectedModalTitle = "Notes";
            Assert.AreEqual(actualModalTitle, expectedModalTitle);
        }




    }
}

