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
    /// Summary description for GununMenusuWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class GununMenusuWebService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<NAutoComplete> GetMealName(string query)
        {
            List<NAutoComplete> mealList = new List<NAutoComplete>();
            NAutoComplete mealAuto = null;

            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT TOP (10) Id,MealName FROM MEAL WHERE MealName like '%'+ @SearchText + '%' AND Status=1 ";
                    command.Parameters.AddWithValue("@SearchText", query);
                    command.Connection = connection;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mealAuto = new NAutoComplete();
                            mealAuto.value = reader["Id"].ToString();
                            mealAuto.label = reader["MealName"].ToString();
                            mealList.Add(mealAuto);

                        }
                    }
                    connection.Close();
                }
            }
            return mealList;

        }
    }
}
