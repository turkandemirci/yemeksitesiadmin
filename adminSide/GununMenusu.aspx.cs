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
    public partial class GununMenusu : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        public List<GununMenusuYemekleri> GUNUNMENUSUYEMEKLERI
        {
            get
            {
                if (ViewState["GUNUNMENUSUYEMEKLERI"] == null)
                {
                    ViewState["GUNUNMENUSUYEMEKLERI"] = new List<GununMenusuYemekleri>();
                }
                return ViewState["GUNUNMENUSUYEMEKLERI"] as List<GununMenusuYemekleri>;
            }
            set
            {


                ViewState["GUNUNMENUSUYEMEKLERI"] = value;

            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            if (!IsPostBack)
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM VW_MealDayMenu  WHERE  Date=@Today  ", connection);

                cmd.Parameters.AddWithValue("Today", DateTime.Today);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())//ogün için olanları bool isNew,Guid ID, Guid MealID, string MealName, bool Status,DateTime Date
                {
                    GUNUNMENUSUYEMEKLERI.Add(new GununMenusuYemekleri(
                                                       false,
                                                       reader.GetGuid(1),
                                                       reader.GetGuid(2),
                                                       reader.GetString(0),
                                                       reader.GetBoolean(3),
                                                       reader.GetDateTime(4)));
                }
                rptGununMenusu.DataSource = GUNUNMENUSUYEMEKLERI;
                rptGununMenusu.DataBind();
                reader.Close();

            }
        }









        protected void btnEkle_Click(object sender, EventArgs e) //Guid ID, Guid MealID, string MealName, bool Status,bool isNew
        {
            if (hdnGununMenusuID.Value == string.Empty)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Bir Yemek Seçiniz');", true);
            }
            else
            {
                Guid gununMenusuID = Guid.NewGuid();
                if (txtGununMenusu.Text != string.Empty && hdnGununMenusuID.Value != string.Empty)
                {

                    GUNUNMENUSUYEMEKLERI.Add(new GununMenusuYemekleri(
                                true,
                                gununMenusuID,
                                Guid.Parse(hdnGununMenusuID.Value),
                                txtGununMenusu.Text,
                                false,
                                DateTime.Today
                           ));
                }
            }
            rptGununMenusu.DataSource = GUNUNMENUSUYEMEKLERI;
            rptGununMenusu.DataBind();
        }


















        protected void rptGununMenusu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            GununMenusuYemekleri temp = GUNUNMENUSUYEMEKLERI.Single(m => m.ID == Guid.Parse(e.CommandArgument.ToString()));
            if (temp != null)
            {
                if (e.CommandName == "Delete")
                {
                    if (!temp.isNew)
                    {

                        SqlConnection connection = new SqlConnection(conString);
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM DAY_MENU WHERE Id=@Id", connection);
                        cmd.Parameters.AddWithValue("Id", temp.ID);
                        cmd.ExecuteNonQuery();
                    }
                    GUNUNMENUSUYEMEKLERI.Remove(temp);
                    rptGununMenusu.DataSource = GUNUNMENUSUYEMEKLERI;
                    rptGununMenusu.DataBind();

                }
            }
        }

        protected void btnTamam_Click(object sender, EventArgs e)
        {
            if (GUNUNMENUSUYEMEKLERI.Count == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Yemek Eklemeniz Gerekmektedir');", true);
                pnlGununMenusuOnay.Visible = false;
            }

            else
            {
                foreach (GununMenusuYemekleri menu in GUNUNMENUSUYEMEKLERI)
                {

                    if (menu.isNew)
                    {
                        SqlConnection connection = new SqlConnection(conString);
                        connection.Open();
                        SqlCommand command = new SqlCommand("INSERT INTO DAY_MENU(Id,MealId,Status) VALUES (@Id,@MealId,@Status)", connection);
                        Guid gununMenuID = Guid.NewGuid();
                        command.Parameters.AddWithValue("@Id", gununMenuID);
                        command.Parameters.AddWithValue("@MealId", menu.MealID);
                        command.Parameters.AddWithValue("@Status", menu.Status);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }


                }
                pnlGununMenusuOnay.Visible = true;
                pnlGununMenusu.Visible = false;

            }

          
        


            rptGununMenusuOnay.DataSource = GUNUNMENUSUYEMEKLERI;
            rptGununMenusuOnay.DataBind();

        }

        protected void rptGununMenusuOnay_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            GununMenusuYemekleri temp = GUNUNMENUSUYEMEKLERI.Single(m => m.ID == Guid.Parse(e.CommandArgument.ToString()));
            if (temp != null)
            {
                if (e.CommandName == "Onayla")
                {
                    SqlConnection connection = new SqlConnection(conString);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE DAY_MENU SET Status=@Status WHERE Id =@Id", connection);
                    cmd.Parameters.AddWithValue("Id", temp.ID);
                    cmd.Parameters.AddWithValue("Status", true);
                    cmd.ExecuteNonQuery();

                    GUNUNMENUSUYEMEKLERI.Remove(temp);
                    temp.Status = true;
                    GUNUNMENUSUYEMEKLERI.Add(temp);

                    rptGununMenusuOnay.DataSource = GUNUNMENUSUYEMEKLERI;
                    rptGununMenusuOnay.DataBind();
                    upDayMenuConfirm.Update();
                    connection.Close();
                }
                else if (e.CommandName == "OnayıKaldır")
                {
                    SqlConnection connection = new SqlConnection(conString);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE DAY_MENU SET Status=@Status WHERE Id =@Id", connection);
                    cmd.Parameters.AddWithValue("Id", temp.ID);
                    cmd.Parameters.AddWithValue("Status", false);
                    cmd.ExecuteNonQuery();

                    GUNUNMENUSUYEMEKLERI.Remove(temp);
                    temp.Status = false;
                    GUNUNMENUSUYEMEKLERI.Add(temp);

                    rptGununMenusuOnay.DataSource = GUNUNMENUSUYEMEKLERI;
                    rptGununMenusuOnay.DataBind();
                    upDayMenuConfirm.Update();
                    connection.Close();
                }
            }
        }

        protected void btnIptal_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("GununMenusu.aspx");
        }




    }
}