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
    public class LeasingPageContentController : SurfaceController
    {
        public ActionResult RenderLeasingPageContent()
        {

            return PartialView("~/Views/Partials/LeasingPageContent/LeasingPageContent.cshtml");
        }


        public ActionResult SubmitData()
        {
            string msg = "";
            string send1 = Request["send"];
            string name = send1.Split('~')[0];
            string mobile = send1.Split('~')[1];
            string email = send1.Split('~')[2];
            string company = send1.Split('~')[3];
            SqlConnection con = new SqlConnection("Data Source=ASUS-PC/imran;Initial Catalog=ManarMall;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_enquiryTBL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@company", company);
            cmd.ExecuteNonQuery();
            con.Close();

            return Json(msg);
        }
    }
}