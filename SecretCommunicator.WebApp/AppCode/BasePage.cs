using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecretCommunicator.WebData;

namespace SecretCommunicator.WebApp.AppCode
{
    public class BasePage : System.Web.UI.Page
    {
        boSessionState _sessionState = new boSessionState();
        public boSessionState SessionState
        {
            get { return _sessionState; }
            set { _sessionState = value; }
        }

        #region Page Events
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["sessionState"] != null)
                _sessionState = (boSessionState)Session["sessionState"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
            SaveSession();
        }
        #endregion // Page Events

        protected void SaveSession()
        {
            Session["sessionState"] = _sessionState;
        }
    }
}