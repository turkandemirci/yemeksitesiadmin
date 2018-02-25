using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace YemekSitesi
{
    public class BasePage : System.Web.UI.Page
    {

        public static string MD5Sifrele(string metin)
        {
            // MD5CryptoServiceProvider nesnenin yeni bir instance'sını oluşturalım.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //Girilen veriyi bir byte dizisine dönüştürelim ve hash hesaplamasını yapalım.
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);

            //byte'ları biriktirmek için yeni bir StringBuilder ve string oluşturalım.
            StringBuilder sb = new StringBuilder();


            //hash yapılmış her bir byte'ı dizi içinden alalım ve her birini hexadecimal string olarak formatlayalım.
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürelim.
            return sb.ToString();
        }
        public bool isLoginForm = false;
        public bool isRegisterForm = false;

        protected override void OnInit(EventArgs e)
        {
            if (User.ID == Guid.Empty && !isLoginForm && !isRegisterForm)
            {
                Response.Redirect("/adminSide/LoginForm.aspx");
            }
            base.OnInit(e);
        }


  



        public Kullanıcı User
        {
            get
            {
                if (Session["Id"] == null)
                    Session["Id"] = new Kullanıcı();
                return Session["Id"] as Kullanıcı;
            }
            set
            {
                Session["Id"] = value;
            }
        }
    }
}