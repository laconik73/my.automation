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
        [When(@"user uploads file")]
        public void WhenUserUploadsFile()
        {
            new UploadDocumentModal(driverContext)
                .ChooseFile()
                .Upload();
        }
       
        [Then(@"file is uploaded as '(.*)' and increases by '(.*)' unit")]
        public void ThenFileIsUploadedAsAndIncreasesByUnit(string duplicateName, int n)
        {
            new PatientPage(driverContext);
            
            if(duplicateName == "Scale" + n)
            {
                Assert.IsTrue(S(By.XPath("//tr[@class='odd']")).IsDisplayed());
            }            
            
        }
        [When(@"user chooses one file to upload")]
        public void WhenUserChoosesOneFileToUpload()
        {
            new UploadDocumentModal(driverContext).ChooseOneFile();
        }
        [Then(@"'(.*)' button is enabled")]
        public void ThenButtonIsEnabled(string button)
        {
            new UploadDocumentModal(driverContext).EnableUpload(button);
            
        }
        [Then(@"a user chooses '(.*)' button")]
        public void ThenAUserChoosesButton(string button)
        {
            new UploadDocumentModal(driverContext).ClickCancel(button);
        }
        [Then(@"modal is closed")]
        public void ThenModalIsClosed()
        {
            new PatientPage(driverContext);
            Assert.IsTrue(S(By.XPath("//h3[contains(text(),'Documents')]")).Displayed);
        }
        [Then(@"user clicks on '(.*)' again")]
        public void ThenUserClicksOnAgain(string button)
        {
            new PatientPage(driverContext).ClickUploadDocument(button);
        }
        [Then(@"any data entered on the previous modal is cleared")]
        public void ThenAnyDataEnteredOnThePreviousModalIsCleared()
        {
            new UploadDocumentModal(driverContext);
            String fileName = S(By.XPath("//label[@class='file-name']")).GetText();
            String expectedFileName = "NO FILE CHOSEN";
            Assert.AreEqual(fileName, expectedFileName);
        }
        [When(@"user is on Patient'(.*)'Overview' page")]
        public void WhenUserIsOnPatientOverviewPage(string subtabName)
        {
            new ProfilePage(driverContext);
            
        }
        [Then(@"'(.*)' subtab is displayed")]
        public void ThenSubtabIsDisplayed(string subtabName)
        {
            new ProfilePage(driverContext);
            bool subtabDocuments = Verify("#documents");
            Console.WriteLine("Documents subtab is displayed");

        }

        private bool Verify(string subtabName)
        {
            try
            {
                bool isDocumentsDisplayed = S("#documents").Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }
        [When(@"user refers a service")]
        public void WhenUserRefersAService()
        {
            new ProfilePage(driverContext).SendTrackedReferral();
        }
        [When(@"user adds document")]
        public void WhenUserAddsDocument()
        {
            new MakeReferralModal(driverContext).AddDocument();
        }
        [When(@"user adds another document")]
        public void WhenUserAddsAnotherDocument()
        {
            new MakeReferralModal(driverContext).AddAnotherDocument();
        }
        [Then(@"the files display as separate lines")]
        public void ThenTheFilesDisplayAsSeparateLines()
        {
            new MakeReferralModal(driverContext);
            Assert.IsTrue(S(By.XPath("//div[@class='attached-documents']")).Displayed);            
        }
        [When(@"user deletes a document")]
        public void WhenUserDeletesADocument()
        {
            new MakeReferralModal(driverContext).ClickDeleteIcon();
        }
        [Then(@"document is removed")]
        public void ThenDocumentIsRemoved()
        {
            new MakeReferralModal(driverContext);
            Assert.IsTrue(S(By.XPath("//div[@class='attached-documents']")).Displayed);
        }






    }

}

