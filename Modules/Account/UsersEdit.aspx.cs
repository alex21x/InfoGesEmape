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
    public partial class UsersEdit : System.Web.UI.Page
    {

        private string userId;

        protected void Page_Load(object sender, EventArgs e)
        {

            InfogesEmape.Modules.MasterPage m = (InfogesEmape.Modules.MasterPage)Page.Master;
            //m.SetTitleText = "Editando Usuario";
            userId = "" + Request.Params["pId"];
            if (!Page.IsPostBack)
            {
                ShowRoles();
                ShowData();
                ShowDataEjecutora();
            }
        }

        #region Private Methods

        private void ShowData()
        {
            DataRow dr1 = Code.Logic.Accounts.User.Get(userId);
            this.txtUserName.Text = dr1["user_name"].ToString();
            this.txtDescription.Text = dr1["description"].ToString();
            this.txtEmailAddress.Text = dr1["email_address"].ToString();
            ListItem lstItemStatus = new ListItem();
            lstItemStatus = cboStatus.Items.FindByValue(dr1["status"].ToString());
            lstItemStatus.Selected = true;
            this.cboUserRoles.DataSource = Code.Logic.Accounts.User.GetUserRoles(userId);
            this.cboUserRoles.DataTextField = "description";
            this.cboUserRoles.DataValueField = "role_id";
            this.cboUserRoles.DataBind();
            if (this.cboUserRoles.Items.Count > 0) 
                this.cboUserRoles.Items[0].Selected = true;
        }
        private void ShowRoles()
        {
            this.cboRoles.DataSource = Code.Logic.Accounts.Role.GetRoleList();
            this.cboRoles.DataTextField = "description";
            this.cboRoles.DataValueField = "role_id";
            this.cboRoles.DataBind();
            if (this.cboRoles.Items.Count > 0)
                this.cboRoles.Items[0].Selected = true;
        }

        private void ShowDataEjecutora()
        {
            this.CboUjecutoraSeleccionadas.DataSource = Code.Logic.Forms.Consulta.Ejecutora.GetUserEjecutora(userId);
            this.CboUjecutoraSeleccionadas.DataTextField = "NOMBRE";
            this.CboUjecutoraSeleccionadas.DataValueField = "SEC_EJEC";
            this.CboUjecutoraSeleccionadas.DataBind();
            if (this.CboUjecutoraSeleccionadas.Items.Count > 0)
                this.CboUjecutoraSeleccionadas.Items[0].Selected = true;

            this.cboEjecutoras.DataSource = Code.Logic.Forms.Consulta.Ejecutora.SearchEjecutora1();
            this.cboEjecutoras.DataTextField = "NOMBRE";
            this.cboEjecutoras.DataValueField = "SEC_EJEC";
            this.cboEjecutoras.DataBind();
            if (this.cboEjecutoras.Items.Count > 0)
                this.cboEjecutoras.Items[0].Selected = true;
        }
        #endregion

        #region Events
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Actualizando datos
            if (Page.IsValid)
            {
                if (this.cboUserRoles.Items.Count > 0)
                {
                    /*string[] parameters = 
                    { 
                        userId,
                        this.txtDescription.Text,
                        this.txtEmailAddress.Text,
                        txtPassword01.Value,
                        this.cboStatus.Value
                    };
                    int i = Code.Logic.Accounts.User.Update(parameters);*/
                    Code.Logic.Accounts.User.RemoveRole(userId, this.cboUserRoles.Value);

                    for (int intIndex = 0; intIndex < this.cboUserRoles.Items.Count; intIndex++)
                        Code.Logic.Accounts.User.AddRole(userId, this.cboUserRoles.Items[intIndex].Value.ToString());
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
            Code.Logic.Accounts.User.AddRole(userId, this.cboUserRoles.Items[0].Value);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Delete Rol
            Code.Logic.Accounts.User.RemoveRole(userId, this.cboUserRoles.Items[0].Value);
            ListDelete(this.cboUserRoles);
            
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            //Cancelar
            Response.Redirect("~/Modules/Account/Users.aspx");

        }


        protected void onClickAddEjecutora(object sender, EventArgs e)
        {
            //Add Rol
            ListAdd(this.cboEjecutoras,this.CboUjecutoraSeleccionadas);
            Code.Logic.Accounts.User.AddEjecutora(userId, this.cboEjecutoras.Items[cboEjecutoras.SelectedIndex].Value);

        }

        protected void onClickRemoveEjecutora(object sender, EventArgs e)
        {
            //Delete Rol
            Code.Logic.Accounts.User.RemoveEjecutora(userId, this.CboUjecutoraSeleccionadas.Items[0].Value);
            ListDelete(this.CboUjecutoraSeleccionadas);

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



        protected void Button5_Click(object sender, EventArgs e)
        {
            //Delete el usuario
            int i = Code.Logic.Accounts.User.Delete(this.userId);
            //Aubillus
            //if (1==0)
                //Response.Redirect("~/Modules/Account/Users.aspx");

        }

    }
}
