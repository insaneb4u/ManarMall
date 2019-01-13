using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace ManarMall.Model
{
    public class BlogDetailsPageContentController : SurfaceController
    {
        public ActionResult RenderBlogDetailsDetailsPageContent()
        {

            return PartialView("~/Views/Partials/BlogDetailsPageContent/BlogDetailsPageContent.cshtml");
        }

         public ActionResult SubmitData()
        {
            string send1 = Request["send"];
            string msg = "subscribed....!";
            SqlConnection con = new SqlConnection("Data Source=ASUS-PC/imran;Initial Catalog=ManarMall;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_BlogNewsLetterEmail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", send1);
            cmd.ExecuteNonQuery();
            con.Close();

            return Json(msg);
        }

    }
}