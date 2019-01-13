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

            var query = searchCriteria.GroupedOr(new[] { "description1", "description2", "description3", "description4", "description5", "brandImage1Text", "brandImage2Text", "eventDescription1", "eventDescription2", "brandImage2Description", "brandImage3Description", "brandImage4Description", "brandImage5Description", "brandImage6Description", "brandImage7Description" , "movieDescription1", "movieDescription2", "descriptionTitle2" , "descriptionTitle3" , "descriptionTitle5" , "descriptionTitle6" , "brandTitle" , "description1Title", "description2Title" , "alHamra" , "textSliderTitle1" }, searchQuery).Compile();



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
                    model.link = link.ToString();
                }
                if (node1.GetProperty("description1") != null)
                {

                    d1 = node1.GetProperty("description1").DataValue.ToString();
                
                    model.de1 = d1.ToString();
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
                if (node1.GetProperty("eventDescription1") !=null)
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




                res = res + "" + "<ul>" 
                    + "<li><a href = " + model.link + " > " + model.de1 + "</a></li>"+
                    "<li><a href = " + model.link + " > " + model.de2 + "</a></li>" +
                    "<li><a href = " + model.link + " > " + model.de3 + "</a></li>" +
                     "<li><a href = " + model.link + " > " + model.de4 + "</a></li>" +
                      "<li><a href = " + model.link + " > " + model.de5 + "</a></li>" +
                       "<li><a href = " + model.link + " > " + model.de6 + "</a></li>" +
                        "<li><a href = " + model.link + " > " + model.de7 + "</a></li>" +
                         "<li><a href = " + model.link + " > " + model.de8 + "</a></li>" +
                          "<li><a href = " + model.link + " > " + model.de9 + "</a></li>" +
                           "<li><a href = " + model.link + " > " + model.de10 + "</a></li>" +
                            "<li><a href = " + model.link + " > " + model.de11 + "</a></li>" +
                             "<li><a href = " + model.link + " > " + model.de12 + "</a></li>" +
                              //"<li><a href = " + model.link + " > " + model.de13 + "</a></li>" +
                              // "<li><a href = " + model.link + " > " + model.de14 + "</a></li>" +
                              //  "<li><a href = " + model.link + " > " + model.de15 + "</a></li>" +
                              //   "<li><a href = " + model.link + " > " + model.de16 + "</a></li>" +
                              //    "<li><a href = " + model.link + " > " + model.de17 + "</a></li>" +
                              //     "<li><a href = " + model.link + " > " + model.de18 + "</a></li>" +
                              //      "<li><a href = " + model.link + " > " + model.de19 + "</a></li>" +
                              //       "<li><a href = " + model.link + " > " + model.de20 + "</a></li>" +
                                      //"<li><a href = " + model.link + " > " + model.de21 + "</a></li>" +
                                      // "<li><a href = " + model.link + " > " + model.de22 + "</a></li>" +
                                      //  "<li><a href = " + model.link + " > " + model.de23 + "</a></li>" +
                                      //   "<li><a href = " + model.link + " > " + model.de24 + "</a></li>" +
                                      //    "<li><a href = " + model.link + " > " + model.de25 + "</a></li>" +
                                      //     "<li><a href = " + model.link + " > " + model.de26 + "</a></li>" +
                                      //      "<li><a href = " + model.link + " > " + model.de27 + "</a></li>" +
                                      //       "<li><a href = " + model.link + " > " + model.de28 + "</a></li>" +
                                      //        "<li><a href = " + model.link + " > " + model.de29 + "</a></li>" +
                                      //         "<li><a href = " + model.link + " > " + model.de30 + "</a></li>" +
                                      //          "<li><a href = " + model.link + " > " + model.de31 + "</a></li>" +
                                      //          "<li><a href = " + model.link + " > " + model.de32 + "</a></li>" +
                                      //          "<li><a href = " + model.link + " > " + model.de33 + "</a></li>" +
                                      //    "<li><a href = " + model.link + " > " + model.de34 + "</a></li>" +
                                      //    "<li><a href = " + model.link + " > " + model.de35 + "</a></li>" +

                    "</ul>";

            }

            return Json(res);


            }
           
        }

    }

 
    