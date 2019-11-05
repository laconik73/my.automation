using NLog;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using System;
using static NSelene.Selene;
using OpenQA.Selenium;
using Nowpow.Automation.Features.StepDefinitions;
using System.Collections.Generic;


namespace Nowpow.Automation.Features.PageObjects
{
    internal class ReferralsSentPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement referralMessage = S("div[class*='message']");
        SeleneElement inputMessage = S("#new-message");        
        SeleneElement sendButton = S("#send-button");
        SeleneElement backButton = S("span#back-link");
        SeleneElement referralStatus = S(By.XPath("//span[@class='referral-icon-label'][contains(text(),'New')]"));
        

        public ReferralsSentPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        internal ReferralsSentPage ClickMessage()
        {
            referralMessage.Click();
            return new ReferralsSentPage(DriverContext);
        }

        internal ReferralsSentPage WriteMessage(string note)
        {
            inputMessage.Hover().SendKeys(note);
            return this;
        }

        internal ReferralsSentPage SendMessage()
        {
            WaitForNot(spinner, Be.InDom);
            sendButton.Click();
            return this;
        }

        internal ReferralsSentPage NavigateBack()
        {
            backButton.Click();
            return new ReferralsSentPage(DriverContext);
        }

        internal EditReferralModal ChooseStatus(string statusNew)
        {
            WaitForNot(S(".modal.modal-card.fade.in"), Be.InDom);
            referralStatus.Click();
            return new EditReferralModal(DriverContext);
        }

        internal ReferralsSentPage DisplayOrganizations()
        {
            IList<IWebElement> senders = SS("div[class*='referral-organization']");
            IList<string> organizations = new List<string>();
            foreach(IWebElement element in senders)
            {
                organizations.Add(element.ToString());
                Console.WriteLine("Organization "+element.ToString());
            }
                                                         
            IList<IWebElement> receivers = SS("div.drawer-space:nth-child(2) > div.info:nth-child(2)");
            IList<string> coordinatedReceivers = new List<string>();
            foreach (IWebElement element in receivers)
            {
                coordinatedReceivers.Add(element.ToString());
                Console.WriteLine("Coordinated Receiver "+element.ToString());
            }

            return this;
        }
    }
}
  

    

