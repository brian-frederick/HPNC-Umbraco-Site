using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;
using HPNC_Website.Models;
using System.Web.Mvc;
using Archetype.Models;

namespace HPNC_Website.Controllers
{
    public class HomeSurfaceController: SurfaceController 
    {
        public ActionResult RenderFeaturedContent()
        {
            List<FeaturedContent> featuredContentList = new List<FeaturedContent>();

            List<FeaturedContent> model = new List<FeaturedContent>();
            const int HOME_PAGE_POSITION_IN_PATH = 1;
            int homePageId = int.Parse(CurrentPage.Path.Split(',')[HOME_PAGE_POSITION_IN_PATH]);
            IPublishedContent homePage = Umbraco.Content(homePageId);
           // ArchetypeModel featuredContent = homePage.GetProperty("featuredContent");

            return PartialView("~/Views/Partials/_featuredContent.cshtml", featuredContentList);
        }
    }
}