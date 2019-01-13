using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class StoreLocatorContentPageController : SurfaceController
    {
        public ActionResult RenderStoreLocatorContent() 
        {
            return PartialView("~/Views/Partials/StoreLocatorContentPage/StoreLocatorContentPage.cshtml");
        }

    }
}