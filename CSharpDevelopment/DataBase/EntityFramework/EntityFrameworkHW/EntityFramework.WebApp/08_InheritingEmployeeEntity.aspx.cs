using System;
using System.Linq;
using EntityFramework.Data;

namespace EntityFramework.WebApp
{
    public partial class InheritingEmployeeEntity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Implement previous by using native SQL query and executing it through the DbContext<br>");

            grdResult.DataSource = SessionState.db.Employees.FirstOrDefault().TerritoriesSet;
            grdResult.DataBind();


        }
    }
}