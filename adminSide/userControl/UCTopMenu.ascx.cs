using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YemekSitesi.adminSide.userControl
{
    public partial class UCTopMenu : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnCıkış_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("/adminSide/Loginform.aspx");
        }
    }
}