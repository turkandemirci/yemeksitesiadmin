using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;


namespace YemekSitesi.WebService
{
    /// <summary>
    /// ScaleService için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
     [System.Web.Script.Services.ScriptService]
    public class ScaleService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<NAutoComplete> GetScaleName(string query)
        {
            List<NAutoComplete> scaleList = new List<NAutoComplete>();
            NAutoComplete scaleAuto = null;

            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT TOP (10) Id,ScaleName FROM SCALE WHERE ScaleName like '%'+ @SearchText + '%' ";
                    command.Parameters.AddWithValue("@SearchText", query);
                    command.Connection = connection;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            scaleAuto = new NAutoComplete();
                            scaleAuto.value = reader["Id"].ToString();
                            scaleAuto.label = reader["ScaleName"].ToString();
                            scaleList.Add(scaleAuto);

                        }
                    }
                    connection.Close();
                }
            }
            return scaleList;

        }
    }
}
