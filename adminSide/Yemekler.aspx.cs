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
    public partial class Yemekler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            listele();
        }

        protected void listele()
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand comm = new SqlCommand("SELECT * FROM VW_MealCategory order by Date desc", conn);
            SqlDataReader reader;

            try
            {

                conn.Open();
                reader = comm.ExecuteReader();
                rptlistele.DataSource = reader;
                rptlistele.DataBind();
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

        protected void rptlistele_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(conString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("",conn);

                cmd.CommandText = "DELETE FROM MEAL_INGREDIENT WHERE MealId=@Id "
                                   + " DELETE FROM DAY_MENU WHERE MealId=@Id "
                                   + " DELETE FROM MEAL WHERE Id=@Id ";
                cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                
                conn.Close();
                listele();
            }
        }

        protected void lbAra_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            string sqlQuery = "SELECT * from VW_MEAL WHERE MealName LIKE'%" + txtAra.Text.Trim().ToString() + "%'"; 
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                rptlistele.DataSource = reader;
                rptlistele.DataBind();


                reader.Close();

            }

            finally
            {
                connection.Close();
            }


        }




    }
}