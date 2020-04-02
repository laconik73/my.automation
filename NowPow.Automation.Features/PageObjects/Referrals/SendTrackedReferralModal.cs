using System.Threading;
using NLog;
using NSelene;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using static NSelene.Selene;
using Ocaramba;
using System;
using Nowpow.Automation.Features.PageObjects;
using Nowpow.Automation.Features.StepDefinitions;
using System.Collections;
using System.Collections.Generic;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class SendTrackedReferralModal : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();


        public SendTrackedReferralModal(DriverContext driverContext) : base(driverContext)
        {
            
        }

        internal SendTrackedReferralModal DisplayServicesWithinTheNetwork()
        {
            IList<IWebElement> services = SS("#services-container a");
            IList<string> networkServices = new List<string>();
            foreach (IWebElement element in services)
            {
                networkServices.Add(element.ToString());
                
            }

            return this;
        }
    }
}