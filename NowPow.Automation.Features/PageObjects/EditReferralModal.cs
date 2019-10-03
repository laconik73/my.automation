using System;
using NLog;
using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using OpenQA.Selenium;
using static NSelene.Selene;


namespace Nowpow.Automation.Features.StepDefinitions
{
    public class EditReferralModal : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
       
        SeleneElement contactStatusContainer = S("[data-id='contactStatus']");
        SeleneElement saveButton = S("#btn-save");
        


        public EditReferralModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }      

        internal EditReferralModal SelectContactStatus(string statusName)
        {
            contactStatusContainer.Click();
            S(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'Contacted')]")).Click();
            
            return this;
        }        

        internal EditReferralModal EnterNote(string note)
        {
            S("div.col-xs-12.outcome").SendKeys(note);
            return this;
        }

        internal PatientPage Save()
        {
            saveButton.Click();
            return new PatientPage(DriverContext);
        }

        
    }
}