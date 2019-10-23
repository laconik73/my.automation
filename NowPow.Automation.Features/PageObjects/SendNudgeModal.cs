using NSelene;
using static NSelene.Selene;
using Ocaramba;
using NowPow.Automation.PageObjects;
using System;
using NLog;
using Nowpow.Automation.Features.StepDefinitions;
using Nowpow.Automation.Features.PageObjects;

namespace NowPow.Automation.Features.StepDefinitions
{
    internal class SendNudgeModal : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        SeleneElement emailButton = S("#btn-email");
        SeleneElement closeButton = S("button[class='close']");
        SeleneElement inputMessage = S("div.message-area");
        SeleneElement attachmentContainer = S("#attachment-container");
        SeleneElement nudgeButton = S("#btn-add");

        public SendNudgeModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        internal SendNudgeModal ClickEmailIcon()
        {
            WaitForNot(smallSpinner, Be.InDom);
            emailButton.Click();
            return this;
        }

        internal SendNudgeModal InputEmail(string email)
        {
            closeButton.Click();
            S("input[type='text']").SendKeys(email);
            return this;

        }      

        internal SendNudgeModal AddErx()
        {
            attachmentContainer.Click();
            return this;
        }

        internal PatientPage SendNudge()
        {
            nudgeButton.Click();
            return new PatientPage(DriverContext);
        }

        internal ErxPage AddNudge()
        {
            S("#btn-add").Click();
            return new ErxPage(DriverContext);
        }
    }
}
