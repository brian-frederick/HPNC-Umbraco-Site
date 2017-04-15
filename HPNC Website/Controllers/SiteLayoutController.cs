using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace HPNC_Website.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        private const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/SiteLayout/";
        public ActionResult RenderHeader()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_header.cshtml");
        }

        public ActionResult RenderFooter()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_footer.cshtml");
        }
    }
}