using System;
using NLog;
using NowPow.Automation.Features.StepDefinitions;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using static NSelene.Selene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class ScreeningResultsModal: ProjectPageBase
    { 
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
       
        SeleneElement screeningNote = S(".input-field");
        SeleneElement confirmButton = S("#btn-confirm");
        

        public ScreeningResultsModal(DriverContext driverContext): base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        internal ScreeningResultsModal SaveScreeningResults()
        {
            return this;
        }
        internal ScreeningResultsModal WriteNote(string note)
        {
            screeningNote.SendKeys(note);
            return this;
        }

        

        internal ScreeningPage Confirm()
        {
            confirmButton.Click();
            return new ScreeningPage(DriverContext);
        }
    }
}