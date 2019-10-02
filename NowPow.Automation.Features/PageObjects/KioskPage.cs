using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using static NSelene.Selene;
using NLog;
using System;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class KioskPage: ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement categoryList = S("#divCategoriesList>div:nth-child(1)");
        SeleneElement typesList = S("#divTypesList>div:nth-child(1)");
        SeleneElement curLocationButton = S("#btn-curLocation");
        SeleneElement continueButton = S("#btn-continue");
        SeleneElement directionsButton = S("#btn-directions_24236");
        SeleneElement drivingButton = S("button[data-transit-type='DRIVING']");
        SeleneElement transitButton = S("button[data-transit-type='TRANSIT']");
        SeleneElement walkingButton = S("button[data-transit-type='WALKING']");
        SeleneElement bicyclingButton = S("button[data=transit-type='BICYCLING']");



        public KioskPage(DriverContext driverContext) : base(driverContext)
        {
            
        }

        internal KioskPage SelectServiceCategory()
        {
            categoryList.Click();
            return new KioskPage(DriverContext);
        }

        internal KioskPage SelectProgram()
        {
            typesList.Click();
            return new KioskPage(DriverContext);
        }       

        internal KioskPage UseCurrentLocation()
        {
            curLocationButton.Click();
            return new KioskPage(DriverContext);
        }      

        internal KioskPage FindResources()
        {
            continueButton.Click();
            return new KioskPage(DriverContext);
        }        

        internal KioskPage ClickGetDirections()
        {
            directionsButton.Click();
            return new KioskPage(DriverContext);
        }
        internal KioskPage GetCarDirections()
        {
            drivingButton.Click();
            return new KioskPage(DriverContext);
        }
        internal KioskPage GetPublicTransitDirections()
        {
            transitButton.Click();
            return new KioskPage(DriverContext);
        }
        internal KioskPage GetWalkingDirections()
        {
            walkingButton.Click();
            return new KioskPage(DriverContext);
        }
        internal KioskPage GetBikingDirections()
        {
            bicyclingButton.Click();
            return new KioskPage(DriverContext);
        }
    }
}