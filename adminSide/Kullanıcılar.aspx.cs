using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YemekSitesi.adminSide
{
    [Serializable]
    public partial class Kullanıcılar : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public List<Kullanıcı> KULLANICILAR
        {
            get
            {
                if (ViewState["KULLANICILAR"] == null)
                {
                    ViewState["KULLANICILAR"] = new List<Kullanıcı>();
                }
                return ViewState["KULLANICILAR"] as List<Kullanıcı>;
            }
            set
            {
                ViewState["KULLANICILAR"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
                return;
            Listele();
        }

        protected void lbAra_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            string sqlQuery = "SELECT * from USERS WHERE Name LIKE'%" + txtAra.Text.Trim().ToString() + "%'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                kullanıcıRepeater.DataSource = reader;
                kullanıcıRepeater.DataBind();


                reader.Close();

            }

            finally
            {
                connection.Close();
            }
        }

        protected void kullanıcıRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (e.CommandName == "Delete")
            {
              
                SqlConnection conn = new SqlConnection(conString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("", conn);

                cmd.CommandText = "DELETE FROM USERS WHERE Id=@Id ";
                                  
                cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                Listele();
                conn.Close();
             
            }
            else if (e.CommandName == "Onayla")
            {
               
                SqlConnection conn = new SqlConnection(conString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("", conn);

                cmd.CommandText = "UPDATE USERS SET isAdmin=@isAdmin WHERE Id =@Id ";
                cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
                cmd.Parameters.AddWithValue("isAdmin", true);
                cmd.ExecuteNonQuery();
                Listele();
                upKullanıcı.Update();
                conn.Close();
              
            }
            else if (e.CommandName == "OnayKaldır")
            {

                SqlConnection conn = new SqlConnection(conString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("", conn);

                cmd.CommandText = "UPDATE USERS SET isAdmin=@isAdmin WHERE Id =@Id ";
                cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
                cmd.Parameters.AddWithValue("isAdmin", false);
                cmd.ExecuteNonQuery();
                Listele();
                upKullanıcı.Update();
                conn.Close();
               
               
            }
               
               
           
        }
        protected void Listele()
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand comm = new SqlCommand("SELECT * FROM USERS order by Date desc", conn);
            SqlDataReader reader;

            try
            {

                conn.Open();
                reader = comm.ExecuteReader();
                kullanıcıRepeater.DataSource = reader;
                kullanıcıRepeater.DataBind();
                reader.Close();
            }

            catch
            {
                Response.Write("bir hata oluştu");
            }

            finally
            {
                conn.Close();
            }
        }
         
         
                                                   


            
       


        protected void btnOnayla_Click(object sender, EventArgs e)
        {
          //  SqlConnection conn = new SqlConnection(conString);
          //  SqlCommand cmd = new SqlCommand("UPDATE USERS SET isAdmin=@isAdmin WHERE Id =@Id", conn);
          ////  cmd.Parameters.AddWithValue("@Id", );
          //  conn.Open();
          //  cmd.Parameters.AddWithValue("isAdmin", true);
          //  cmd.ExecuteNonQuery();
          //  conn.Close();
        }
    }
}