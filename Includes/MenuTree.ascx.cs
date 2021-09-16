#region Using
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
#endregion


namespace InfogesEmape.Includes
{
    public partial class MenuTree : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String lcCad = "";
                if (Context.User.Identity.IsAuthenticated)
                    lcCad = Context.User.Identity.Name.ToString();
                else
                    lcCad = "9999";
                //Code.Logic.Accounts.SitePrincipal o1 = new Code.Logic.Accounts.SitePrincipal(lcCad, (IsMobile(Request.UserAgent)));
                Code.Logic.Accounts.SitePrincipal o1 = new Code.Logic.Accounts.SitePrincipal(lcCad, true);
                this.XmlDataSource1.Data = o1.XmlMenuTree();
                this.XmlDataSource1.DataBind();
                o1 = null;
            }
        }
        public static bool IsMobile(string userAgent)
        {
            userAgent = userAgent.ToLower();
            return userAgent.Contains("iphone") ||
                  userAgent.Contains("ppc") ||
                  userAgent.Contains("windows ce") ||
                  userAgent.Contains("blackberry") ||
                  userAgent.Contains("opera mini") ||
                  userAgent.Contains("mobile") ||
                  userAgent.Contains("palm") ||
                  userAgent.Contains("portable");
        } 
    }


}
