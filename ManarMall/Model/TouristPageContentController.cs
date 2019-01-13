using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class TouristPageContentController : SurfaceController
    {
        public  ActionResult RenderTouristPageContent()
        {
            return PartialView("~/Views/Partials/TouristPageContent/TouristPageContent.cshtml");
        }

    }
}