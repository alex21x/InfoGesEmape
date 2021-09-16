#region Using Declaratives
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

namespace InfogesEmape.Modules.Account
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InfogesEmape.Modules.MasterPage m = (InfogesEmape.Modules.MasterPage)Page.Master;
            //m.SetTitleText = "Natenimiento de Usuarios";
            if (!Page.IsPostBack)
            {
                ShowData();
            }
        }

        #region ShowData
        private void ShowData()
        {
            DataSet ds1 = Code.Logic.Accounts.User.GetUserList();
            this.grdData.DataSource = ds1;
            this.grdData.DataBind();
            this.lblTotal.Text = System.Convert.ToString(ds1.Tables[0].Rows.Count);
        }
        #endregion
    }
}
