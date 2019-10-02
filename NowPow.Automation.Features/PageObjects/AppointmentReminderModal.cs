using NLog;
using NowPow.Automation.PageObjects;
using Ocaramba;
using System;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class AppointmentReminderModal:ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        public AppointmentReminderModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
    }
}