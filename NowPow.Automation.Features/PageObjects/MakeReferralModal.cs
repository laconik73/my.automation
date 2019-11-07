using System;
using System.Threading;
using AutoItX3Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using static NSelene.Selene;
using OpenQA.Selenium;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class MakeReferralModal: ProjectPageBase
    { 
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement inputPatientName = S("#patient-search.typeahead");
        SeleneElement datasetPatients = S(".tt-dataset");
        SeleneElement inputTextbox = S("#notes");
        SeleneElement referralRow = S("#referralRow.col-xs-8");
        SeleneElement sendButton = S("#btn-add.btn-modal");
        SeleneElement addDocumentButton = S("button[class*='btn-attach-document']");
        SeleneElement deleteIcon = S(".btn-delete-document");
        SeleneElement restrictionCheckbox = S("#restrictionsCheckBox");
        SeleneElement patientEmail = S("#patientEmailAddress");
        SeleneElement resultMatch = S("div.result.match.tt-suggestion.tt-selectable");


        public static bool Displayed { get; internal set; }

        public MakeReferralModal(DriverContext driverContext): base (driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        internal MakeReferralModal MakeReferral()
        {
            return this;
        }
        //input patient name into search field within the modal
        internal MakeReferralModal PatientMrn(string patientName)
        {                       
            WaitFor(inputPatientName, Be.Visible);
            inputPatientName.Hover().SendKeys(patientName).Click();            
            return this;
        }
        //pick first prepopulated patient name
        internal MakeReferralModal SelectFirstDataset()
        {            
            WaitFor(datasetPatients, Be.InDom);           
            datasetPatients.Click();            
            return this;
        }        
        internal MakeReferralModal WriteNote(string note)
        {
            inputTextbox.SendKeys(note);
            return this;
        }
        
        internal MakeReferralModal SelectCheckbox()
        {
            referralRow.Click();
            return this;
        }        
        internal ServicePage Send()
        {
            sendButton.Click();
            return new ServicePage(DriverContext);
        }

        internal MakeReferralModal AddDocument()
        {
            WaitForNot(smallSpinner, Be.InDom);
            addDocumentButton.Click();
            Thread.Sleep(1000);
            //AutoIT= Handles Windows that do not belong to browser.
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            autoIt.Send("C:\\Users\\sabina.dovlati\\Desktop\\ScaleTestDocs\\Scale.docx");
            Thread.Sleep(1000);
            autoIt.Send(@"{ENTER}");
            Thread.Sleep(1000);
            return this;
        }

        internal MakeReferralModal AddAnotherDocument()
        {
            addDocumentButton.Click();
            Thread.Sleep(1000);
            //AutoIT= Handles Windows that do not belong to browser.
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            autoIt.Send("C:\\Users\\sabina.dovlati\\Desktop\\Scale.pdf");
            Thread.Sleep(1000);
            autoIt.Send(@"{ENTER}");
            Thread.Sleep(1000);
            return this;
        }

        internal MakeReferralModal ClickDeleteIcon()
        {            
            try
            {                
                deleteIcon.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("test failed");
            }

            return this;
        }        

        internal ErxPage SendCoordinatedReferral()
        {
            S("#btn-add").Click();
            return new ErxPage(DriverContext);
        }

        internal MakeReferralModal SelectRestrictionCheckBox()
        {
            try
            {
                restrictionCheckbox.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("test failed");
            }

           
            return this;
        }

        internal MakeReferralModal SelectConsentCheckBox()
        {
            try
            {
                referralRow.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("test failed");
            }
           
            return this;
        }

        internal ProfilePage SendButton()
        {
            S("#btn-add").Click();
            return new ProfilePage(DriverContext);
        }

        internal MakeReferralModal ChooseVirusFile()
        {
            WaitForNot(smallSpinner, Be.InDom);
            addDocumentButton.Click();
            Thread.Sleep(1000);
            //AutoIT= Handles Windows that do not belong to browser.
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            autoIt.Send("C:\\Users\\sabina.dovlati\\Desktop\\eicar.txt");
            Thread.Sleep(1000);
            autoIt.Send(@"{ENTER}");
            Thread.Sleep(1000);
            return this;
        }
        
        internal MakeReferralModal SelectFirstResultMatch()
        {            
            resultMatch.Click();
            return this;
        }
    }
}