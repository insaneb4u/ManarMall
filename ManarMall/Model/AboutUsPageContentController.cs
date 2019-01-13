using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class AboutUsPageContentController : SurfaceController
    {
        public ActionResult RenderAboutUsPageContent()
        {

            return PartialView("~/Views/Partials/AboutUsPageContent/AboutUsPageContent.cshtml");
        }
    }
}