using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace YemekSitesi.adminSide
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            if (Request.QueryString.AllKeys.Contains("Id"))
            {
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("Select * From CATEGORY WHERE Id=@Id", connect);
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtKategoriAdi.Text = reader.GetString(1).ToString();
                }

                reader.Close();

            }

        }
        protected void lbKaydet_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(conString);

         
            if (txtKategoriAdi.Text == string.Empty)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Lütfen Boş Alanı Doldurun');", true);

            }
           

            else
            {
                {
                    string sqlquery = "INSERT INTO CATEGORY (CategoryName) VALUES (@CategoryName)";
                    SqlCommand command = new SqlCommand(sqlquery, conn);

                    string categoryName = txtKategoriAdi.Text;
                    command.Parameters.AddWithValue("CategoryName", categoryName);


                    try
                    {
                        conn.Open();

                        command.ExecuteNonQuery();

                        conn.Close();
                        command.Parameters.Clear();
                        Response.Write("<script>alert('Kayıt Yapıldı')</script>");
                    }
                    catch
                    {
                        Response.Write("<script>alert('Aynı Kateğoriden Bulunmaktadır.')</script>");
                    }
                }
            }

        }
        protected void lbTemizle_Click(object sender, EventArgs e)
        {

        }

        protected void lbAra_Click(object sender, EventArgs e)
        {

        }
    }
}