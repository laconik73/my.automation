using System;
using NLog;
using NowPow.Automation.PageObjects;
using Ocaramba;
using static NSelene.Selene;
using OpenQA.Selenium;
using NSelene;
using AutoItX3Lib;
using System.Threading;
using System.Diagnostics;
using Microsoft.JScript;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class UploadDocumentModal: ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        SeleneElement chooseFile = S("#btn-choose-file");
        SeleneElement uploadButton = S("#btn-add");
        SeleneElement cancelButton = S("#btn-cancel");

        public UploadDocumentModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        internal UploadDocumentModal ChooseFile()
        {
            chooseFile.Click();
            Thread.Sleep(1000);
            //AutoIT= Handles Windows that do not belong to browser.
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            autoIt.Send("C:\\Users\\sabina.dovlati\\Desktop\\Scale.pdf");
            Thread.Sleep(1000);
            autoIt.Send(@"{ENTER}");
            Thread.Sleep(1000);
            return this;
        }
        internal PatientPage Upload()
        {
            uploadButton.Click();
            return new PatientPage(DriverContext);
        }

        internal UploadDocumentModal ChooseOneFile()
        {

            chooseFile.Click();
            Thread.Sleep(1000);
            //AutoIT= Handles Windows that do not belong to browser.
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            autoIt.Send("C:\\Users\\sabina.dovlati\\Desktop\\ScaleTestDocs\\Scale.docx");
            Thread.Sleep(1000);
            autoIt.Send(@"{ENTER}");
            Thread.Sleep(1000);
            return this;
        }

        internal UploadDocumentModal EnableUpload(string button)
        {
            Assert.IsTrue(uploadButton.Enabled);
            return this;
        }

        internal PatientPage ClickCancel(string button)
        {
            cancelButton.Click();
            return new PatientPage(DriverContext);
        }

        internal UploadDocumentModal ChooseVirusFile()
        {
            chooseFile.Click();
            Thread.Sleep(1000);
            //AutoIT= Handles Windows that do not belong to browser.
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            autoIt.Send("Tanya add your path here");
            Thread.Sleep(1000);
            autoIt.Send(@"{ENTER}");
            Thread.Sleep(1000);
            return this;
        }
    }
}