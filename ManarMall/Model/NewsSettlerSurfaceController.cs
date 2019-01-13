using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Examine.LuceneEngine.SearchCriteria;
using Examine;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Xml;
using Umbraco.Core.Models;
using System.Text;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using System.Collections;

namespace ManarMall.Model
{
    public class NewsSettlerSurfaceController : SurfaceController
    {
        public ActionResult NewsSettler(ContactModel model)
        {
            if (model.NewsSettlerEmail != null)
            {
                SqlConnection con = new SqlConnection("Data Source=ADMIN-PC;Initial Catalog=ManarMall;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_NewsSettlerDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NewsSettlerEmail", model.NewsSettlerEmail);
                cmd.ExecuteNonQuery();
                con.Close();

            }



            return RedirectToCurrentUmbracoUrl();
        }

        public JsonResult LoadSearchDatapramod()
        {
            string send1 = Request["send"];
            string dt1 = send1.Split('~')[0];
            //  string dt2 = "en/"+send1.Split('~')[1];
            //if (dt2 == "en")
            //{
            //    dt2 = "home";
            //}
            Dictionary<string, string> jnodearray = new Dictionary<string, string>();
            jnodearray.Add("1090", "en");
            jnodearray.Add("8221", "shop");
            jnodearray.Add("1114", "dine");
            jnodearray.Add("1116", "entertain");
            jnodearray.Add("8223", "offers");

            jnodearray.Add("5061", "aboutus");
            jnodearray.Add("8703", "customerdesk");
            jnodearray.Add("8697", "blog");
            jnodearray.Add("8698", "storelocator");
            jnodearray.Add("4896", "contactus");
            jnodearray.Add("8706", "leasing");
            string msg = "";
            string jsonText = "";
            string connnect = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;
            SqlConnection con = new SqlConnection(connnect);

            con.Open();
            //string query = "SELECT * FROM [dbo].[cmsContentXml] where nodeId = '" + dt1 + "'";
            string query = "SELECT * FROM [dbo].[cmsContentXml] where nodeId in (1090,8221,1114,1116,5061,8703,8697,8698,4896,8706)";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                JArray jArray = new JArray();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    string xml = "";
                    string nodeId = "";
                    string nodeTypeAlias = "";
                    nodeId = row["nodeId"].ToString();
                    xml = row["xml"].ToString();
                    // To convert an XML node contained in string xml into a JSON string   
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml);
                    jsonText = JsonConvert.SerializeXmlNode(doc);
                    jsonText = jsonText.Replace(@"shopping", "m");
                    jsonText = jsonText.Replace(@"home", "m");
                    jsonText = jsonText.Replace(@"dine", "m");
                    jsonText = jsonText.Replace(@"entertain", "m");
                    jsonText = jsonText.Replace(@"aboutUs", "m");
                    jsonText = jsonText.Replace(@"shopDetails", "m");
                    jsonText = jsonText.Replace(@"shops", "m");
                    jsonText = jsonText.Replace(@"gifts", "m");
                    jsonText = jsonText.Replace(@"promotions", "m");
                    jsonText = jsonText.Replace(@"storeLocator", "m");
                    jsonText = jsonText.Replace(@"shop", "m");
                    jsonText = jsonText.Replace(@"Image", "m");
                    jsonText = jsonText.Replace(@"more", "m");
                    jsonText = jsonText.Replace(@"offers", "m");
                    jsonText = jsonText.Replace(@"bLOG", "m");
                    jsonText = jsonText.Replace(@"BlogDetails", "m");
                    jsonText = jsonText.Replace(@"customerDesk", "m");
                    jsonText = jsonText.Replace(@"storelocator", "m");
                    jsonText = jsonText.Replace(@"contactUs", "m");
                    jsonText = jsonText.Replace(@"leasing", "m");


                    dynamic jsonarray = JObject.Parse(jsonText);
                    var y = jsonarray.m;
                    var description1 = "";
                    var description2 = "";
                    var description3 = "";
                    var description4 = "";
                    var description5 = "";
                    var eventDescription1 = "";
                    var eventDescription2 = "";
                    var brandImage2Description = "";
                    var brandImage3Description = "";
                    var brandImage4Description = "";
                    var brandImage5Description = "";
                    var brandImage6Description = "";
                    var brandImage7Description = "";
                    var brandImage1Text = "";
                    var brandImage2Text = "";
                    var movieDescription1 = "";
                    var movieDescription2 = "";
                    var descriptionTitle1 = "";
                    var descriptionTitle2 = "";
                  
                    var descriptionTitle6 = "";
                    var brandTitle = "";
                    var description1Title = "";
                    var description2Title = "";
                    var manarMall = "";
                    var alHamra = "";
                    var textSliderTitle1 = "";
                    var textSliderDescription1 = "";
                    var description = "";
                    var shopContact = "";
                    var aboutShop = "";
                    var shopLocation = "";
                    var shopTitle = "";
                    var brandm2Text = "";





                    //  var itemToAdd = new JObject();
                    List<searchdata> seachdatalist = new List<searchdata>();
                    // JArray jArray = new JArray();
                    nodeTypeAlias = jnodearray[nodeId];
                    //  nodeTypeAlias = y["@nodeTypeAlias"];
                    string dt2 = "";

                    if (nodeTypeAlias == "en")
                    {
                        dt2 = "";

                    }
                    else
                    {
                        dt2 = "en/" + nodeTypeAlias;
                    }


                    IDictionary<string, JToken> dictionary = y;
                    if (dictionary.ContainsKey("description1"))
                    {
                        //Do things for success
                        description1 = y["description1"]["#cdata-section"];
                        if (description1 != "" || description1 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = description1;
                            itemToAdd["bio"] = description1;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("description2"))
                    {
                        //Do things for success
                        description2 = y["description2"]["#cdata-section"];
                        if (description2 != "" || description2 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = description2;
                            itemToAdd["bio"] = description2;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("description3"))
                    {
                        //Do things for success
                        description3 = y["description3"]["#cdata-section"];
                        if (description3 != "" || description3 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = description3;
                            itemToAdd["bio"] = description3;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("description4"))
                    {
                        //Do things for success
                        description4 = y["description4"]["#cdata-section"];
                        if (description4 != "" || description4 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = description4;
                            itemToAdd["bio"] = description4;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("description5"))
                    {
                        //Do things for success
                        description5 = y["description5"]["#cdata-section"];
                        if (description5 != "" || description5 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = description5;
                            itemToAdd["bio"] = description5;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("eventDescription1"))
                    {
                        //Do things for success
                        eventDescription1 = y["eventDescription1"]["#cdata-section"];
                        if (eventDescription1 != "" || eventDescription1 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = eventDescription1;
                            itemToAdd["bio"] = eventDescription1;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("eventDescription2"))
                    {
                        //Do things for success
                        eventDescription2 = y["eventDescription2"]["#cdata-section"];
                        if (eventDescription2 != "" || eventDescription2 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = eventDescription2;
                            itemToAdd["bio"] = eventDescription2;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("brandImage2Description"))
                    {
                        //Do things for success
                        brandImage2Description = y["brandImage2Description"]["#cdata-section"];
                        if (brandImage2Description != "" || brandImage2Description != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = brandImage2Description;
                            itemToAdd["bio"] = brandImage2Description;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("brandImage3Description"))
                    {
                        //Do things for success
                        brandImage3Description = y["brandImage3Description"]["#cdata-section"];
                        if (brandImage3Description != "" || brandImage3Description != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = brandImage3Description;
                            itemToAdd["bio"] = brandImage3Description;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("brandImage4Description"))
                    {
                        //Do things for success
                        brandImage4Description = y["brandImage4Description"]["#cdata-section"];
                        if (brandImage4Description != "" || brandImage4Description != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = brandImage4Description;
                            itemToAdd["bio"] = brandImage4Description;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("brandImage5Description"))
                    {
                        //Do things for success
                        brandImage5Description = y["brandImage5Description"]["#cdata-section"];
                        if (brandImage5Description != "" || brandImage5Description != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = brandImage5Description;
                            itemToAdd["bio"] = brandImage5Description;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("brandImage6Description"))
                    {
                        //Do things for success
                        brandImage6Description = y["brandImage6Description"]["#cdata-section"];
                        if (brandImage6Description != "" || brandImage6Description != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = brandImage6Description;
                            itemToAdd["bio"] = brandImage6Description;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("brandImage7Description"))
                    {
                        //Do things for success
                        brandImage7Description = y["brandImage7Description"]["#cdata-section"];
                        if (brandImage7Description != "" || brandImage7Description != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = brandImage7Description;
                            itemToAdd["bio"] = brandImage7Description;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("brandImage1Text"))
                    {
                        //Do things for success
                        brandImage1Text = y["brandImage1Text"]["#cdata-section"];
                        if (brandImage1Text != "" || brandImage1Text != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = brandImage1Text;
                            itemToAdd["bio"] = brandImage1Text;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("brandImage2Text"))
                    {
                        //Do things for success
                        brandImage2Text = y["brandImage2Text"]["#cdata-section"];
                        if (brandImage2Text != "" || brandImage2Text != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = brandImage2Text;
                            itemToAdd["bio"] = brandImage2Text;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("movieDescription1"))
                    {
                        //Do things for success
                        movieDescription1 = y["movieDescription1"]["#cdata-section"];
                        if (movieDescription1 != "" || movieDescription1 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = movieDescription1;
                            itemToAdd["bio"] = movieDescription1;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                    if (dictionary.ContainsKey("movieDescription2"))
                    {
                        //Do things for success
                        movieDescription2 = y["movieDescription2"]["#cdata-section"];
                        if (movieDescription2 != "" || movieDescription2 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = movieDescription2;
                            itemToAdd["bio"] = movieDescription2;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("descriptionTitle1"))
                    {
                        //Do things for success
                        descriptionTitle1 = y["descriptionTitle1"]["#cdata-section"];
                        if (descriptionTitle1 != "" || descriptionTitle1 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = descriptionTitle1;
                            itemToAdd["bio"] = descriptionTitle1;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("descriptionTitle2"))
                    {
                        //Do things for success
                        descriptionTitle2 = y["descriptionTitle2"]["#cdata-section"];
                        if (descriptionTitle2 != null)
                        {
                            if (descriptionTitle2 != "" || descriptionTitle2 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = descriptionTitle2;
                            itemToAdd["bio"] = descriptionTitle2;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                        }
                        
                    }

               

                    if (dictionary.ContainsKey("descriptionTitle6"))
                    {
                        //Do things for success
                        descriptionTitle6 = y["descriptionTitle6"]["#cdata-section"];
                        if (descriptionTitle6 != "" || descriptionTitle6 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = descriptionTitle6;
                            itemToAdd["bio"] = descriptionTitle6;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("brandTitle"))
                    {
                        //Do things for success
                        brandTitle = y["brandTitle"]["#cdata-section"];
                        if (brandTitle != "" || brandTitle != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = brandTitle;
                            itemToAdd["bio"] = brandTitle;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("description1Title"))
                    {
                        //Do things for success
                        description1Title = y["description1Title"]["#cdata-section"];
                        if (description1Title != "" || description1Title != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = description1Title;
                            itemToAdd["bio"] = description1Title;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("description2Title"))
                    {
                        //Do things for success
                        description2Title = y["description2Title"]["#cdata-section"];
                        if (description2Title != "" || description2Title != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = description2Title;
                            itemToAdd["bio"] = description2Title;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("manarMall"))
                    {
                        //Do things for success
                        manarMall = y["manarMall"]["#cdata-section"];
                        if (manarMall != "" || manarMall != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = manarMall;
                            itemToAdd["bio"] = manarMall;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("alHamra"))
                    {
                        //Do things for success
                        alHamra = y["alHamra"]["#cdata-section"];
                        if (alHamra != "" || alHamra != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = alHamra;
                            itemToAdd["bio"] = alHamra;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("textSliderTitle1"))
                    {
                        //Do things for success
                        textSliderTitle1 = y["textSliderTitle1"]["#cdata-section"];
                        if (textSliderTitle1 != "" || textSliderTitle1 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = textSliderTitle1;
                            itemToAdd["bio"] = textSliderTitle1;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("textSliderDescription1"))
                    {
                        //Do things for success
                        textSliderDescription1 = y["textSliderDescription1"]["#cdata-section"];
                        if (textSliderDescription1 != "" || textSliderDescription1 != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = textSliderDescription1;
                            itemToAdd["bio"] = textSliderDescription1;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("description"))
                    {
                        //Do things for success
                        description = y["description"]["#cdata-section"];
                        if (description != "" || description != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = movieDescription2;
                            itemToAdd["bio"] = movieDescription2;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("shopContact"))
                    {
                        //Do things for success
                        shopContact = y["shopContact"]["#cdata-section"];
                        if (shopContact != "" || shopContact != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = shopContact;
                            itemToAdd["bio"] = shopContact;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("aboutShop"))
                    {
                        //Do things for success
                        aboutShop = y["aboutShop"]["#cdata-section"];
                        if (aboutShop != "" || aboutShop != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = aboutShop;
                            itemToAdd["bio"] = aboutShop;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("shopLocation"))
                    {
                        //Do things for success
                        shopLocation = y["shopLocation"]["#cdata-section"];
                        if (shopLocation != "" || shopLocation != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = shopLocation;
                            itemToAdd["bio"] = shopLocation;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }

                    if (dictionary.ContainsKey("brandm2Text"))
                    {
                        //Do things for success
                        brandm2Text = y["brandm2Text"]["#cdata-section"];
                        if (brandm2Text != "" || brandm2Text != null)
                        {
                            var itemToAdd = new JObject();
                            itemToAdd["name"] = brandm2Text;
                            itemToAdd["bio"] = brandm2Text;
                            itemToAdd["reknown"] = dt2;
                            itemToAdd["shortname"] = dt2;
                            itemToAdd["pagename"] = nodeTypeAlias;
                            jArray.Add(itemToAdd);
                        }
                    }
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                String returndata = JsonConvert.SerializeObject(jArray, Newtonsoft.Json.Formatting.Indented);
                // String returndata = serializer.Serialize(seachdatalist);


                var imagePath = ConfigurationManager.AppSettings["JsonPath"];
                var physicalPath = Server.MapPath(imagePath);

                string path1 = physicalPath;
                FileInfo fi = new FileInfo(path1);
                using (var tw = new StreamWriter(fi.Open(FileMode.Truncate)))
                {

                    tw.Write(returndata);
                    tw.Close();
                }
            }



            return Json(msg);
        }
        public JsonResult LoadSearchData()
        {
            string send1 = Request["send"];
            string dt1 = send1.Split('~')[0];
            string dt2 = send1.Split('~')[1];
            if (dt2 == "en")
            {
                dt2 = "home";
            }

            string msg = "";
            string connnect = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;
            SqlConnection con = new SqlConnection(connnect);

            con.Open();
            string query = "SELECT * FROM [dbo].[cmsContentXml] where nodeId = '" + dt1 + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string xml = "";
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                xml = row["xml"].ToString();
                // To convert an XML node contained in string xml into a JSON string   
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                jsonText = jsonText.Replace(@"shopping", "m");
                jsonText = jsonText.Replace(@"home", "m");
                jsonText = jsonText.Replace(@"dine", "m");
                jsonText = jsonText.Replace(@"entertain", "m");
                jsonText = jsonText.Replace(@"aboutus", "m");
                jsonText = jsonText.Replace(@"shopDetails", "m");
                jsonText = jsonText.Replace(@"shops", "m");
                jsonText = jsonText.Replace(@"gifts", "m");
                jsonText = jsonText.Replace(@"promotions", "m");
                jsonText = jsonText.Replace(@"storeLocator", "m");
                jsonText = jsonText.Replace(@"shop", "m");
                jsonText = jsonText.Replace(@"Image", "m");
                jsonText = jsonText.Replace(@"more", "m");
                jsonText = jsonText.Replace(@"shop", "m");
                jsonText = jsonText.Replace(@"offers", "m");

                dynamic stuff = JObject.Parse(jsonText);



                var feed = stuff.field;

                ContactModel model = new ContactModel();


                var y = stuff.m;



                List<searchdata> seachdatalist = new List<searchdata>();
                searchdata s = new searchdata();
                var itemToAdd = new JObject();
                // searchdata mSearchData = new searchdata();

                foreach (JProperty x in (JToken)y)
                { // if 'obj' is a JObject

                    //Imran
                    searchdata mSearchData = new searchdata();

                    //if (x.Name == "eventDescription1")
                    //{

                    //    JToken value1 = x.Value;
                    //    mSearchData.name = value1.ToString();
                    //    mSearchData.bio = value1.ToString();
                    //    itemToAdd["name"] = mSearchData.name;
                    //    itemToAdd["bio"] = mSearchData.bio; 




                    //}

                    //start

                    if (x.Name == "@nodeTypeAlias")
                    {
                        JToken value1 = x.Value;
                        mSearchData.shortname = dt2;
                        mSearchData.reknown = dt2;
                        itemToAdd["shortname"] = mSearchData.name;
                        itemToAdd["reknown"] = mSearchData.bio;
                    }


                    if (x.Name == "@urlName")
                    {
                        JToken value1 = x.Value;
                        mSearchData.shortname = dt2;
                        mSearchData.reknown = dt2;
                        itemToAdd["shortname"] = mSearchData.name;
                        itemToAdd["reknown"] = mSearchData.bio;
                    }

                    if (x.Name == "description1")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name =  x.Value.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = value1.ToString();
                        itemToAdd["bio"] = mSearchData.bio;

                    }
                  
                    if (x.Name == "description2")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }


                    if (x.Name == "description3")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;
                    }


                    if (x.Name == "description4")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "description5")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }


                    if (x.Name == "eventDescription1")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                       
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;
                    }

                    if (x.Name == "eventDescription2")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "brandImage2Description")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "brandImage3Description")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "brandImage4Description")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "brandImage5Description")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "brandImage6Description")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "brandImage7Description")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "brandImage1Text")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "brandImage2Text")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "movieDescription1")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "movieDescription2")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "descriptionTitle1")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "descriptionTitle2")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "description5")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "descriptionTitle6")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }
                    if (x.Name == "brandTitle")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "description1Title")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "description2Title")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "manarMall")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "alHamra")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "textSliderTitle1")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "textSliderDescription1")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "description")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "shopContact")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "aboutShop")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "shopLocation")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }

                    if (x.Name == "shopTitle")
                    {
                        JToken value1 = x.Value;
                        mSearchData.name = value1.ToString();
                        mSearchData.bio = value1.ToString();
                        itemToAdd["name"] = mSearchData.name;
                        itemToAdd["bio"] = mSearchData.bio;

                    }







                    //end
                    if (mSearchData.name != null && mSearchData.bio != null)
                    {
                        seachdatalist.Add(mSearchData);
                    }

                }








                JavaScriptSerializer serializer = new JavaScriptSerializer();


                String returndata = serializer.Serialize(seachdatalist);

                //returndata = returndata.Replace(@"\r\n", "");
                //returndata = returndata.Replace(@"#cdata-section\""", "");
                //returndata = returndata.Replace(@": \", "");
                //returndata = returndata.Replace(@"\""""", "");
                var imagePath = ConfigurationManager.AppSettings["JsonPath"];
                var physicalPath = Server.MapPath(imagePath);

                string path1 = physicalPath;
                using (StreamReader r = new StreamReader(path1))
                {
                    string json = r.ReadToEnd();
                    if (json != "")
                    {

                        var array = JArray.Parse(json);



                        array.Add(itemToAdd);
                   
                      
                        returndata = JsonConvert.SerializeObject(array, Newtonsoft.Json.Formatting.Indented);
                        if (returndata != null)
                        {

                        }



                    }
                }
                FileInfo fi = new FileInfo(path1);
                //using (var tw = new StreamWriter(fi.Open(FileMode.Truncate)))
                //{

                //    tw.Write(returndata);
                //    tw.Close();
                //}


            }

            return Json(msg);
        }


        public JsonResult GetClient(ContactModel model)
        {

            string send1 = Request["send"];

            Session["results"] = send1;

            string searchQuery = send1;

            if (Session["results"] != null)
            {
                searchQuery = Session["results"].ToString();
            }



            if (String.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = "";
            }


            var searcher = ExamineManager.Instance;
            var searchCriteria = searcher.CreateSearchCriteria();

            var query = searchCriteria.GroupedOr(new[] { "description1", "description2", "description3", "description4", "description5", "brandImage1Text", "brandImage2Text", "eventDescription1", "eventDescription2", "brandImage2Description", "brandImage3Description", "brandImage4Description", "brandImage5Description", "brandImage6Description", "brandImage7Description", "movieDescription1", "movieDescription2", "descriptionTitle2", "descriptionTitle3", "descriptionTitle5", "descriptionTitle6", "brandTitle", "description1Title", "description2Title", "alHamra", "textSliderTitle1" }, searchQuery).Compile();



            var searchResults = searcher.Search(query).Where(r => r["__IndexType"] == "content").ToList();
            string res = "";
            foreach (var results in searchResults)
            {
                var node1 = Umbraco.TypedContent(results.Id);
                var pathIds = results["__Path"].Split(',');

                var path = Umbraco.TypedContent(pathIds).Where(p => p != null).Select(p => new { p.Name }).ToList();


                string link = "";
                string d1 = "";
                string d2 = "";
                string d3 = "";
                string d4 = "";
                string d5 = "";
                string d6 = "";
                string d7 = "";
                string d8 = "";
                string d9 = "";
                string d10 = "";
                string d11 = "";
                string d12 = "";
                string d13 = "";
                string d14 = "";
                string d15 = "";
                string d16 = "";
                string d17 = "";
                string d18 = "";
                string d19 = "";
                string d20 = "";
                string d21 = "";
                string d22 = "";
                string d23 = "";
                string d24 = "";
                string d25 = "";
                string d26 = "";
                string d27 = "";
                string d28 = "";
                string d29 = "";
                string d30 = "";
                string d31 = "";
                string d32 = "";
                string d33 = "";
                string d34 = "";
                string d35 = "";

                if (link != null)
                {
                    link = node1.Url.ToString();
                    model.reknown = link.ToString();
                }
                if (node1.GetProperty("description1") != null)
                {

                    d1 = node1.GetProperty("description1").DataValue.ToString();
                    string s = Regex.Replace(d1, "<.*?>", String.Empty);
                    model.bio = s.ToString();
                }
                if (node1.GetProperty("description2") != null)
                {
                    d2 = node1.GetProperty("description2").DataValue.ToString();

                    model.de2 = d2.ToString();
                }
                if (node1.GetProperty("description3") != null)
                {
                    d3 = node1.GetProperty("description3").DataValue.ToString();

                    model.de3 = d3.ToString();
                }
                if (node1.GetProperty("description4") != null)
                {
                    d4 = node1.GetProperty("description4").DataValue.ToString();

                    model.de4 = d4.ToString();
                }
                if (node1.GetProperty("description5") != null)
                {
                    d5 = node1.GetProperty("description5").DataValue.ToString();

                    model.de5 = d5.ToString();
                }
                if (node1.GetProperty("eventDescription1") != null)
                {
                    d6 = node1.GetProperty("eventDescription1").DataValue.ToString();

                    model.de6 = d6.ToString();
                }

                if (node1.GetProperty("eventDescription2") != null)
                {
                    d7 = node1.GetProperty("eventDescription2").DataValue.ToString();

                    model.de7 = d7.ToString();
                }

                if (node1.GetProperty("brandImage2Description") != null)
                {
                    d8 = node1.GetProperty("brandImage2Description").DataValue.ToString();

                    model.de8 = d8.ToString();
                }
                if (node1.GetProperty("brandImage3Description") != null)
                {
                    d9 = node1.GetProperty("brandImage3Description").DataValue.ToString();

                    model.de9 = d9.ToString();
                }
                if (node1.GetProperty("brandImage4Description") != null)
                {
                    d10 = node1.GetProperty("brandImage4Description").DataValue.ToString();

                    model.de10 = d10.ToString();
                }
                if (node1.GetProperty("brandImage5Description") != null)
                {
                    d11 = node1.GetProperty("brandImage5Description").DataValue.ToString();

                    model.de11 = d11.ToString();
                }
                if (node1.GetProperty("brandImage6Description") != null)
                {
                    d12 = node1.GetProperty("brandImage6Description").DataValue.ToString();

                    model.de12 = d12.ToString();
                }
                if (node1.GetProperty("brandImage7Description") != null)
                {
                    d13 = node1.GetProperty("brandImage7Description").DataValue.ToString();

                    model.de13 = d13.ToString();
                }
                if (node1.GetProperty("brandImage1Text") != null)
                {
                    d14 = node1.GetProperty("brandImage1Text").DataValue.ToString();

                    model.de14 = d14.ToString();
                }

                if (node1.GetProperty("brandImage2Text") != null)
                {
                    d15 = node1.GetProperty("brandImage2Text").DataValue.ToString();

                    model.de15 = d15.ToString();
                }

                if (node1.GetProperty("movieDescription1") != null)
                {
                    d16 = node1.GetProperty("movieDescription1").DataValue.ToString();

                    model.de16 = d16.ToString();
                }
                if (node1.GetProperty("movieDescription2") != null)
                {
                    d17 = node1.GetProperty("movieDescription2").DataValue.ToString();

                    model.de17 = d17.ToString();
                }

                if (node1.GetProperty("descriptionTitle1") != null)
                {
                    d18 = node1.GetProperty("descriptionTitle1").DataValue.ToString();

                    model.de18 = d18.ToString();
                }

                if (node1.GetProperty("descriptionTitle2") != null)
                {
                    d19 = node1.GetProperty("descriptionTitle2").DataValue.ToString();

                    model.de19 = d19.ToString();
                }

                if (node1.GetProperty("descriptionTitle2") != null)
                {
                    d20 = node1.GetProperty("descriptionTitle2").DataValue.ToString();

                    model.de20 = d20.ToString();
                }

                if (node1.GetProperty("description5") != null)
                {
                    d21 = node1.GetProperty("description5").DataValue.ToString();

                    model.de21 = d21.ToString();
                }

                if (node1.GetProperty("descriptionTitle6") != null)
                {
                    d22 = node1.GetProperty("descriptionTitle6").DataValue.ToString();

                    model.de22 = d22.ToString();
                }

                if (node1.GetProperty("brandTitle") != null)
                {
                    d23 = node1.GetProperty("brandTitle").DataValue.ToString();

                    model.de23 = d23.ToString();
                }

                if (node1.GetProperty("description1Title") != null)
                {
                    d24 = node1.GetProperty("description1Title").DataValue.ToString();

                    model.de24 = d24.ToString();
                }
                if (node1.GetProperty("description2Title") != null)
                {
                    d25 = node1.GetProperty("description2Title").DataValue.ToString();

                    model.de25 = d25.ToString();
                }

                if (node1.GetProperty("manarMall") != null)
                {
                    d26 = node1.GetProperty("manarMall").DataValue.ToString();

                    model.de26 = d26.ToString();
                }

                if (node1.GetProperty("alHamra") != null)
                {
                    d27 = node1.GetProperty("alHamra").DataValue.ToString();

                    model.de27 = d27.ToString();
                }

                if (node1.GetProperty("textSliderTitle1") != null)
                {
                    d28 = node1.GetProperty("textSliderTitle1").DataValue.ToString();

                    model.de28 = d28.ToString();
                }
                if (node1.GetProperty("textSliderDescription1") != null)
                {
                    d29 = node1.GetProperty("textSliderDescription1").DataValue.ToString();

                    model.de29 = d29.ToString();
                }

                if (node1.GetProperty("description") != null)
                {
                    d30 = node1.GetProperty("description").DataValue.ToString();

                    model.de30 = d30.ToString();
                }


                if (node1.GetProperty("shopContact") != null)
                {
                    d31 = node1.GetProperty("shopContact").DataValue.ToString();

                    model.de31 = d31.ToString();
                }

                if (node1.GetProperty("shopContact") != null)
                {
                    d32 = node1.GetProperty("shopContact").DataValue.ToString();

                    model.de32 = d32.ToString();
                }

                if (node1.GetProperty("aboutShop") != null)
                {
                    d33 = node1.GetProperty("aboutShop").DataValue.ToString();

                    model.de33 = d33.ToString();
                }


                if (node1.GetProperty("shopLocation") != null)
                {
                    d34 = node1.GetProperty("shopLocation").DataValue.ToString();

                    model.de34 = d34.ToString();
                }

                if (node1.GetProperty("shopTitle") != null)
                {
                    d35 = node1.GetProperty("shopTitle").DataValue.ToString();

                    model.de35 = d35.ToString();
                }








            }


            ContactModel emp = new ContactModel();
            string str = "[{\"name\":\"" + model.bio + "\",\"shortname\":\"" + model.bio + "\",\"reknown\":\"" + model.reknown + "\",\"bio\":\"" + model.reknown + "\"}]";
            dynamic json = JsonConvert.DeserializeObject(str);

            string JSONresult = JsonConvert.SerializeObject(json);

            string path1 = @"E:\ManarMall\ManarMall\data.json";


            if (System.IO.File.Exists(path1))
            {
                System.IO.File.Delete(path1);
                
                using (var tw = new StreamWriter(path1, true))
                {
                    tw.WriteLine(JSONresult.ToString());
                    tw.Close();
                }
            }
            else
            {
                using (var tw = new StreamWriter(path1, true))
                {
                    tw.WriteLine(JSONresult.ToString());
                    tw.Close();
                }
            }







            return Json(res);

        }

    }







}
