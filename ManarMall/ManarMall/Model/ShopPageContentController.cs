using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class ShopPageContentController : SurfaceController
    {
        public ActionResult RenderShopPageContent()
        {
            return PartialView("~/Views/Partials/ShopPageContent/ShopPageContent.cshtml");
        }

    }
}