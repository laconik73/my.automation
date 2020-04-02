using System;
using System.Configuration;
using System.Globalization;
using NLog;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using Ocaramba.Extensions;
using static NSelene.Selene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    public class SLSLoginPage: ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement usernameTextbox = S("#username");
        SeleneElement passwordTextbox = S("#password");
        SeleneElement submitButton = S("input[type='submit']");

        public SLSLoginPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        internal SLSLoginPage GoTo(string sls)
        {
            var sls_url = ConfigurationManager.AppSettings["sls_url"];
            this.Driver.NavigateTo(new Uri(sls));
            Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", sls_url);
            return this;
        }

        internal SLSLoginPage EnterUsername(string email)
        {
            usernameTextbox.SendKeys(email);
                return this;
        }

        internal SLSLoginPage EnterPassword(string password)
        {
            passwordTextbox.SendKeys(password);
            return this;
        }

        internal SLSOrganizationPage LoginButton()
        {
            submitButton.Click();
            return new SLSOrganizationPage(DriverContext);
        }
    }
}