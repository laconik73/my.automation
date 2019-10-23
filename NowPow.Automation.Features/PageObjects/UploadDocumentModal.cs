using NLog;
using NowPow.Automation.PageObjects;
using Ocaramba;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class UploadDocumentModal: ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        public UploadDocumentModal(DriverContext driverContext) : base(driverContext)
        {
            
        }
    }
}