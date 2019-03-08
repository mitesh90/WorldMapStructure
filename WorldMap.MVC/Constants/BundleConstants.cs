using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldMap.MVC.Constants
{
    public class BundleConstants
    {
        #region BaseBundle

        public const string JQueryAllVersions = "~/Scripts/jquery-{version}.js";

        #endregion

        #region UI Plugins

        public const string JQueryBootStrap = "~/Scripts/Bootstrap/bootstrap*";

        #endregion

        #region CSS Bundle

        public const string BootStrapCSSBundle = "~/Content/Bootstrap/css";
        public const string BootStrapCSS = "~/Content/Bootstrap/bootstrap.css";
        public const string BootStrapResponsiveCSS = "~/Content/Bootstrap/bootstrap-responsive.css";

        #endregion
    }
}