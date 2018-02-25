using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace YemekSitesi.adminSide
{
    public partial class LoginForm : BasePage
    {

        protected override void OnPreInit(EventArgs e)
        {
            isLoginForm = true;
            base.OnPreInit(e);
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            User = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM USERS Where Name=@Name and MD5Sifreleme=@Password", conn);
            com.Parameters.AddWithValue("@Name", txtUserName.Text);
            com.Parameters.AddWithValue("@Password", MD5Sifrele(txtPsswrd.Text));
            SqlDataReader oku = com.ExecuteReader();

            string name = string.Empty;

            while (oku.Read()) // todo : Verileri databaseten çek classın içini doldur
            {
                try
                {
                    User.ID = oku.GetGuid(0);
                    User.Name = oku.GetString(1);
                    User.Surname = oku.GetString(2);
                    User.MD5Sifreleme = oku.GetString(3);
                    User.Email = oku.GetString(4);
                    User.Date = oku.GetDateTime(5);
                    User.isAdmin = oku.GetBoolean(6);
                }
                catch { }
            }

            Response.Redirect("Default.aspx");

        }
    }
}