using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;


namespace YemekSitesi.adminSide
{
    public partial class YemekEkle : System.Web.UI.Page
    {
       
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

        protected void Page_Load(object sender, EventArgs e)
        {
            Meal MealForUpdate = new Meal();

            if (!Page.IsPostBack)
            {

                DropDownCategory();

                if (Request.QueryString.Count > 0 && Request.QueryString.AllKeys.Contains("Id"))
                {
                    RECID = Guid.Parse(Request.QueryString["Id"]);
                    string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    SqlConnection conn = new SqlConnection(conString);


                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM MEAL WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", RECID);
                    SqlDataReader reader = cmd.ExecuteReader();
                   
                    while (reader.Read())
                    {
                        MealForUpdate.Id = reader.GetGuid(0);
                        RECID = MealForUpdate.Id;
                        MealForUpdate.MealName = reader.GetString(1);
                        MealForUpdate.CategoryId = reader.GetByte(2);
                        MealForUpdate.NumberPeople = reader.GetByte(4);
                        MealForUpdate.CookingTime = reader.GetByte(5);
                        resimler.Old = reader.GetGuid(6);
                        MealForUpdate.Description = reader.GetString(7);
                    }
                    reader.Close();


                    txtYemekAdi.Text = MealForUpdate.MealName;
                    txtKacKisi.Text = MealForUpdate.NumberPeople.ToString();
                    txtHazirlama.Text = MealForUpdate.CookingTime.ToString();
                    ddlKategori.SelectedValue = MealForUpdate.CategoryId.ToString();
                    txtDescriptipon.Text = MealForUpdate.Description.ToString();

                    cmd.CommandText = "Select * From VW_MEALINGREDIENT Where MealId=@Id";
                    reader = cmd.ExecuteReader();

                    while (reader.Read())// Yemeğe ait malzemeleri çek
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

                    reader.Close();

                    imgYemekResim.ImageUrl = "../Pictures//KapakResmi//" + resimler.Old.ToString() + ".jpg";
                }

            }

        }

        public object PicID { get; private set; }

        protected void lbKaydet_Click(object sender, EventArgs e)
        {

            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);

            conn.Open();

            if (ddlKategori.SelectedValue == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Kategori Kısmını Lütfen Seçiniz');", true);
            }
            else if (txtYemekAdi.Text == String.Empty)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Yemek Adını Lütfen Giriniz');", true);
            }
            else if (txtKacKisi.Text == String.Empty)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Lütfen Kaç Kişi Olduğunu Giriniz');", true);
            }
            else if (txtHazirlama.Text == String.Empty)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert(' Lütfen Hazılama Süresini Giriniz');", true);
            }
            else
            {
                if (Request.QueryString.Count > 0 && Request.QueryString.AllKeys.Contains("Id")) // Güncelleme
                {

                    string sqlUpdateQuery = "UPDATE MEAL SET MealName=@MealName,CategoryId=@CategoryId,NumberPeople=@NumberPeople,CookingTime=@CookingTime,MealPic=@MealPic,Description=@Description WHERE Id=@Id";

                    SqlCommand cmd = new SqlCommand(sqlUpdateQuery, conn);
                    cmd.Parameters.AddWithValue("Id", RECID);
                    cmd.Parameters.AddWithValue("MealName", txtYemekAdi.Text);
                    cmd.Parameters.AddWithValue("CategoryId", ddlKategori.SelectedValue);
                    cmd.Parameters.AddWithValue("NumberPeople", txtKacKisi.Text);
                    cmd.Parameters.AddWithValue("CookingTime", txtHazirlama.Text);                 
                    cmd.Parameters.AddWithValue("Description", txtDescriptipon.Text);               
                    if (resimler.New != Guid.Empty)
                    {
                        cmd.Parameters.AddWithValue("MealPic", resimler.New);
                        string dosyaYolu = Server.MapPath("../Pictures//KapakResmi//" + resimler.Old + ".jpg");
                        if (File.Exists(dosyaYolu))
                        {
                            File.Delete(dosyaYolu);
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("MealPic", resimler.Old);
                    }

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    foreach (YemeginMalzemeleri malzeme in YEMEGINMALZEMELERI)//foreach kullanmamızın sebebi malzemeleri listeden alıp geldiğimiz için
                    {
                        if (malzeme.yeniMi)
                        {
                            cmd.CommandText = "INSERT INTO  MEAL_INGREDIENT(Id,MealId,Amount,ScaleId,IngredientId) VALUES (@Id, @MealId, @Amount,@ScaleId, @IngredientId)";
                            Guid MealIngredientId = Guid.NewGuid();
                            cmd.Parameters.AddWithValue("Id", MealIngredientId);
                            cmd.Parameters.AddWithValue("MealId", RECID);
                            cmd.Parameters.AddWithValue("Amount", malzeme.amount);
                            cmd.Parameters.AddWithValue("ScaleId", malzeme.scaleId);
                            cmd.Parameters.AddWithValue("IngredientId", malzeme.ingredientId);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                  

                    Response.Redirect("YemekDetay.aspx?Id=" + RECID);
                }

                else // İlk kez kayıt
                {
                    if (ddlKategori.SelectedValue == "0")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Kategori Kısmını Lütfen Seçiniz');", true);
                    }
                    else if (txtYemekAdi.Text == String.Empty)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Yemek Adını Lütfen Giriniz');", true);
                    }
                    else if (txtKacKisi.Text == String.Empty)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Lütfen Kaç Kişi Olduğunu Giriniz');", true);
                    }
                    else if (txtHazirlama.Text == String.Empty)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert(' Lütfen Hazılama Süresini Giriniz');", true);
                    }
                    else
                    {
                        if (txtYemekAdi.Text != string.Empty || ddlKategori.SelectedIndex != 0)
                        {
                            int kacKisilik, Sure;
                            if (int.TryParse(txtKacKisi.Text, out kacKisilik) && int.TryParse(txtHazirlama.Text, out Sure))
                            {
                                string sqlquery = "INSERT INTO MEAL(Id,MealName,CategoryId,NumberPeople,CookingTime,MealPic,Description) VALUES (@Id,@MealName,@CategoryId,@NumberPeople,@CookingTime,@MealPic,@Description)";

                                SqlCommand command = new SqlCommand(sqlquery, conn);
                                RECID = Guid.NewGuid();
                                command.Parameters.AddWithValue("Id", RECID);
                                command.Parameters.AddWithValue("MealName", txtYemekAdi.Text);
                                command.Parameters.AddWithValue("CategoryId", ddlKategori.SelectedValue);
                                command.Parameters.AddWithValue("NumberPeople", kacKisilik);
                                command.Parameters.AddWithValue("CookingTime", Sure);
                                command.Parameters.AddWithValue("MealPic", resimler.New);
                                command.Parameters.AddWithValue("Description", txtDescriptipon.Text);

                                if (ddlKategori.SelectedValue == " 0")
                                {

                                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Kategori Seçiniz Lütfen');", true);

                                }

                                else
                                {
                                    command.ExecuteNonQuery();
                                    command.Parameters.Clear();

                                }


                                foreach (YemeginMalzemeleri malzeme in YEMEGINMALZEMELERI)
                                {
                                    command.CommandText = "INSERT INTO MEAL_INGREDIENT(Id,MealId,Amount,ScaleId,IngredientId) VALUES (@Id,@MealId,@Amount,@ScaleId,@IngredientId)";
                                    Guid MealIngredientId = Guid.NewGuid();
                                    command.Parameters.AddWithValue("Id", MealIngredientId);
                                    command.Parameters.AddWithValue("MealId", RECID);
                                    command.Parameters.AddWithValue("Amount", malzeme.amount);
                                    command.Parameters.AddWithValue("ScaleId", malzeme.scaleId);
                                    command.Parameters.AddWithValue("IngredientId", malzeme.ingredientId);
                                    command.ExecuteNonQuery();
                                    command.Parameters.Clear();
                                }

                                Response.Redirect("YemekDetay.aspx?Id=" + RECID);
                                conn.Close();

                            }
                            else
                            {
                                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Boş Yerleri Doldurunuz');", true);
                            }
                            Temizle(txtHazirlama);
                            Temizle(txtKacKisi);
                            Temizle(txtYemekAdi);


                        }
                    }
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Boş olan yerleri doldurun ve tekrar kaydedin');", true);
                }

            }


        }



        protected void DropDownCategory()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string selectSQL = "SELECT *  FROM CATEGORY";

            SqlCommand command = new SqlCommand(selectSQL, con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlKategori.DataTextField = ds.Tables[0].Columns["CategoryName"].ToString();
            ddlKategori.DataValueField = ds.Tables[0].Columns["Id"].ToString();
            ddlKategori.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            ddlKategori.DataBind();
            ddlKategori.Items.Insert(0, new ListItem("Kategori Seçiniz", "0"));

        }

        protected void Temizle(TextBox box)
        {
            box.Text = string.Empty;
        }


        protected void btnAutoEkle_Click(object sender, EventArgs e)
        {

            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            string sqlQuery = "SELECT * FROM SCALE WHERE ScaleName LIKE '%" + txtSearchAutoComplete.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                string queryIngredient = "INSERT INTO SCALE (ScaleName) VALUES (@ScaleName)";
                SqlCommand command = new SqlCommand(queryIngredient, connection);
                string scaleName = txtSearchAutoComplete.Text;
                command.Parameters.AddWithValue("ScaleName", scaleName);
                try
                {

                    command.ExecuteNonQuery();

                    connection.Close();

                }
                catch
                {
                }

            }
            else if (txtIngredientSearch.Text == string.Empty)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Boş Yerleri Doldurunuz');", true);
            }
            Temizle(txtSearchAutoComplete);


        }


        protected void btnIngredientSearch_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            string sqlQuery = "SELECT * FROM INGREDIENT WHERE IngredientName LIKE '%" + txtIngredientSearch.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);


            if (table.Rows.Count == 0)
            {
                string queryIngredient = "INSERT INTO INGREDIENT (IngredientName) VALUES (@IngredientName)";
                SqlCommand command = new SqlCommand(queryIngredient, connection);
                string ingredientName = txtIngredientSearch.Text;
                command.Parameters.AddWithValue("IngredientName", ingredientName);
                try
                {

                    command.ExecuteNonQuery();

                    connection.Close();

                }
                catch
                {

                }


            }
            else if (txtIngredientSearch.Text == string.Empty)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Boş Yerleri Doldurunuz');", true);
            }
            Temizle(txtIngredientSearch);

        }

        protected void btnListeyeEkle_Click(object sender, EventArgs e)
        {
            if ((txtAdet.Text != string.Empty) && hdnScaleID.Value != string.Empty && hdnIngredientID.Value != string.Empty)
            {
                Guid IngID = Guid.NewGuid();
                YEMEGINMALZEMELERI.Add(new YemeginMalzemeleri(
                                            true,
                                            IngID,
                                            int.Parse(hdnScaleID.Value),
                                            int.Parse(hdnIngredientID.Value),
                                            txtScale.Text,
                                            txtIngredient.Text,
                                            txtAdet.Text

                                            ));

                ingredientRepeater.DataSource = YEMEGINMALZEMELERI;
                ingredientRepeater.DataBind();

            }
            else
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Boş Yerleri Doldurunuz');", true);

            }
            Temizle(txtAdet);
            Temizle(txtIngredient);
            Temizle(txtScale);


        }
        protected void btnResimKaydet_Click(object sender, EventArgs e)
        {

            btnResimSil.Visible = true;

            if (flResim.HasFile)
            {
                Guid PicID = Guid.NewGuid();
                flResim.SaveAs(Server.MapPath("../Pictures//KapakResmi//" + PicID + ".jpg"));
                resimler.New= PicID;
                imgYemekResim.ImageUrl = "../Pictures//KapakResmi//" + resimler.New+ ".jpg";
            }

        }

        protected void ingredientRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            YemeginMalzemeleri temp = YEMEGINMALZEMELERI.Single(m => m.ID == Guid.Parse(e.CommandArgument.ToString()));
            if (temp != null)
            {
                if (e.CommandName == "Delete")
                {
                    if (!temp.yeniMi)
                    {
                        string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                        SqlConnection connection = new SqlConnection(conString);
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM MEAL_INGREDIENT WHERE Id=@Id", connection);
                        cmd.Parameters.AddWithValue("Id", temp.ID);
                        cmd.ExecuteNonQuery();
                    }
                    YEMEGINMALZEMELERI.Remove(temp);
                    ingredientRepeater.DataSource = YEMEGINMALZEMELERI;
                    ingredientRepeater.DataBind();
                    upIngredients.Update();
                }
            }
        }

        protected void btnIptal_Click(object sender, EventArgs e)
        {
            
            string dosyaYolu = Server.MapPath("../Pictures//KapakResmi//" + resimler.New+ ".jpg");
            if (File.Exists(dosyaYolu))
            {
                File.Delete(dosyaYolu);
            }
          
            Response.Redirect("Default.aspx");
        }

        protected void btnResimSil_Click(object sender, EventArgs e)
        {
            string dosyaYolu = Server.MapPath("../Pictures//KapakResmi//" + resimler.New+ ".jpg");
            if (File.Exists(dosyaYolu))
            {
                File.Delete(dosyaYolu);
            }
            btnResimSil.Visible = false;
        }

        protected void btnKategori_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(conString);


            if (txtKategoriModal.Text == string.Empty)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Lütfen Boş Alanı Doldurun');", true);

            }
         else
            {
                {
                    string sqlquery = "INSERT INTO CATEGORY (CategoryName) VALUES (@CategoryName)";
                    SqlCommand command = new SqlCommand(sqlquery, conn);

                    string categoryName = txtKategoriModal.Text;
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
            DropDownCategory();
        }



    }
}
