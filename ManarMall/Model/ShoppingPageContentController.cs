﻿using ManarMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;


namespace ManarMall.Model
{
    public class ShoppingPageContentController : SurfaceController
    {
        public ActionResult RenderShoppingPageContent()
        {
            return PartialView("~/Views/Partials/ShoppingPageContent/ShoppingPageContent.cshtml");
        }


    }
}