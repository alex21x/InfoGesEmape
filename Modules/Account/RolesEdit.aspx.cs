#region Using Declaratives
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
#endregion

namespace InfogesEmape.Modules.Account
{
    public partial class RolesEdit : System.Web.UI.Page
    {
        private string rolId;

        protected void Page_Load(object sender, EventArgs e)
        {
     
            InfogesEmape.Modules.MasterPage m = (InfogesEmape.Modules.MasterPage)Page.Master;
            //m.SetTitleText = "Editando Rol";
            rolId = "" + Request.Params["pId"];
            if (!Page.IsPostBack)
            {
                ShowRoleDestiny();
                ShowRoleSource();
            }
        }

        #region Private Methods

        private void ShowRoleDestiny()
        {
            this.trwRoleDestiny.Nodes.Clear();
            //TreeNode nodeLevel1 = new TreeNode();
            //nodeLevel1.Text = "";
            //nodeLevel1.Value = "";
            DataSet ds1 = Code.Data.Accounts.User.GetPermissions(int.Parse(rolId));
            this.XmlDataSource1.Data = Code.Logic.Accounts.User.CreateXmlMenu_Roles(ds1);
            this.XmlDataSource1.DataBind();
            this.trwRoleDestiny.DataBind();
            ds1.Dispose();
            ds1 = null;
        }
        private void ShowRoleSource()
        {
            DataSet ds1 = Code.Data.Accounts.User.GetAllPermissions();
            this.trwRoleSource.Nodes.Clear();
            this.XmlDataSource2.Data = Code.Logic.Accounts.User.CreateXmlMenu_Roles(ds1);
            this.XmlDataSource2.DataBind();
            this.trwRoleSource.DataBind();
            ds1.Dispose();
            ds1 = null;
        }

        #endregion

        #region Events
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Eliminar rol
            int i = Code.Logic.Accounts.Role.Delete(rolId);
            if (i == 0)
            {
                Response.Redirect("~/Modules/Account/Roles.aspx");
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            //Cerrar
            Response.Redirect("~/Modules/Account/Roles.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //Add
            TreeNode trwNode = null;
            trwNode = trwRoleSource.SelectedNode;
            if (trwNode!=null)
            {
                string level3Id = trwNode.Value.ToString();
                string level2Id = trwNode.Parent.Value.ToString();
                string level1Id = trwNode.Parent.Parent.Value.ToString();
                int i = Code.Logic.Accounts.Role.AddPermission(rolId, level1Id, level2Id, level3Id);
                ShowRoleDestiny();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Delete
            TreeNode trwNode = null;
            trwNode = trwRoleDestiny.SelectedNode;
            if (trwNode != null)
            {
                string level3Id = trwNode.Value.ToString();
                int total3 = trwNode.Parent.ChildNodes.Count;
                string level2Id = trwNode.Parent.Value.ToString();
                int total2 = trwNode.Parent.Parent.ChildNodes.Count;
                string level1Id = trwNode.Parent.Parent.Value.ToString();
                int i = Code.Logic.Accounts.Role.RemovePermission(rolId, level1Id, level2Id, level3Id, total2, total3);
                ShowRoleDestiny();
            }
        }
        #endregion

    }
}
