using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
namespace ManarMall.Model
{
    public class GiftsPageContentController : SurfaceController
    {
        public ActionResult RenderGiftsPageContent()
        {

            return PartialView("~/Views/Partials/GiftsPageContent/GiftsPageContent.cshtml");
        }
    }
}