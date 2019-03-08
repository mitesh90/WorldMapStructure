using WorldMap.MVC.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WorldMap.MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region UI Plugin

            bundles.Add(new ScriptBundle(BundleConstants.JQueryBootStrap));

            #endregion

            #region CSS Bundle

            bundles.Add(new StyleBundle(BundleConstants.BootStrapCSSBundle).Include(
                        BundleConstants.BootStrapCSS,
                        BundleConstants.BootStrapResponsiveCSS));

            #endregion

        }
    }
}