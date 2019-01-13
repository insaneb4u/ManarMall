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
    public class ContactSurfaceController : SurfaceController
    {

        public ActionResult RenderContactUsPageContent()
        {
            return PartialView("~/Views/Partials/ContactUsPageContent/ContactUsPageContent.cshtml");
        }

        [HttpPost]
        public ActionResult SubmitForm(ContactModel model)
        {
            SqlConnection con = new SqlConnection("Data Source=ADMIN-PC;Initial Catalog=ManarMall;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ContactDetails",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Name", model.Fullname);
            cmd.Parameters.AddWithValue("Nationality", model.Nationality);
            cmd.Parameters.AddWithValue("Email", model.Email);
            cmd.Parameters.AddWithValue("Address", model.Address);

            if (model.Remark1 !=null)
            {
                cmd.Parameters.AddWithValue("CustomerService",model.Remark1);
            }

            if (model.Remark2 != null)
            {
                cmd.Parameters.AddWithValue("CustomerService",model.Remark2);
            }

            if (model.Remark3 != null)
            {
                cmd.Parameters.AddWithValue("CustomerService", model.Remark3);
            }

            if (model.Remark4 != null)
            {
                cmd.Parameters.AddWithValue("CustomerService", model.Remark4);
            }

            if (model.Remark5 != null)
            {
                cmd.Parameters.AddWithValue("FriendlinessofSecurityStaff", model.Remark5);
            }

            if (model.Remark6 != null)
            {
                cmd.Parameters.AddWithValue("FriendlinessofSecurityStaff", model.Remark6);
            }
            if (model.Remark7 != null)
            {
                cmd.Parameters.AddWithValue("FriendlinessofSecurityStaff", model.Remark7);
            }
            if (model.Remark8 != null)
            {
                cmd.Parameters.AddWithValue("FriendlinessofSecurityStaff", model.Remark8);
            }

            if (model.Remark9 != null)
            {
                cmd.Parameters.AddWithValue("Directionalsigns", model.Remark9);
            }

            if (model.Remark10 != null)
            {
                cmd.Parameters.AddWithValue("Directionalsigns", model.Remark10);
            }

            if (model.Remark11 != null)
            {
                cmd.Parameters.AddWithValue("Directionalsigns", model.Remark11);
            }

            if (model.Remark12 != null)
            {
                cmd.Parameters.AddWithValue("Directionalsigns", model.Remark12);
            }

            if (model.Remark13 != null)
            {
                cmd.Parameters.AddWithValue("Cleanlinessofmal", model.Remark13);
            }
            if (model.Remark14 != null)
            {
                cmd.Parameters.AddWithValue("Cleanlinessofmal", model.Remark14);
            }
           
            if (model.Remark15 != null)
            {
                cmd.Parameters.AddWithValue("Cleanlinessofmal", model.Remark15);
            }

            if (model.Remark16 != null)
            {
                cmd.Parameters.AddWithValue("Cleanlinessofmal", model.Remark16);
            }

            cmd.ExecuteNonQuery();
            con.Close();


            return RedirectToCurrentUmbracoUrl();
        }

        



        }
}