using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSitesi.classes
{
    public class GununMenusu
    {
        public Guid ID { get; set; }
        public Guid MealID { get; set; }
        public string MealName { get; set; }
        public bool Status { get; set; }

        public GununMenusu()
        {

        }
        public GununMenusu(Guid ID, Guid MealID, string MealName, bool Status)
        {
            this.ID = ID;
            this.MealID = MealID;
            this.MealName = MealName;
            this.Status = Status;
        }
    }
}