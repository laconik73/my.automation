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

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class UploadDocumentModal: ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        SeleneElement chooseFile = S("#btn-choose-file");
        SeleneElement uploadButton = S("#btn-add");

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
    }
}