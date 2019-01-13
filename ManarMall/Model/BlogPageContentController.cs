using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class BlogPageContentController : SurfaceController
    {
        public ActionResult RenderBlogPageContent()
        {

            return PartialView("~/Views/Partials/BlogPageContent/BlogPageContent.cshtml");
        }
    }
}