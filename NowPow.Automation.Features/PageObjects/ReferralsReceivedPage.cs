﻿using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using static NSelene.Selene;
using OpenQA.Selenium;
using System;
using NLog;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class ReferralsReceivedPage: ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement taskViewSubNav = S("#tasks");
        SeleneElement referralMessage = S(".message.right");
        SeleneElement inputMessage = S("#new-message");
        SeleneElement sendButton = S("#send-button");
        SeleneElement patientsTab = S("a[id='nav-item-patients'][type]");
        SeleneElement minusCircle = S("div[class*='info acceptance'] i>svg[data-icon='minus-circle']");
        SeleneElement chevronDown = S(".btn-activity.open-drawer");
        SeleneElement addDocumentButton = S(".btn.btn-white.attach-document");
        SeleneElement redDeleteIcon = S(".btn-delete-document");
        SeleneElement deleteButton = S("#btn-add");

        public ReferralsReceivedPage(DriverContext driverContext): base(driverContext)
        {
            
        }

        internal ReferralsReceivedPage OpenTaskView(string subNav)
        {
            taskViewSubNav.Click();
            return new ReferralsReceivedPage(DriverContext);
        }

        internal ReferralsReceivedPage ClickMessage()
        {
            try
            {
                referralMessage.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("test failed");
            }
            
            return new ReferralsReceivedPage(DriverContext);
        }

        internal ReferralsReceivedPage WriteMessage(string note)
        {
            inputMessage.Hover().SendKeys(note);
            return this;
        }

        internal ReferralsReceivedPage SendMessage()
        {
            WaitForNot(spinner, Be.InDom);
            sendButton.Click();
            return this;
        }

        internal PatientPage OpenPatients()
        {
            WaitForNot(S(".modal-content"), Be.InDom);
            patientsTab.Click();
            return new PatientPage(DriverContext);
        }

        internal EditReferralModal ClickOnNewReferral()
        {            
            minusCircle.Click();
            return new EditReferralModal(DriverContext);
        }

        internal ReferralsReceivedPage OpenChevronDown()
        {
            chevronDown.Click();
            return this;
        }

        internal UploadDocumentModal AddDocument()
        {
            addDocumentButton.Click();
            return new UploadDocumentModal(DriverContext);
        }

        internal ReferralsReceivedPage DeleteDocument()
        {
            redDeleteIcon.Click();
            return new ReferralsReceivedPage(DriverContext);
        }

        internal ReferralsReceivedPage ProceedWithDelete()
        {
            try
            {
                deleteButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(" test failed");
            }
           
            return new ReferralsReceivedPage(DriverContext);
        }
    }
}