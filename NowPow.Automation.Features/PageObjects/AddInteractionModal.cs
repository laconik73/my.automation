using NSelene;
using static NSelene.Selene;
using Ocaramba;
using NowPow.Automation.PageObjects;
using System;
using OpenQA.Selenium;

namespace NowPow.Automation.Features.StepDefinitions
{
    internal class AddInteractionModal : ProjectPageBase
    {
        SeleneElement typeButton = S("[data-id='type']");
        public AddInteractionModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        

        internal AddInteractionModal ChooseInteraction()
        {
            S("button[title='Select Interaction Type']").Click();
            S(".bootstrap-select.open a").Click();
            return this;
        }

        internal AddInteractionModal ChooseDuration()
        {
            S("button[title='Select Duration']").Click();
            S(".bootstrap-select.open a").Click();
            return this; 
        }

        internal DashboardPage Save()
        {
            S("#btn-add").Click();
            return new DashboardPage(DriverContext);
        }
    }
        
}