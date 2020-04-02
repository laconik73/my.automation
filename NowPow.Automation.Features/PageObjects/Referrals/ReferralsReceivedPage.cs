using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using static NSelene.Selene;
using OpenQA.Selenium;
using System;
using NLog;
using System.Collections.Generic;
using Nowpow.Automation.Features.StepDefinitions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;

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
        SeleneElement patientSearch = S("#patient-search");
        SeleneElement submitSearch = S("#btn-search");
        SeleneElement attendanceTab = S("#attendance-tab");
       

        public ReferralsReceivedPage(DriverContext driverContext): base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            DriverContext.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
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

        internal ReferralsReceivedPage SearchPatient()
        {            
            patientSearch.Hover().SendKeys("bradley adams");            
            submitSearch.Click();
            return new ReferralsReceivedPage(DriverContext);
        }

        internal ReferralsReceivedPage OpenPatientInfo()
        {
            SeleneElement patientInfo = S(By.XPath("//i[@id='2656']"));
            patientInfo.Click();
            return this;
        }

        internal ReferralsReceivedPage OpenAttendanceAndOutcomes(string sidepanelTab)
        {            
            attendanceTab.Click();
            Thread.Sleep(3000);
            return new ReferralsReceivedPage(DriverContext);
        }

        internal ReferralsReceivedPage SearchPatientAttendance()
        {
            WaitFor(S("#patient-search-attendance"), Be.Visible).Hover().SendKeys("bradley adams");
            WaitFor(S("#btn-search-attendance"), Be.Visible).Hover().Click();            
            WaitFor(S("#attendance-content-container"), Be.Visible);            
            return new ReferralsReceivedPage(DriverContext);
        }

        internal ReferralsReceivedPage ViewSameDocuments()
        {
            S(By.XPath("//i[@id='2605']")).Click();
            var js = (IJavaScriptExecutor)Driver;
            try
            {
                var document = S("div[class*='document_container'] div.info:nth-child(7)");
                if (document.Location.Y > 200)
                {
                    js.ExecuteScript("arguments[0].scrollIntoView(true);", document);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("test failed");
            }   
            
                                            

            return this;
        }
    }
}