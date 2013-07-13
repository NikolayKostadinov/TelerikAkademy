using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityFramework.Data;

namespace EntityFramework.WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var dbSearch = db.Customers.ToList();
            foreach (var customer in dbSearch)
            {
                Response.Write(customer.ContactName + "<br />");
            }
        }
    }
}