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


namespace InfoGesRegional.Includes
{
    public partial class MenuTree11 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                //Code.Logic.Accounts.SitePrincipal o1 = new Code.Logic.Accounts.SitePrincipal("1");
                //this.XmlDataSource1.Data = o1.XmlMenuTree();
                //this.XmlDataSource1.DataBind();
                //o1 = null;
        }

        protected void EvtBound(object sender, EventArgs e)
        {

        }

        protected void EvtRender(object sender, EventArgs e)
        {

        }
    }
}
