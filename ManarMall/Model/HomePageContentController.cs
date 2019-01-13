using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class HomePageContentController : SurfaceController
    {
        public ActionResult RenderHomePageContent()
        {
            return PartialView("~/Views/Partials/HomePageContent/HomePageContent.cshtml");
        }
    }
}