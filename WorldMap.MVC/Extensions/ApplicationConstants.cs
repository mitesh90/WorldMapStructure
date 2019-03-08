using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WorldMap.MVC.Extensions
{
    public class ApplicationConstants
    {
        #region Constants

        public int MaximumNumberOfInvalidLoginAttempts = 60;
        public int DaysUntilPasswordChangeRequired = 5;
        public int DaysUntilNewPasswordShouldNotMatchInHistory = 10;
        public int StartPasswordChangeNotificationBy = 10;
        public int MaxInActiveDaysPeriod = 10;
        public int PrescriptionExpireInNoOfYears = 10;

        #endregion

        public ApplicationConstants()
        {
            int.TryParse(ConfigurationManager.AppSettings["MaximumNumberOfInvalidLoginAttempts"], out MaximumNumberOfInvalidLoginAttempts);
            int.TryParse(ConfigurationManager.AppSettings["DaysUntilPasswordChangeRequired"], out DaysUntilPasswordChangeRequired);
            int.TryParse(ConfigurationManager.AppSettings["DaysUntilNewPasswordShouldNotMatchInHistory"], out DaysUntilNewPasswordShouldNotMatchInHistory);
            int.TryParse(ConfigurationManager.AppSettings["StartPasswordChangeNotificationBy"], out StartPasswordChangeNotificationBy);
            int.TryParse(ConfigurationManager.AppSettings["MaxInActiveDaysPeriod"], out MaxInActiveDaysPeriod);
            int.TryParse(ConfigurationManager.AppSettings["PrescriptionExpireInNoOfYears"], out PrescriptionExpireInNoOfYears);
        }
    }
}