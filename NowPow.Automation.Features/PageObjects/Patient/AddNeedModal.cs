using NSelene;
using static NSelene.Selene;
using Ocaramba;
using NowPow.Automation.PageObjects;
using System;
using OpenQA.Selenium;

namespace NowPow.Automation.Features.StepDefinitions
{
    internal class AddNeedModal : ProjectPageBase

    { 
        SeleneElement inputTextbox = S("#notes");
        SeleneElement addButton = S("#btn-add");

        public AddNeedModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
        //Adding needs with a note
        internal AddNeedModal SelectFirstNeed()
        {
           S("button[data-id='selNeed']").Click();
            S(".btn-group.bootstrap-select.open a").Click();  
            return this; 
        }
        
        internal AddNeedModal SelectInteractionType()
           
        {
            S("button[data-id='selNeedIdentifiedThru']").Click();
            S(".btn-group.bootstrap-select.open a").Click();
            return this;
            
        }

        internal AddNeedModal SelectDuration()
        {
            S("button[data-id='durationType']").Click();
            S(".btn-group.bootstrap-select.open a").Click();
            return this;
        }

        internal AddNeedModal WriteNote(string note)
        {
            inputTextbox.SendKeys(note);
            return this;
        }
        
        internal DashboardPage Add()
        {
            addButton.Click();
            return new DashboardPage(DriverContext);
        }
    }
 }
