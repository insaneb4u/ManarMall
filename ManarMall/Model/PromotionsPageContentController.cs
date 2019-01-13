using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
namespace ManarMall.Model
{
    public class PromotionsPageContentController : SurfaceController
    {
        public ActionResult RenderPromotionsPageContent()
        {

            return PartialView("~/Views/Partials/PromotionsPageContent/PromotionsPageContent.cshtml");
        }
    }
}