using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSitesi
{
    [Serializable]
    public class Meal
    {
        public Guid Id { get; set; }
        public string MealName { get; set; }
        public byte CategoryId { get; set; }
        public DateTime Date { get; set; }
        public byte NumberPeople { get; set; }
        public byte CookingTime { get; set; }
        public Guid MealPic { get; set; }
        public string Description { get; set; }

        public bool Status { get; set; }
        public Meal() { }

        public Meal(Guid Id, string MealName, byte CategoryId, byte NumberPeople, byte CookingTime, Guid MealPic, string Description,bool Status)
        {
            this.Id = Id;
            this.MealName = MealName;
            this.CategoryId = CategoryId;
            this.NumberPeople = NumberPeople;
            this.CookingTime = CookingTime;
            this.MealPic = MealPic;
            this.Description = Description;
            this.Status = Status;
          
        }

    }
}