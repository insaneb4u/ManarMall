﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class DinePageContentController : SurfaceController
    {
        public ActionResult RenderDinePageContent()
        {

            return PartialView("~/Views/Partials/DinePageContent/DinePageContent.cshtml");
        }
    }
}