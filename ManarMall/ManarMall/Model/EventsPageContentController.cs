using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class EventsPageContentController : SurfaceController
    {
        public ActionResult RenderEventsPageContent()
        {
            return PartialView("~/Views/Partials/EventsPageContent/EventsPageContent.cshtml");
        }

    }
}