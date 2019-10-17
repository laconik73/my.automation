using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using static NSelene.Selene;
using NowPow.Automation.Features.StepDefinitions;
using System;
using OpenQA.Selenium;

namespace Nowpow.Automation.Features.PageObjects
{
    internal class AddReferralModal : ProjectPageBase
    { 
        SeleneElement inputTextbox = S("#notes");
        SeleneElement restrictionCheckbox = S("#referralRow");
        SeleneElement consentCheckbox = S("#referralRow.col-xs-8");
        SeleneElement sendButton = S("#btn-add.btn-modal");
        SeleneElement addDocumentButton = S(".btn.btn-attach-document");
        SeleneElement filePicker = S("input[id='file-picker'][type='file']");
        private IJavaScriptExecutor driver;

        public AddReferralModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        // Adding referral with a note
        internal AddReferralModal SelectFirstRefer()
        {
            
            WaitFor(S("button[data-id][data-org]"), Be.Visible);
            WaitForNot(smallSpinner, Be.Visible);
            S("button[data-id][data-org]").Click();
            return new AddReferralModal(DriverContext);
        }
        internal AddReferralModal MakeReferral()
        {
            return this;
        }

        internal AddReferralModal WriteNote(string note)
        {
            inputTextbox.SendKeys(note);
            return this;
        }
        //Verify checkboxes in AddReferral Modal
        internal AddReferralModal SelectCheckbox1()
        {
            WaitForNot(smallSpinner, Be.InDom);
            restrictionCheckbox.Click();
            return this;
        }
        internal AddReferralModal SelectCheckbox2()
        {
            consentCheckbox.Click();
            return this;
        }        
        internal ProfilePage Send()
        {
            sendButton.Click();
            return new ProfilePage(DriverContext);
        }

        internal AddReferralModal SelectReferralRow()
        {
            WaitForNot(smallSpinner, Be.InDom);
            WaitFor(S("#restrictionsCheckBox"),Be.Visible)
                .Hover()
                .Click();
            return this;           
                       
        }
    }
}

      
       
       

      

        
       