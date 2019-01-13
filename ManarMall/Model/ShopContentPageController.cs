using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class ShopContentPageController : SurfaceController
    {
        public ActionResult RenderShopContentPage()
        {
            return PartialView("~/Views/Partials/ShopContentPage/ShopContentPage.cshtml");
        }

    }
}