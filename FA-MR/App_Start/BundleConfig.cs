using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FA_MR
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection pBC)
        {
            pBC.IgnoreList.Clear();
            #region Style
            pBC.Add(new StyleBundle("~/Content/localstyle").Include(
                        "~/Content/Site.css*",
                        "~/Content/Account.css*",
                        "~/Content/Padding.css*"));
            #endregion
            #region Script
            pBC.Add(new ScriptBundle("~/Scripts/localscript").Include(
                "~/Scripts/Script_Start/ScriptConfig.js*",
                "~/Scripts/Service/Dailog.js*",
                "~/Scripts/Service/Table.js*",
                "~/Scripts/Request/ReportsHttp.js*",
                "~/Scripts/Request/FixedAssetsHttp.js*",
                "~/Scripts/Request/EmployeesHttp.js*",
                "~/Scripts/Request/MRHttp.js*",
                "~/Scripts/Controller/Account.js*",
                "~/Scripts/Controller/FixedAssets.js*",
                "~/Scripts/Controller/AssignedAssets.js*",
                "~/Scripts/Controller/Disposed.js*",
                "~/Scripts/Controller/FixedAssetsMovement.js*"
                ));
            #endregion
            BundleTable.EnableOptimizations = false;
        }
    }
}