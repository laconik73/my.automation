using System;
using System.Globalization;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using Ocaramba.Extensions;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;
using Nowpow.Automation.Features.StepDefinitions;
using System.Collections.Generic;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class UserManagement : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement userRolesFilter = S(".filter-dropdown-container");
        IList<IWebElement> actionButton = SS(".take-action-dropdown");
        SeleneElement activateButton = S(".reactivate-btn");
        SeleneElement deactivateAction = S(By.PartialLinkText("Deactiva"));
        SeleneElement resendPasswordAction = S(By.PartialLinkText("Resend Passwo"));
        SeleneElement viewEditAction = S(By.PartialLinkText("View/Ed"));      
        IList<IWebElement> confirmButton = SS(".modal-footer button");
        SeleneElement addUsersButton = S("button[class*='add-users-button']");


        public UserManagement(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal UserManagement OpenFilter(string userRoles)
        {
            userRolesFilter.Hover().Click();                        
            return this;
        }

        internal UserManagement TakeAction()
        {
            actionButton.ElementAt(0).Click();
            return this;
        }

        internal UserManagement Activate()
        {
            activateButton.Hover().Click();
            return new UserManagement(DriverContext);
        }

        internal UserManagement DeactivateUser(string action)
        {
            deactivateAction.Hover().Click();
            return new UserManagement(DriverContext);
        }

        internal UserManagement ViewEditUser()
        {
            viewEditAction.Hover().Click();
            return new UserManagement(DriverContext);
        }
        
        internal UserManagement ResendPassword()
        {
            resendPasswordAction.Hover().Click();
            return new UserManagement(DriverContext);
        }

        internal UserManagement ConfirmAction(string modal)
        {
            modal = S(".modal-header h5").Text;            
            Console.WriteLine(modal.ToString());            

            try
            {
                confirmButton.ElementAt(1).Click();
            }
            catch(Exception e)
            {
                confirmButton.ElementAt(1).Click();
            }
            
            return new UserManagement(DriverContext);
        }
        internal AddUserModal AddUsers(string button)
        {
            addUsersButton.Hover().Click();
            return new AddUserModal(DriverContext);
        }
    }
}

