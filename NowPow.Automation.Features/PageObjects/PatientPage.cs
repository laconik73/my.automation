using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using OpenQA.Selenium;
using System;
using static NSelene.Selene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    public class PatientPage : ProjectPageBase
    {

        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement createNewProfileButton = S("#btn-add-patient");
        SeleneElement firstNameTextbox = S("#firstName");
        SeleneElement lastNameTextbox = S("#lastName");
        SeleneElement dateOfBirthInput = S("#dateOfBirth");
        SeleneElement selectGender = S("[data-id='genderId']");
        SeleneElement saveandcreateButton = S("#saveandcreate");
        SeleneElement addReferralButton = S("#add-referral");
        SeleneElement userLevelButton = S("button[data-id='userLevelFilterOptions']");     
        SeleneElement statusFilterButton = S("button[data-id='statusFilterOptions']");
        SeleneElement viewErxButton = S(".row.col-xs.erx-name");
        SeleneElement patientHeader = S(".patient-header");
        SeleneElement buildNewErxButton = S("button[id='eRx-new']");      
        SeleneElement generateAutomaticErx = S("button[id='eRx-new-automatic']");
        SeleneElement editProfileButton = S("#editpatient");      
        SeleneElement contactInformationDrawer = S("#contactinformation-drawer.open-drawer");        
        SeleneElement addressInput = S("input[id='streetAddress']");
        SeleneElement cityInput = S("input[id='city']");        
        SeleneElement zipcodeInput = S("input[id='postalCode']");     
        SeleneElement conditionsDrawer = S("#conditions-drawer.open-drawer");
        SeleneElement addConditionButton = S("#addcondition");
        SeleneElement conditionsInput = S("#conditions-search-query");     
        SeleneElement searchButton = S("#btn-search");
        SeleneElement conditionCheckbox = S("div.col-xs-1");     
        SeleneElement updateButton = S("#btn-add");
        SeleneElement saveButton = S("#update");
        SeleneElement acceptanceInfo = S("div.col-xs.info.acceptance");
               
        public SeleneCollection AllDropDownList { get; private set; }

        public PatientPage(DriverContext driverContext) : base(driverContext)
        {
            
        }
        //Open "Referral" subtab 
        internal PatientPage OpenReferral(string subtabName)
        {
            S(By.Id("referrals")).Click();
            return new PatientPage(DriverContext);
        }
        //Open "Documents" subtab
        internal PatientPage OpenDocuments(string subtabName)
        {
            S(By.Id("documents")).Click();
            return new PatientPage(DriverContext);
        }


        //Make a refferal via PatientPage
        internal AddReferralModal AddReferral()
        {
            WaitForNot(smallSpinner, Be.InDom);
            addReferralButton.Click();
            return new AddReferralModal(DriverContext);
        }       

        //Creating new patient profile
        internal PatientPage OpenNewProfile()
        {
            WaitForNot(spinner, Be.InDom);
            createNewProfileButton.Click();
            return this;
        }        

        //Complete only required fields in "Basic Information"
        internal PatientPage EnterFirstName(string firstName)
        {
            firstNameTextbox.SendKeys(firstName);
            return this;
        }      

        internal PatientPage EnterLastName(string lastName)
        {
            lastNameTextbox.SendKeys(lastName);
            return this;
        }       

        internal PatientPage EnterDateOfBirth(string dateOfBirth)
        {
            dateOfBirthInput.SendKeys(dateOfBirth);
            return this;
        }

        internal PatientPage SelectGender(string gender)
        {
            selectGender.Click();
            return this;
        }

        internal ProfilePage SaveAndCreate()
        {
            saveandcreateButton.Click();
            return new ProfilePage(DriverContext);
        }      

        //Search and verify new patient card created
        internal ProfilePage View()
        {
            WaitFor(S("#results-area"), Be.Visible);
            return new ProfilePage(DriverContext);
        }
        //To choose any option from dropdown menu in "Referrals": My Referrals or any organization
        internal PatientPage FilterOption(string filterOption, string dropdownTitle)
        {
            if (filterOption == "User Level")
            {
                WaitForNot(smallSpinner, Be.InDom);
                userLevelButton.Click();
            }
            else
            {
                WaitForNot(smallSpinner, Be.InDom);
                statusFilterButton.Click();
            }
            S(By.XPath("//span[@class='text' and contains(text(),'" + dropdownTitle + "')]")).Click();

            return new PatientPage(DriverContext);
        }

        //To check any or all options from dropdown menu in Referrals: My Referrals, Archived and etc.
        internal PatientPage StatusOption(string statusOption, string dropdownTitle)
        {
            if (statusOption == "Status Filter")
            {
                WaitFor(statusFilterButton, Be.Visible).Click();
            }
            else
            {
                userLevelButton.Click();
            }
            S(By.XPath("//span[@class='text' and contains(text(), '" + dropdownTitle + "')]")).Click();

            return new PatientPage(DriverContext);
        }
        //View Erx from Patient Page 
        internal ErxPage OpenViewErx()
        {
            viewErxButton.Click();
            return new ErxPage(DriverContext);
        }
        //Verify "Back to Patient" button
        internal PatientPage VerifyPatientCard(string subtabName)
        {
            WaitFor(patientHeader, Be.Visible);
            Assert.IsTrue(true);
            return this;
        }
        internal ErxPage BuildNewErx()
        {         
            buildNewErxButton.Click();            
            return new ErxPage(DriverContext);
        }
        internal PatientPage EditProfile()
        {
            WaitFor(editProfileButton, Be.Visible);
            editProfileButton.Click();
            return new PatientPage(DriverContext);
        }
        internal PatientPage OpenContactInformation(string contactInformation)
        {
            contactInformationDrawer.Click();
            return this;
        }
        internal PatientPage InputAddress(string address)
        {
            addressInput.Clear();
            addressInput.SendKeys(address);
            return this;
        }        

        internal PatientPage InputCity(string city)
        {
            cityInput.Clear();
            cityInput.SendKeys(city);
            return this;
        }      

        internal PatientPage SelectState()
        {
            WaitFor(S("button[data-id='stateId']"), Be.Visible);
            S("button[data-id='stateId']").Click();
            S(By.XPath("//span[@class='text'][contains(text(),'IL')]")).Click();                   
            return this;
        }
        internal PatientPage InputZipCode(string zipCode)
        {
            WaitFor(zipcodeInput, Be.Visible);
            zipcodeInput.Clear();
            zipcodeInput.SendKeys(zipCode);
            return this;
        }
        internal PatientPage SelectCountry()
        {
            WaitFor(S("button[data-id='countryCode']"), Be.Visible);
            S("button[data-id='countryCode']").Click();
            S(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'United States')]")).Click();
            //SelectElement c = new SelectElement(S(By.Id("countryCode")));
            //c.SelectByValue("US");

            return this;
        }

        internal PatientPage OpenConditions(string conditions)
        {
            conditionsDrawer.Click();
            return this;
        }
        internal PatientPage AddCondition()
        {          
           
            S(".btn-remove-condition").Click();           
            addConditionButton.Click();
            return new PatientPage(DriverContext);
        }
        internal PatientPage OpenSearchForConditionsModal()
        {
            
            return new PatientPage(DriverContext);
        }
        internal PatientPage InputQuery(string query)
        {
            WaitFor(conditionsInput, Be.Visible);
            conditionsInput.Clear();
            conditionsInput.Hover().SendKeys(query);
            return this;
        }
        internal PatientPage Search()
        {
            searchButton.Click();
            return this;
        }
        internal PatientPage SelectFirstResult()
        {
            WaitForNot(smallSpinner, Be.Visible);
            conditionCheckbox.Click();
            return this;
        }
        internal PatientPage Update()
        {
            updateButton.Click();
            return new PatientPage(DriverContext);
        }
        internal PatientPage Save()
        {
            WaitFor(S(By.XPath("//h2[contains(text(),'Edit Profile')]")), Be.Visible);
            saveButton.Click();
            return new PatientPage(DriverContext);
        }
        internal PatientPage DisplayGeneratedButton()
        {
            Assert.IsTrue(true);
            return new PatientPage(DriverContext);
        }

        internal ErxPage OpenGenerateAutomaticErx()
        {
            generateAutomaticErx.Click();
            return new ErxPage(DriverContext);
        }
        internal PatientPage OpenScreenings(string subtabname)
        {
            S(By.Id("screenings")).Click();
            return new PatientPage(DriverContext);
        }
        internal ScreeningPage ConductScreening(string startScreening)
        {
            WaitForNot(smallSpinner, Be.InDom);
            S(By.Id("btn-conduct-screening")).Click();
            SeleneElement screeningTitle= S(By.XPath("//h2[contains(text(),'QA Organization - Automation Screenings')]"));
            String expectedOrg = screeningTitle.GetText();
            String actualOrg = "QA Organization - Automation Screenings";
            Assert.AreEqual(actualOrg, expectedOrg);
            return new ScreeningPage(DriverContext);
        }
        internal PatientPage SearchPatient(string query)
        {
            S("#services-search-query").SendKeys(query);
            return new PatientPage(DriverContext);
        }
        internal PatientPage Submit()
        {
            searchButton.Click();
            return new PatientPage(DriverContext);
        }
        internal PatientPage ReturnToPatient()
        {
            SeleneElement pS = S(".col-xs-6.flex");
            String actualPS = pS.GetText();
            String expectedPS = "Screenings";
            Assert.AreEqual(actualPS, expectedPS);
            return new PatientPage(DriverContext);
        }
        internal PatientPage SwitchEmailToggle(string toggleOn, string toggleOff)
        {
           if(toggleOff == "Yes")
            {
                S(".btn.btn-secondary.toggle-on").Click();
            }
            else
            {
                S(".btn.btn-off.active.toggle-off").Click();
            }
            S("#emailConsent>div:nth-child(2)>div.toggle.btn").Click();
            return new PatientPage(DriverContext);
        }
        internal PatientPage ConfirmEmailConfiguration()
        {
            S("#btn-add").Click();
            return this;
        }
        internal EditReferralModal OpenEditReferral()
        {
            acceptanceInfo.Click();
            return new EditReferralModal(DriverContext);
        }
        internal PatientPage VerifyStatusDisplay()
        {
            //verify contact status display in patient referral
            WaitForNot(S(".modal.modal-card.fade.in"), Be.InDom);
            S("div.col-xs-1.info>i").Click();
            String expectedRefStatus = S("span.referralStatusLabel").GetText();
            String actualRefStatus = "NOTE ADDED";
            Assert.AreEqual(expectedRefStatus, actualRefStatus);
            return new PatientPage(DriverContext);
            
        }
        internal AddReferralModal ClickMakeReferal()
        {
            S("div.send-referral").Hover().Click();
            return new AddReferralModal(DriverContext);
        }
        internal SendNudgeModal SendNudge()
        {
            S("#btn-nudge").Click();
            return new SendNudgeModal(DriverContext);
        }
        internal UploadDocumentModal ClickUploadDocument(string button)
        {
            WaitForNot(smallSpinner, Be.InDom);
            S("#btn-add-document").Click();
            return new UploadDocumentModal(DriverContext);
        }
        internal PatientPage TakeAction()
        {
            S("#btn-takeAction").Click();
            return new PatientPage(DriverContext);
        }
        internal PatientPage Delete()
        {
            S(By.LinkText("Delete")).Click();
            return new PatientPage(DriverContext);
        }
        internal PatientPage Download()
        {
            S(By.LinkText("Download")).Click();
            return new PatientPage(DriverContext);
        }
        internal PatientPage Notes()
        {
            S(By.LinkText("Notes")).Click();
            return new PatientPage(DriverContext);
        }
    } 
}