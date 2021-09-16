using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace InfogesEmape.Modules
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


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
