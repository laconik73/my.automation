namespace NowPow.Automation.Features
{
    using System;   
    using static NSelene.Selene;
    using TechTalk.SpecFlow;
    using Ocaramba;
    using Ocaramba.Logger;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using OpenQA.Selenium.Chrome;
    using System.Configuration;

    /// <summary>
    /// The base class for all tests <see href="https://github.com/ObjectivityLtd/NowPow/wiki/ProjectTestBase-class">More details on wiki</see>
    /// </summary>
    [Binding]
    public class ProjectTestBase : TestBase
    {
        private readonly ScenarioContext scenarioContext;
        private DriverContext driverContext = new DriverContext();
        private string BrowserConfig => ConfigurationManager.AppSettings["browser"];

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectTestBase"/> class.
        /// </summary>
        /// <param name="scenarioContext"> Scenario Context </param>
        public ProjectTestBase(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Gets or sets logger instance for driver
        /// </summary>
        public TestLogger LogTest
        {
            get
            {
                return this.DriverContext.LogTest;
            }

            set
            {
                this.DriverContext.LogTest = value;
            }
        }

        /// <summary>
        /// Gets the browser manager
        /// </summary>
        protected DriverContext DriverContext
        {
            get
            {
                return this.DriverContext1;
            }
            set { this.DriverContext1 = value; }
        }

        public object TimeUnit { get; private set; }
        public ChromeDriver driver { get; private set; }
        public DriverContext DriverContext1 { get => driverContext; set => driverContext = value; }

        /// <summary>
        /// Before the class.
        /// </summary>
        [BeforeFeature]
        public static void BeforeClass()
        { 
            
        }

        /// <summary>
        /// After the class.
        /// </summary>
        [AfterFeature]
        public static void AfterClass(FeatureContext featureContext)
        {
            //((DriverContext)(featureContext["DriverContext"])).Stop();
        }

        /// <summary>
        /// Before the test.
        /// </summary>
        [Before]
        public void BeforeTest(FeatureContext featureContext)
        {
            this.DriverContext.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.DriverContext.TestTitle = this.scenarioContext.ScenarioInfo.Title;
            this.LogTest.LogTestStarting(this.DriverContext1);

            if (BrowserConfig == BrowserType.RemoteWebDriver.ToString())
            {
                SetBrowserStack();
            }
            else
            {
                this.DriverContext.Start();
            }

            this.scenarioContext["DriverContext"] = this.DriverContext;
            featureContext["DriverContext"] = this.DriverContext;

            SetWebDriver(DriverContext.Driver);
            DriverContext.Driver.Manage().Window.Maximize();


        }

        public void SetBrowserStack()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("browserName", "firefox");

            IWebDriver dr = new RemoteWebDriver(new Uri("http://52.165.22.223:4444/wd/hub"), capabilities);
            //DesiredCapabilities capabilities = new DesiredCapabilities();
            //capabilities.SetCapability("browserName", "Chrome");
            //capabilities.SetCapability("browserVersion", "76.0");
            //capabilities.SetCapability("resolution", "1920x1080");
            //Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            //browserstackOptions.Add("os", "Windows");
            //browserstackOptions.Add("osVersion", "10");
            //browserstackOptions.Add("resolution", "1920x1080");
            //browserstackOptions.Add("local", "false");
            //browserstackOptions.Add("seleniumVersion", "3.5.2");
            //browserstackOptions.Add("userName", "semiloreajibola1");
            //browserstackOptions.Add("accessKey", "Nb5FsLPHpy9peecC1Cpw");
            //capabilities.SetCapability("bstack:options", browserstackOptions);

            //IWebDriver dr = new RemoteWebDriver(
            //  new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capabilities
            //);
            //dr.Manage().Window.Maximize();
            //dr.Navigate().GoToUrl("http://www.google.com");
        }

        /// <summary>
        /// After the test.
        /// </summary>
        [After]
        public void AfterTest()
        {
            try
            {
                this.DriverContext.IsTestFailed = this.scenarioContext.TestError != null || !this.DriverContext1.VerifyMessages.Count.Equals(0);
                var filePaths = this.SaveTestDetailsIfTestFailed(this.DriverContext1);
                this.SaveAttachmentsToTestContext(filePaths);
                var javaScriptErrors = this.DriverContext.LogJavaScriptErrors();

                this.LogTest.LogTestEnding(this.DriverContext1);
                if (this.IsVerifyFailedAndClearMessages(this.DriverContext1) && this.scenarioContext.TestError == null)
                {
                    Assert.Fail();
                }

                if (javaScriptErrors)
                {
                    Assert.Fail("JavaScript errors found. See the logs for details");
                }
            }
            finally
            {
                // the context should be cleaned up no matter what
                this.DriverContext.Stop();
            }
        }

        private void SaveAttachmentsToTestContext(string[] filePaths)
        {
            if (filePaths != null)
            {
                foreach (var filePath in filePaths)
                {
                    this.LogTest.Info("Uploading file [{0}] to test context", filePath);
                    TestContext.AddTestAttachment(filePath);
                }
            }
        }
    }
}
