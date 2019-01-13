using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class OffersPageContentController : SurfaceController
    {
        public ActionResult RenderOffersPageContent()
        {
            return PartialView("~/Views/Partials/OffersPageContent/OffersPageContent.cshtml");
        }

    }
}