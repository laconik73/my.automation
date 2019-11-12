using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using System;
using TechTalk.SpecFlow;
using static NSelene.Selene;
using OpenQA.Selenium;
using NSelene;
using System.Threading;
using Ocaramba.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class DocumentsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string query;
        private string note;

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

            if (duplicateName == "Scale" + n)
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
        [When(@"user proceeds with '(.*)'")]
        public void WhenUserProceedsWith(string deleteButton)
        {
            new PatientPage(driverContext).ProceedWithDelete();
        }
        [Then(@"document is deleted")]
        public void ThenDocumentIsDeleted()
        {
            new PatientPage(driverContext);
            Assert.IsTrue(S(By.XPath("//h4[contains(text(),'There are currently no documents uploaded to this')]")).Displayed);
        }
        [When(@"user uploads a virus document")]
        public void WhenUserUploadsAVirusDocument()
        {
            new UploadDocumentModal(driverContext)
                .ChooseVirusFile()
                .Upload();
        }

        [Then(@"'(.*)' message  with a link is displayed")]
        public void ThenMessageWithALinkIsDisplayed(string errorMessage)
        {
            new UploadDocumentModal(driverContext);

            String actualMessage = S(By.XPath("//div[@class='error-area row center-xs']")).GetText();
            Console.WriteLine(actualMessage);

            Thread.Sleep(5000);
            this.Verify(actualMessage);
        }
        [When(@"user adds virus document")]
        public void WhenUserAddsVirusDocument()
        {
            new MakeReferralModal(driverContext)
                .ChooseVirusFile()
                .SelectRestrictionCheckBox()
                .SelectConsentCheckBox()
                .SendButton();
        }
        [Then(@"referral is not created")]
        public void ThenReferralIsNotCreated()
        {
            new MakeReferralModal(driverContext);
            String redMessage = S(By.XPath("//span[@class='virus-error-message']")).GetText();
            Console.WriteLine(redMessage);
            Thread.Sleep(5000);

        }
        [Then(@"user uploads file with a note")]
        public void ThenUserUploadsFileWithANote()
        {
            note = DateTime.Now.Ticks.ToString();
            new UploadDocumentModal(driverContext)
                 .ChooseFile()
                 .InputDocumentNotes(note)
                 .Upload();
        }
        [Then(@"fie is successfully uploaded and note is displayed")]
        public void ThenFieIsSuccessfullyUploadedAndNoteIsDisplayed()
        {
            new ProfilePage(driverContext);
            Assert.IsTrue(S("tbody.documents-table-body tr td:nth-child(4)").Displayed);

        }
        [When(@"user  selects  '(.*)'")]
        public void WhenUserSelects(string service)
        {
            new ServicePage(driverContext).SelectFavorite(service);
        }

        [When(@"user refers patient with virus document")]
        public void WhenUserRefersPatientWithVirusDocument()
        {
            var modal = new MakeReferralModal(driverContext).MakeReferral();
            modal.PatientMrn("johnny")
                .SelectFirstResultMatch()
                .ChooseVirusFile()
                .SelectRestrictionCheckBox()
                .SelectConsentCheckBox()
                .SendButton();

        }
        [Given(@"user is on '(.*)' page")]
        public void GivenUserIsOnPage(string tabName)
        {
            new DashboardPage(driverContext).OpenReferralsSent();
        }
        [When(@"user is on referral with attached document")]
        public void WhenUserIsOnReferralWithAttachedDocument()
        { 
             new ReferralsSentPage(driverContext)
                .OpenChevronDown()
                .AddDocument()
                .ChooseFile()
                .UploadToReferralSent();
            Thread.Sleep(3000);
            WaitForNot(S(".modal-backdrop.fade"), Be.InDom);
        }
        [When(@"user decides to delete a document")]
        public void WhenUserDecidesToDeleteADocument()
        {
            new ReferralsSentPage(driverContext)
                .OpenChevronDown()
                .DeleteDocument()
                .ProceedWithDelete();
            Thread.Sleep(3000);
            WaitForNot(S(".modal-backdrop.fade"), Be.InDom);
        }
        [Then(@"document is removed from Sent Referrals")]
        public void ThenDocumentIsRemovedFromSentReferrals()
        {
            new ReferralsSentPage(driverContext).OpenChevronDown();
           
        }
        [When(@"user is on received referrals with attached document")]
        public void WhenUserIsOnReceivedReferralsWithAttachedDocument()
        {
            new DashboardPage(driverContext)
                .OpenReceivedReferrals()
                .OpenChevronDown()
                .AddDocument()
                .ChooseFile()
                .UploadToReceivedReferrals();
            Thread.Sleep(500);
            WaitForNot(S(".modal.modal-card.fade"), Be.InDom);
                 
        }
        [When(@"user deletes document")]
        public void WhenUserDeletesDocument()
        {
            new ReferralsReceivedPage(driverContext)
               .OpenChevronDown()
               .DeleteDocument()
               .ProceedWithDelete();
            Thread.Sleep(500);
            WaitForNot(S(".modal.modal-card.fade"), Be.InDom);

        }
        [Then(@"document is removed from Received Referrals")]
        public void ThenDocumentIsRemovedFromReceivedReferrals()
        {
            new ReferralsReceivedPage(driverContext).OpenChevronDown();
            
        }
        [Then(@"file is added to Sent Referrals")]
        public void ThenFileIsAddedToSentReferrals()
        {
            new ReferralsSentPage(driverContext);
            Assert.IsTrue(S("i.urgent.clip").Displayed);
        }
        [Given(@"user is on Referrals Received page")]
        public void GivenUserIsOnReferralsReceivedPage()
        {
            new DashboardPage(driverContext).OpenReceivedReferrals();
        }

        [Then(@"file is added to Received Referrals")]
        public void ThenFileIsAddedToReceivedReferrals()
        {
            new ReferralsReceivedPage(driverContext);
            Assert.IsTrue(S("i.urgent.clip").Displayed);
        }
        
        [When(@"user views documents")]
        public void WhenUserViewsDocuments()
        {
            new ReferralsSentPage(driverContext).OpenChevronDown();
            Assert.IsTrue(S("i.urgent.clip").Displayed);
        }
        [When(@"user downloads document")]
        public void WhenUserDownloadsDocument()
        {
            new ReferralsSentPage(driverContext).DownloadDocument();
        }
        [Then(@"document is downloaded")]
        public string ThenDocumentIsDownloaded()
        {
            new ReferralsSentPage(driverContext);
                    
             var nameOfFile = FilesHelper.GetFilesOfGivenType(this.driverContext.ScreenShotFolder, FileType.Docx);
            return nameOfFile.ToString();           
        }        
        
        [Then(@"documents are sorted by Upload Date in Descending order")]
        public void ThenDocumentsAreSortedByUploadDateInDescendingOrder()
        {
            new ProfilePage(driverContext);
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now + TimeSpan.FromDays(1);
            var value = dt2.CompareTo(dt1);
        }
        [Then(@"user refreshes page")]
        public void ThenUserRefreshesPage()
        {
            new ProfilePage(driverContext)
                .RefreshPage()
                .OpenDocuments();
        }
        [When(@"user clicks on '(.*)' column")]
        public void WhenUserClicksOnColumn(string column)
        {
            new ProfilePage(driverContext).SortByDocumentName(column);
        }
        [Then(@"documents are displayed in Ascending order")]
        public void ThenDocumentsAreDisplayedInAscendingOrder()
        {
            new ProfilePage(driverContext);
            List<String> displayAscendingNames = new List<string>();
            IReadOnlyList<IWebElement> cells = SS("td.padLeft30");
            foreach(IWebElement cell in cells)
            {
                displayAscendingNames.Add(cell.Text);
            }
            List<String> displayNamesSorted = new List<string>(displayAscendingNames);
            displayNamesSorted.Sort();
            Console.WriteLine(displayAscendingNames.SequenceEqual(displayNamesSorted));
            
        }
        [Then(@"user chooses '(.*)' column")]
        public void ThenUserChoosesColumn(string column)
        {
            new ProfilePage(driverContext).SortByUploadDate(column);
        }
        [Then(@"dates are displayed in Ascending order")]
        public void ThenDatesAreDisplayedInAscendingOrder()
        {
            new ProfilePage(driverContext);
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now + TimeSpan.FromMinutes(1);
            var value = dt2.CompareTo(dt1);
        }
        [Then(@"all documents associated to the referral are listed")]
        public void ThenAllDocumentsAssociatedToTheReferralAreListed()
        {
            new ReferralsSentPage(driverContext);
            IList<IWebElement> documents= SS("div[class*='document_container'] div.info");
            IList<string> attachedDocuments = new List<string>();
            foreach (IWebElement document in documents)
            {
                attachedDocuments.Add(document.ToString());
            }
            String document1 = S("div[class*='document_container'] div.info:nth-child(3)").Text;
            Console.WriteLine(document1.ToString());
            String document2 = S("div[class*='document_container'] div.info:nth-child(4)").Text;
            Console.WriteLine(document2.ToString());
        }
        [When(@"user views documents on received referrals")]
        public void WhenUserViewsDocumentsOnReceivedReferrals()
        {
            new ReferralsReceivedPage(driverContext)
                .SearchPatient()
                .OpenPatientInfo();          

        }
        [Then(@"all documents associated to the received referrals are listed")]
        public void ThenAllDocumentsAssociatedToTheReceivedReferralsAreListed()
        {
            new ReferralsReceivedPage(driverContext);
            IList<IWebElement> documents = SS("div[class*='document_container'] div.info");
            IList<string> attachedDocuments = new List<string>();
            foreach (IWebElement document in documents)
            {
                attachedDocuments.Add(document.ToString());
            }
            String document1 = S("div[class*='document_container'] div.info:nth-child(7)").Text;
            Console.WriteLine(document1.ToString());
            String document2 = S("div[class*='document_container'] div.info:nth-child(6)").Text;
            Console.WriteLine(document2.ToString());
        }
        [Then(@"user clicks on '(.*)'")]
        public void ThenUserClicksOn(string subtabName)
        {
            new ReferralsReceivedPage(driverContext).OpenTaskView(subtabName);
        }
        [Then(@"same documents are displayed in sidepanel tab related to '(.*)'")]
        public void ThenSameDocumentsAreDisplayedInSidepanelTabRelatedTo(string sidepanelTab)
        {
            new ReferralsReceivedPage(driverContext)
                .OpenAttendanceAndOutcomes(sidepanelTab)
                .SearchPatientAttendance()
                .ViewSameDocuments();
        }
























    }


}

