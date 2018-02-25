using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace YemekSitesi.adminSide
{
    public partial class Kategori : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
          if (IsPostBack)
                return;
            Listing_Category();
            
        }
        protected void Listing_Category()
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            string sqlQuery = "SELECT * FROM CATEGORY";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            rptListele.DataSource = reader;
            rptListele.DataBind();
            reader.Close();
        }
        

        protected void lbAra_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string sqlQuery = "SELECT * FROM CATEGORY  WHERE CategoryName LIKE'%" + txtAra.Text.Trim().ToString() + "%'";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
           
               try
           {
            SqlDataReader reader = command.ExecuteReader();

            rptListele.DataSource = reader;
            rptListele.DataBind();
           
          
                    reader.Close();
            
             }
                   
               finally
               {
                   connection.Close();
               }
            

        
        }

        protected void rptListele_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(conString);
                
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = " DELETE FROM MEAL WHERE CategoryId=@Id "
                                      + " delete from CATEGORY where Id = @Id  ";
                    cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    Listing_Category();
                }
                catch { System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Ne yazık ki ,Kategorinize Ait Yemek Bulunmaktadır.');", true); }
            }
        }

       
  
        
    }
}