using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSitesi
{
    [Serializable]
    public class GununMenusuYemekleri
    {
        public bool isNew { get; set; }
        public Guid ID { get; set; }
        public Guid MealID { get; set; }
        public string MealName { get; set; }
        public bool Status { get; set; }

        public DateTime Date { get; set; }
 

        public GununMenusuYemekleri()
        {

        }
        public GununMenusuYemekleri( bool isNew,Guid ID, Guid MealID, string MealName, bool Status, DateTime Date)
        {
            this.isNew = isNew;
            this.ID = ID;
            this.MealID = MealID;
            this.MealName = MealName;
            this.Status = Status;
            this.Date = Date;
           
        }

        public Guid Id { get; set; }
    }
}