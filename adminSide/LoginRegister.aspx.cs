using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace YemekSitesi.adminSide
{
    public partial class LoginRegister : BasePage
    {

        protected override void OnPreInit(EventArgs e)
        {
            isRegisterForm = true;
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {

            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            // Bağlantı açıldığında çalışacak sql sorgusu için cmd nesnesi oluşturulur:                  
            SqlCommand cmd = new SqlCommand("INSERT INTO USERS(Id,Name,Surname,MD5Sifreleme,Email) VALUES (@id,@ad,@soyad,@sifre,@email)", conn);

            // TextBox'lardan alınan bilgiler etiketlere, oradan da sorguya gönderilir:
            Guid userId = Guid.NewGuid();
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.Parameters.AddWithValue("@ad", txtUserName.Text);
            cmd.Parameters.AddWithValue("@soyad", txtSurName.Text);
            cmd.Parameters.AddWithValue("@sifre", MD5Sifrele(txtPsswrd.Text));
            if (IsValidEmailAddress(txtEmail.Text))
            {
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            }
            else
            {
                Response.Write("<script>alert('Mail Adresini Doğru Giriniz!!!')</script>");
            }
           
            try
            {


                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Kayıt Yapıldı !!!')</script>");
                Temizle(txtUserName);
                Temizle(txtSurName);
                Temizle(txtPsswrd);
                Temizle(txtEmail);
            }
            catch 
            {
                Response.Write("<script>alert('Mail Adresiniz Kullanılmaktadır !!!')</script>");
                Temizle(txtUserName);
                Temizle(txtSurName);
                Temizle(txtPsswrd);
                Temizle(txtEmail);
            }
            conn.Close();

            

    }




        protected void Temizle(TextBox box)
        {
            box.Text = string.Empty;
        }

        public static bool IsValidEmailAddress(string emailaddress)

           {

      return Regex.IsMatch(emailaddress, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            }


       

    }
}
