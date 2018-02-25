using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YemekSitesi.adminSide
{
    public partial class YemekDetay : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
       
        public List<YemeginMalzemeleri> YEMEGINMALZEMELERI
        {
            get
            {
                if (ViewState["YEMEGINMALZEMELERI"] == null)
                {
                    ViewState["YEMEGINMALZEMELERI"] = new List<YemeginMalzemeleri>();
                }
                return ViewState["YEMEGINMALZEMELERI"] as List<YemeginMalzemeleri>;
            }
            set
            {


                ViewState["YEMEGINMALZEMELERI"] = value;

            }
        }
        public MealPic resimler
        {
            get
            {
                if (ViewState["MealPic"] == null)
                {
                    ViewState["MealPic"] = new MealPic();
                }
                return ViewState["MealPic"] as MealPic;
            }
            set
            {
                ViewState["MealPicID"] = value;
            }
        }

        public Guid RECID
        {
            get
            {
                if (ViewState["RECID"] == null)
                {
                    ViewState["RECID"] = Guid.Empty;
                }
                return Guid.Parse(ViewState["RECID"].ToString());
            }
            set
            {
                ViewState["RECID"] = value;
            }
        }
        Meal MealForUpdate = new Meal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
           


                if (Request.QueryString.AllKeys.Contains("Id"))
                {

                    SqlConnection conn = new SqlConnection(conString);
                    SqlCommand cmd = new SqlCommand("SELECT * FROM VW_MealCategory WHERE Id =@Id", conn);
                    cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();


                    try
                    {

                        while (reader.Read())
                        {
                            MealForUpdate.Id = reader.GetGuid(0);
                            ltlYemekAdi.Text = reader[1].ToString();
                            ltlKatgoryID.Text = reader[9].ToString();
                            ltlNumberPeople.Text = reader[4].ToString();
                            ltlCookTime.Text = reader[5].ToString();
                            resimler.Old = reader.GetGuid(6);
                            ltlDescription.Text = reader[7].ToString();

                            if (reader.GetBoolean(8))
                            {
                                ltlOnayDurumu.Text = "Onaylı";
                                btnYayindanKaldir.Visible = true;
                                btnYayinla.Visible = false;
                            }
                            else
                            {
                                ltlOnayDurumu.Text = "Onaylı Değil";
                                btnYayindanKaldir.Visible = false;
                                btnYayinla.Visible = true;
                            }
                        }
                        cmd.Dispose();
                        reader.Close();


                        cmd.CommandText = "Select * From VW_MEALINGREDIENT Where MealId=@Id";

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            YEMEGINMALZEMELERI.Add(new YemeginMalzemeleri(
                                                              false,
                                                              reader.GetGuid(0),
                                                              reader.GetInt32(3),
                                                              reader.GetInt32(4),
                                                              reader.GetString(5),
                                                              reader.GetString(6),
                                                              reader.GetString(2)));
                        }

                        ingredientRepeater.DataSource = YEMEGINMALZEMELERI;
                        ingredientRepeater.DataBind();

                        cmd.Dispose();
                        reader.Close();


                        imgResim.ImageUrl = "../Pictures//KapakResmi//" + resimler.Old.ToString() + ".jpg";



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
            }

        }
        
        protected void btnYayinla_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(conString);


            if (ltlOnayDurumu.Text=="Onaylı Değil")
            {

             
                SqlCommand cmd = new SqlCommand("UPDATE MEAL SET Status=@Status WHERE Id =@Id", conn);
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);
                conn.Open();
                cmd.Parameters.AddWithValue("Status",true);
                cmd.ExecuteNonQuery();
                ltlOnayDurumu.Text = "Onaylı";

            }
            btnYayinla.Visible = false;
            btnYayindanKaldir.Visible = true;
            
            conn.Close();
            
            
        }

        protected void btnYayindanKaldir_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conString);

            if (ltlOnayDurumu.Text == "Onaylı")
            {

                
                SqlCommand cmd = new SqlCommand("UPDATE MEAL SET Status=@Status WHERE Id =@Id", conn);
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);
                conn.Open();
                cmd.Parameters.AddWithValue("Status",false);
                cmd.ExecuteNonQuery();
                ltlOnayDurumu.Text = "Onaylı Değil";
            }

            btnYayinla.Visible = true;
            btnYayindanKaldir.Visible = false;
            conn.Close();
            
        }

       
        
        
    }
}
