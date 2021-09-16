#region Using Declaratives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

namespace InfogesEmape.Modules.Account
{
    public partial class UsersCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            InfogesEmape.Modules.MasterPage m = (InfogesEmape.Modules.MasterPage)Page.Master;
            //m.SetTitleText = "Nuevo Usuario";
            if (!Page.IsPostBack)
            {
                ShowRoles();
            }
        }

        #region Private Methods
        private void ShowRoles()
        {
            this.cboRoles.DataSource = Code.Logic.Accounts.Role.GetRoleList();
            this.cboRoles.DataTextField = "description";
            this.cboRoles.DataValueField = "role_id";
            this.cboRoles.DataBind();
            this.cboRoles.Items[0].Selected = true;
        }
        #endregion

        #region Events
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (this.cboUserRoles.Items.Count > 0)
                {
                    string[] parameters = 
                    { 
                        this.txtDescription.Value,
                        this.txtEmailAddress.Value,
                        txtPassword01.Value,
                        this.txtUserName.Text,
                        this.cboStatus.Value
                    };
                    int i = Code.Logic.Accounts.User.Insert(parameters);

                    for (int intIndex = 0; intIndex < this.cboUserRoles.Items.Count; intIndex++)
                        Code.Logic.Accounts.User.AddRole(i.ToString(), this.cboUserRoles.Items[intIndex].Value.ToString());
                    Response.Redirect("~/Modules/Account/Users.aspx");
                }
                else
                    this.lblMessage.Text = "Requiere asignar un Rol al Usuario";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Add Rol
            ListAdd(this.cboRoles, this.cboUserRoles); 
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Delete Rol
            ListDelete(this.cboUserRoles); 
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            //Cancelar
            Response.Redirect("~/Modules/Account/Users.aspx");

        }
        #endregion

        #region ListAdd
        public static void ListAdd(System.Web.UI.HtmlControls.HtmlSelect cboSource, System.Web.UI.HtmlControls.HtmlSelect cboDestiny)
        {
            bool blnFound = false;
            string strSelectedText = cboSource.Items[cboSource.SelectedIndex].Text.ToString();
            string strSelectedValue = cboSource.Items[cboSource.SelectedIndex].Value.ToString();
            for (int intTemp = 0; intTemp < cboDestiny.Items.Count; intTemp++)
            {
                string strAux = cboDestiny.Items[intTemp].Value.ToString();
                if (strAux == strSelectedValue) blnFound = true;
            }
            if (!blnFound)
            {
                cboDestiny.Items.Add(strSelectedText);
                cboDestiny.Items[cboDestiny.Items.Count - 1].Value = strSelectedValue;
                if (cboDestiny.Items.Count == 1) cboDestiny.Items[0].Selected = true;
            }
        }
        #endregion

        #region ListDelete
        public static void ListDelete(System.Web.UI.HtmlControls.HtmlSelect cboDestiny)
        {
            if (cboDestiny.Items.Count > 0)
            {
                cboDestiny.Items.RemoveAt(cboDestiny.SelectedIndex);
                if (cboDestiny.Items.Count == 1) cboDestiny.Items[0].Selected = true;
            }
        }
        #endregion

    }
}
