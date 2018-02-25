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
    /// ServiceForAutocomplete için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    [System.Web.Script.Services.ScriptService]
    public class ServiceForAutocomplete : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<NAutoComplete> GetIngredientName(string query)
        {
            List<NAutoComplete> ingredientList = new List<NAutoComplete>();
            NAutoComplete ingredientAuto = null;
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT TOP (10) Id,IngredientName FROM INGREDIENT WHERE IngredientName like '%'+ @SearchText + '%' ";
                    command.Parameters.AddWithValue("@SearchText", query);
                    command.Connection = connection;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ingredientAuto = new NAutoComplete();
                            ingredientAuto.value = reader["Id"].ToString();
                            ingredientAuto.label = reader["IngredientName"].ToString();
                            ingredientList.Add(ingredientAuto);
                        }
                    }
                    connection.Close();
                }
            }
            return ingredientList;
             }
    }

}