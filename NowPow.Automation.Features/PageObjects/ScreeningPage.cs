using NLog;
using NSelene;
using NowPow.Automation.PageObjects;
using static NSelene.Selene;
using Ocaramba;
using Nowpow.Automation.Features.StepDefinitions;
using Nowpow.Automation.Features.PageObjects;
using OpenQA.Selenium;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NowPow.Automation.Features.StepDefinitions
{
    internal class ScreeningPage : ProjectPageBase
    { 
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        
        SeleneElement startButton = S(".btn.btn-primary");
        SeleneElement radioButton1 = S("input[id='question-2-answer-1']");
        SeleneElement radioButton2 = S("input[id='question-5-answer-6']");
        SeleneElement radioButton3 = S("input[id='question-6-answer-9']");
        SeleneElement nextButton = S("#next.btn");        
        SeleneElement saveButton = S("#save.btn.btn-next");
        SeleneElement generateErxButton = S("#generate-erx");
        

        public ScreeningPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }      

        //Start screening
        internal ScreeningPage Start()
        {
            WaitFor(S(".col-xs-9"), Be.Visible);
            startButton.Click();
            return new ScreeningPage(DriverContext);
        }
        internal ScreeningPage SubmitBaseScreening()
        {

            WaitFor(radioButton1, Be.Visible);
            radioButton1.Click();


            WaitFor(radioButton2, Be.Visible);
            radioButton2.Click();

            WaitFor(radioButton3, Be.Visible);
            radioButton3.Click();
                       
            return new ScreeningPage(DriverContext);
        } 
         internal LivingSituationPage Next()
        {
            nextButton.Click();
            return new LivingSituationPage(DriverContext);
        }
                
        
        //Saving screening
        internal ScreeningResultsModal SaveButton()
        {
            WaitFor(S(".screening-summary-question-answers"), Be.Visible);
            saveButton.Click();                     
            return new ScreeningResultsModal(DriverContext);
        }
        internal ScreeningErxPage GenerateHealtherxScreening(string generateErx)
        {
            generateErxButton.Click();

            SeleneElement screeningMessage= S("#results-screening-name");
            String expectedMessage = screeningMessage.GetText();
            String actualMessage = "AHC Track 2 Screening HealtheRx";
            Assert.AreEqual(actualMessage, expectedMessage);               
            
            return new ScreeningErxPage(DriverContext);
        }       
                      
        
        internal ScreeningPage GetCode(string code)
        {
            S("#get-code").Click();
            String expectedSN = S("#divPatientName").GetText();
            String actualSN = "NowPow Screening Code for Sophie Arnold:";
            Assert.AreEqual(expectedSN, actualSN);

            return new ScreeningPage(DriverContext);
        }
        internal ScreeningPage GotItButton()
        {
            S("#btn-Back").Click();
            return new ScreeningPage(DriverContext);
        }
        internal ScreeningPage SaveForLater()
        {
            WaitFor(S(By.XPath("//h3[contains(text(),'Information')]")), Be.Visible);
            S("#save-screening-for-later").Click();
            return new ScreeningPage(DriverContext);
        }

        internal PatientPage SaveLaterButton()
        {
            S("#btn-confirm").Click();
            return new PatientPage(DriverContext);
        }
        internal ScreeningPage StartButton()
        {
            S(".btn.btn-primary").Click();
            return new ScreeningPage(DriverContext);
        }
        internal ScreeningPage SelectFirstSection()
        {
            IList<IWebElement> radioButton = SS("input[type='radio']");
            int iSize = radioButton.Count;
            for (int i=0; i<iSize; i++)
            {
                String Value = radioButton.ElementAt(i).GetAttribute("value");
                if (Value.Equals("Mordor"))
                {
                    WaitForNot(S(".answer"), Be.Selected);
                    radioButton.ElementAt(i).Click();
                    break;
                }
            }
           
                       
            return new ScreeningPage(DriverContext);
        }

        
    }    
       
}
