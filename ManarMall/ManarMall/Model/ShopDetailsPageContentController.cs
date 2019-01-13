using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class ShopDetailsPageContentController : SurfaceController
    {
        public ActionResult RenderShopDetailsPageContent()
        {
            return PartialView("~/Views/Partials/ShopDetailsPageContent/ShopDetailsPageContent.cshtml");
        }

    }
}