using System;
using System.Linq;
using EntityFramework.Data;

namespace EntityFramework.WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dbSearch = SessionState.db.Customers.ToList();
            foreach (var customer in dbSearch)
            {
                Response.Write(customer.ContactName + "<br />");
            }
        }
    }
}