using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSitesi
{

    [Serializable]
    public class MealPic
    {
        public Guid New { get; set; }
        public Guid Old { get; set; }

        public MealPic() { }
        public MealPic(Guid New, Guid Old)
        {
            this.New = New;
            this.Old = Old;
        }
    }
}