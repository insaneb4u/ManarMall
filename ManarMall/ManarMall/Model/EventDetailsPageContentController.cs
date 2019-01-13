using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class EventDetailsPageContentController : SurfaceController
    {
        public ActionResult RenderEventDetailsPageContent()
        {

            return PartialView("~/Views/Partials/EventDetailsPageContent/EventDetailsPageContent.cshtml");
        }

    }
}