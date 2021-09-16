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
    public partial class Roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowData();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Insertando Rol
            if (Page.IsValid)
            {
                int r = Code.Logic.Accounts.Role.Insert(this.txtRole.Text);
                Response.Redirect("~/Modules/Account/Roles.aspx");
            }
        }

        private void ShowData()
        {
            DataSet ds1 = Code.Logic.Accounts.Role.GetRoleList();
            this.grdData.DataSource = ds1;
            this.grdData.DataBind();
            this.lblTotal.Text = System.Convert.ToString(ds1.Tables[0].Rows.Count);
        }
    }
}
