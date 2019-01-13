using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
namespace ManarMall.Model
{
    public class CustomerDeskPageContentController : SurfaceController
    {

        public ActionResult RenderCustomerDeskPageContent()
        {

            return PartialView("~/Views/Partials/CustomerDeskPageContent/CustomerDeskPageContent.cshtml");
        }
    }
}