using System;
using System.Data;
using System.Data.SqlClient;
using AdoNet.Data;

namespace ADONET.WebApp
{
    public partial class GetNameAndDescriptionFromCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Write a program that retrieves the name and description of all categories in the Northwind DB<br>");

            string query = "SELECT CategoryName, Description from [dbo].[Categories]";
            boFunctions.ExecuteSqlQueryReturnValue(query, null, CommandType.Text, delegate(SqlDataReader reader)
                {
                    grdResult.DataSource = reader;
                    grdResult.DataBind();
                });
        }
    }
}