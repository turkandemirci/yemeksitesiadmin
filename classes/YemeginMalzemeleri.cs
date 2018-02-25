using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSitesi
{
    [Serializable]
    public class YemeginMalzemeleri
    {
        public bool yeniMi { get; set; }
        public Guid ID { get; set; }
        public int scaleId { get; set; }
        public int ingredientId { get; set; }
        public string scaleName { get; set; }
        public string ingredientName { get; set; }
        public string amount { get; set; }
        public YemeginMalzemeleri()
        {

        }
        public YemeginMalzemeleri(bool yeniMi, Guid ID, int scaleId, int ingredientId, string scaleName, string ingredientName, string amount)
        {
            this.yeniMi = yeniMi;
            this.ID = ID;       
            this.scaleId = scaleId;
            this.ingredientId = ingredientId;
            this.scaleName = scaleName;
            this.ingredientName = ingredientName;
            this.amount = amount;
        }

    }
}