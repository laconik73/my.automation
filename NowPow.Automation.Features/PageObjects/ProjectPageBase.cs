namespace NowPow.Automation.PageObjects
{
    using NSelene;
    using OpenQA.Selenium;
    using static NSelene.Selene;
    using Ocaramba;

    public partial class ProjectPageBase
    {
       protected SeleneElement smallSpinner = S("#spinnerSmall");
        protected SeleneElement spinner = S("#spinner");
        
        
        public ProjectPageBase(DriverContext driverContext)
        {
            this.DriverContext = driverContext;
            this.Driver = driverContext.Driver;           

        }
      protected IWebDriver Driver { get; set; }
        public DriverContext DriverContext { get; set; }
             
    }

}
