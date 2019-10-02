using System;
using System.Configuration;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NSelene;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class KioskSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        public KioskSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [When(@"user searches for services")]
        public void WhenUserSearchesForServices()
        {
            new KioskPage(driverContext)
                .SelectServiceCategory()
                .SelectProgram()
                .UseCurrentLocation()
                .FindResources();
        }        
        
        [When(@"user navigates to Get Directions page")]
        public void WhenUserNavigatesToGetDirectionsPage()
        {
            new KioskPage(driverContext).ClickGetDirections();
            Assert.IsTrue(S("ul.nav.nav-pills").Displayed);
        }
        [When(@"user selects transportation options")]
        public void WhenUserSelectsTransportationOptions()
        {
            new KioskPage(driverContext)
                .GetCarDirections()
                .GetPublicTransitDirections()
                .GetWalkingDirections()
                .GetBikingDirections();
            Assert.IsTrue(S("#directions-panel").Displayed);
        }
        [Then(@"'(.*)' and '(.*)' are updated to the transportation method selected")]
        public void ThenAndAreUpdatedToTheTransportationMethodSelected(string directions, string map)
        {
            new KioskPage(driverContext);
            if (directions == map)
            {

                Assert.IsTrue(S("div.kiosk-service-card").Displayed);
               
                Assert.AreEqual(directions, map);

            }
            else if(map!= directions)
             {
                
                Assert.IsFalse(S("#map").Displayed);
                Assert.AreNotSame(directions, map);
             }
            
        }
    }
}
