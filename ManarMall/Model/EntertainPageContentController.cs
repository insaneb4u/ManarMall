using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ManarMall.Model
{
    public class EntertainPageContentController : SurfaceController
    {
        public ActionResult RenderEntertainPageContent()
        {

            return PartialView("~/Views/Partials/EntertainPageContent/EntertainPageContent.cshtml");
        }




        public JsonResult Filterdata()
        {
            string msg = "";
            string connnect = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;
            SqlConnection con = new SqlConnection(connnect);

            con.Open();
            string query = "SELECT * FROM [dbo].[cmsContentXml]  WHERE nodeId = 8707";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string xml = "";
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                xml = row["xml"].ToString();
                string xml2 = xml.Substring(414);
                string xml3 = xml2.Replace("></brandImage1></events>", "");
                var data = xml3.Substring(0, xml3.Length - 276);


            //    var objects = JArray.Parse(data); // parse as array  


                /* var items = JObject.Parse(data)["eventStartDate"]
                    .Children<JProperty>()
                    .Where(jp => jp.Name.StartsWith("eventStartDate"))
                    .Select(jp => (JObject)jp.Value)
                    .ToList();

                 foreach (var item in items)
                 {
                     foreach (var kvp in item)
                     {
                         Console.WriteLine(kvp.Key + ": " + kvp.Value);
                     }
                     Console.WriteLine();
                 }*/

               /* var resultObject = objects["0"].Values("eventStartDate").Value<string>() == "2018-12-01 00:00:00";

                foreach (JObject data3 in objects)
                {

                   var startdate = data3.GetValue("eventStartDate").ToString();
                   var Enddate = data3.GetValue("eventEndDate").ToString();


                }*/
                return Json(data);
            }

            return Json(msg);
        }
    }
}