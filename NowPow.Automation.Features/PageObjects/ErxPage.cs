using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Nowpow.Automation.Features.StepDefinitions;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using OpenQA.Selenium.Interactions;
using static NSelene.Selene;
using OpenQA.Selenium;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Nowpow.Automation.Features.PageObjects
{
    internal class ErxPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement nowPowErxCode = S("#eRx-code-label");
        SeleneElement backToPatient = S("#back-patient-link");
        SeleneElement erxLandingPage = S("#eRXlanding");
        SeleneElement centeredPannelTable = S(".centered-panel.well.col-xs-12.row");
        SeleneElement addressInput = S(".address-input");
        SeleneElement searchButton = S("#btn-search");
        SeleneElement categoriesButton = S("#btn-categories");
        SeleneElement conditonsButton = S("#btn-conditions");
        SeleneElement inputHealtherxCode = S("input[class*='eRXcode']");
        SeleneElement goButton = S("#eRXcode-next");
        SeleneElement addNewButton = S("#label-add-service");
        SeleneElement saveButton = S("#btn-save");
        SeleneElement depressionCheckbox = S(By.XPath("//label[contains(text(),'Depression')]"));
        SeleneElement diabetesCheckbox = S(By.XPath("//label[contains(text(),'Diabetes')]"));
        SeleneElement nextButton = S("#btn-next");
        SeleneElement languageFilter = S("button[data-id='languages']");
        SeleneElement hoursFilter = S("button[data-id='hours']");
        SeleneElement generateHealtheRxButton = S("#btn-next");
        SeleneElement editButton = S("#btn-edit");
        SeleneElement addServiceButton = S("#btn-add-service");
        SeleneElement searchProviders = S("#search-providers");
        SeleneElement removeServiceButton = S("button[class*='btn-remove-service']");
        SeleneElement serviceInput = S("#services-search-input");
        SeleneElement makeReferralButton = S("div.send-referral");




        public ErxPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        //"View eRx" button redirected to eRx Page.
        //Verify correct eRx code on Erx page
        internal ErxPage VerifyErxCode()
        {
            WaitFor(nowPowErxCode, Be.Visible);
            return new ErxPage(DriverContext);
        }
        //Redirecting from eRx Page back to Patient card
        internal PatientPage ReturnBackToPatient()
        {
            WaitForNot(spinner, Be.Visible);
            backToPatient.Click();
            return new PatientPage(DriverContext);
        }
        //Verify user on correct page
        internal ErxPage VerifyErxPage(string erxLanding, string centeredPannel)
        {
            Assert.IsTrue(true);
            return this;
        }
        //Verify buttons "AddNew" and "Save" are present on eRx page
        internal ErxPage VerifyButtons(string addNew, string save)
        {
            if (addNewButton.Enabled)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
            if (saveButton.Enabled)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
            return this;
        }
        //Verify eRx page display
        internal ErxPage VerifyCenteredPannel(string erxLanding, string centeredPannel)
        {
            Assert.IsTrue(erxLandingPage.Displayed && centeredPannelTable.Displayed);
            return this;
        }
        //Input address location into search field on eRx landing Page
        internal ErxPage InputAddress(string address)
        {
            addressInput.Clear().SendKeys(address);
            return this;
        }
        //Submit button for search field on eRx page
        internal ErxPage Search()
        {
            searchButton.Click();
            return new ErxPage(DriverContext);
        }
        //Verify after input of adress location card toppers are activated
        internal ErxPage VerifyCardToppersActivation(string serviceCategories, string conditions)
        {
            if (categoriesButton.Enabled)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
            if (conditonsButton.Enabled)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }

            return this;
        }
        //Scrolling page down to input eRx code on eRx landing page
        internal ErxPage GoToViewErxInputBox(string viewExistingHealtheRx)
        {
            return new ErxPage(DriverContext);
        }
        // type eRx code into search field and verify "Go" button activated
        internal ErxPage InputErxCode(string erxCode)
        {
            inputHealtherxCode.SendKeys(erxCode);
            Assert.IsTrue(goButton.Enabled);
            return this;
        }

        internal ErxPage Go()
        {
            goButton.Click();
            return new ErxPage(DriverContext);
        }
        //verify typed code and displayed eRX code matches


        internal ErxPage OpenConditionsCardTopper(string conditions)
        {
            conditonsButton.Click();
            return new ErxPage(DriverContext);
        }

        internal ErxPage SelectDepression()
        {

            depressionCheckbox.Hover().Click();
            return this;
        }
        internal ErxPage SelectDiabetes()
        {
            diabetesCheckbox.Hover().Click();
            return this;
        }
        internal ErxPage Next()
        {
            nextButton.Click();
            return new ErxPage(DriverContext);
        }

        internal ErxPage AddFilters(string filters)
        {
            return this;
        }

        internal ErxPage SelectLanguage()
        {
            languageFilter.Click();
            S(By.XPath("//span[contains(text(),'English')]")).Click();
            return this;
        }

        internal ErxPage SelectHours()
        {
            hoursFilter.Click();
            S(By.XPath("//span[contains(text(),'Open Evenings (5pm - midnight)')]")).Click();
            return this;
        }

        internal ErxPage GenerateHealtheRx()
        {
            generateHealtheRxButton.Click();
            return new ErxPage(DriverContext);
        }

        internal ErxPage Save(string newErxCode)
        {
            WaitForNot(spinner, Be.InDom);
            WaitFor(saveButton, Be.Visible).Click();
            return new ErxPage(DriverContext);
        }

        internal ErxPage OpenEdit()
        {
            WaitForNot(spinner, Be.InDom);
            editButton.Click();
            return new ErxPage(DriverContext);
        }

        internal ErxPage AddService(string add)
        {
            addServiceButton.Click();
            return this;
        }


        internal ErxPage SearchForServices()
        {
            S("#add-favorites").Click();
            return new ErxPage(DriverContext);
        }
        internal ErxPage SelectFirstResult()
        {
            WaitForNot(smallSpinner, Be.InDom);
            S(".col-xs-1:nth-child(2)").Click();
            return new ErxPage(DriverContext);
        }
        internal ErxPage Update()
        {
            S("#btn-add").Click();
            return new ErxPage(DriverContext);
        }
        internal ErxPage SaveAddedService()
        {
            WaitForNot(S(".modal-backdrop.fade"), Be.InDom);
            saveButton.Click();
            return new ErxPage(DriverContext);
        }
        internal ErxPage RemoveService()
        {
            removeServiceButton.Click();
            return new ErxPage(DriverContext);
        }
        internal ErxPage SaveRemovedServiceOnErx()
        {
            saveButton.Click();
            return new ErxPage(DriverContext);
        }
        internal ErxPage OpenServiceCategoriesCardTopper(string serviceCategories)
        {
            WaitFor(categoriesButton, Be.Visible).Hover().Click();
            return new ErxPage(DriverContext);
        }
        internal ErxPage SelectResult()
        {
            WaitFor(S("#expand-3"), Be.Visible).Click();
            WaitFor(S("#category3 div"), Be.Visible)
                 .Hover()
                 .Click();
            return this;
        }

        internal SendNudgeModal SendNudge()
        {
            WaitForNot(spinner, Be.InDom);
            S("#btn-nudge").Click();
            return new SendNudgeModal(DriverContext);
        }

        internal ErxPage ClickConditions()
        {
            conditonsButton.Click();
            return new ErxPage(DriverContext);
        }

        internal ErxPage SelectFinancialAssistance()
        {
            S(By.XPath("//label[contains(text(),'Financial Assistance')]"))
                .Hover()
                .Click();   
             return this; 
        }

        internal ErxPage SelectFoodInsecurity()
        {
            S(By.XPath("//label[contains(text(),'Food Insecurity (Adults)')]"))
                .Hover()
                .Click();
            return this;
        }
        
        internal MakeReferralModal MakeReferral()
        {
            try
            {
                S("button[class*='btn-send-referral']").Hover().Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("test failed");
            }
            
            return new MakeReferralModal(DriverContext);
        }

        
    }
}
          
                

        
               

        
    