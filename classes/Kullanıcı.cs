using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSitesi
{
    [Serializable]
    public class Kullanıcı
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string MD5Sifreleme { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public bool isAdmin { get; set; }

        public Kullanıcı()
        {

        }
        public Kullanıcı(Guid ID, string Name, string Surname, string Email, DateTime Date, bool isAdmin)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Date = Date;
            this.isAdmin = isAdmin;
        }

    }
}