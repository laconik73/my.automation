using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using static NSelene.Selene;

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
    }
}