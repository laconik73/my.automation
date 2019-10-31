using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class ServiceSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        String note;


        public ServiceSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }


        [When(@"user chooses tab '(.*)'")]
        public void WhenUserChoosesTab(string tabName)
        {
            new DashboardPage(driverContext).OpenServices(tabName);
        }

        [When(@"user  chooses  '(.*)'")]
        public void WhenUserChooses(string favoriteServices)
        {
            new ServicePage(driverContext).OpenFavoriteService();
        }
        [When(@"user searches for the organization in coordinated network")]
        public void WhenUserSearchesForTheOrganizationInCoordinatedNetwork()
        {
            new ServicePage(driverContext)
                .SearchServices("moore")
                .Submit()
                .ClickServiceLink();
        }
        [When(@"user click on button '(.*)'")]
        public void WhenUserClickOnButton(string Refer)
        {
            new ServicePage(driverContext).Refer();

        }

        [When(@"user refers patient information with a note")]
        public void WhenUserRefersPatientInformationWithANote()
        {
            note = DateTime.Now.Ticks.ToString();
            var modal = new MakeReferralModal(driverContext).MakeReferral();
            modal.PatientMrn("john")
                .SelectFirstDataset()
                .WriteNote(note)
                .SelectCheckbox()
                .Send();
        }
        [Then(@"referral is made")]
        public void ThenReferralIsMade()
        {
            new ServicePage(driverContext);
            String expectedReferral = S(By.XPath("//h4[contains(text(),'Service Offerings')]")).GetText();
            string actualReferral = "Service Offerings";
            Assert.AreEqual(expectedReferral, actualReferral);
        }
        [When(@"user searches for a '(.*)'")]
        public void WhenUserSearchesForA(string serviceType)
        {
            new ServicePage(driverContext)
                .InputServiceType("dental")
                .Submit();
        }
        [When(@"user applies filters")]
        public void WhenUserAppliesFilters()
        {
            new ServicePage(driverContext)
                .OpenFilters()
                .SelectFeeStructure()
                .ApplyFilters();
        }
        [When(@"user changes radius")]
        public void WhenUserChangesRadius()
        {
            new ServicePage(driverContext)
                .ChangeRadius()
                .SelectRadius();
        }
        [When(@"user changes zip code")]
        public void WhenUserChangesZipCode()
        {
            new ServicePage(driverContext)
                .ChangeZipCode("60618")
                .UpdateResults();
        }
        [When(@"user changes '(.*)' options")]
        public void WhenUserChangesOptions(string relevance)
        {
            new ServicePage(driverContext).SortOptions(relevance);
        }
        [Then(@"the search results are updated")]
        public void ThenTheSearchResultsAreUpdated()
        {
            new ServicePage(driverContext);
            Assert.IsTrue(S("#query-results-text").IsDisplayed());
        }
        [When(@"user favorites the service")]
        public void WhenUserFavoritesTheService()
        {
            new ServicePage(driverContext).FavoriteTheService();
            
        }
        [Then(@"service is favorited and added")]
        public void ThenServiceIsFavoritedAndAdded()
        {
            new ServicePage(driverContext);

            IList<IWebElement> contents = SS(".content");
            contents.Count();
            Console.WriteLine(contents.Count());
        }
        [Then(@"user unfavorites the service")]
        public void ThenUserUnfavoritesTheService()
        {
            new ServicePage(driverContext)
              .OpenServices()
              .UnfavoriteTheService();
        }
               
        [Then(@"service is unfavorited and removed")]
        public void ThenServiceIsUnfavoritedAndRemoved()
        {
            new ServicePage(driverContext);
            if(SS(".content").Equals("Manus Dental is no longer your favorite"))
            {
                Assert.IsTrue(S(By.LinkText("Dynamic Dental Services")).Displayed);
            }
            else
            {
                Assert.IsTrue(S(By.LinkText("Manus Dental Hyde Park")).Displayed);
            }         
                  

        }
    }
}


