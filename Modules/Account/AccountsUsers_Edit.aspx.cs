using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Bussiness = BuildSolutionsIT.Adiera.Server.Logic;
using Libraries = BuildSolutionsIT.Libraries;

namespace AdieraManager.Modules.MainData
{
	/// <summary>
	/// Summary description for Users_Edit.
	/// </summary>
	public class AccountsUsers_Edit : AdieraManager.Modules.stAdminPage
	{
		private int vntUserId;
		protected System.Web.UI.HtmlControls.HtmlInputText txtDescription;
		protected System.Web.UI.HtmlControls.HtmlSelect cboStatus;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPassword01;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPassword02;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdSave;
		protected System.Web.UI.HtmlControls.HtmlInputButton idDelete;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdAdd;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdDelete;
		protected System.Web.UI.HtmlControls.HtmlInputText txtEmailAddress;
		protected System.Web.UI.HtmlControls.HtmlSelect cboUserRoles;
		protected System.Web.UI.HtmlControls.HtmlSelect cboRoles;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Label lblUser;
		protected bool blnValidPermission=false;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Context.User.Identity.IsAuthenticated && ((Bussiness.Accounts.SitePrincipal)Context.User).HasPermission((int)MainDataPermissions.AccountsUsers)) 
			{
				blnValidPermission=true;
			}

			if (Request.Params["vntUserId"] != "") 
			{
				vntUserId = int.Parse(System.Convert.ToString(Request.Params["vntUserId"]));
			}
			if (!Page.IsPostBack) {
				ShowRoles();
				ShowData();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			base.OnInit(e);
			InitializeComponent();
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdSave.ServerClick += new System.EventHandler(this.cmdSave_ServerClick);
			this.idDelete.ServerClick += new System.EventHandler(this.idDelete_ServerClick);
			this.cmdAdd.ServerClick += new System.EventHandler(this.cmdAdd_ServerClick);
			this.cmdDelete.ServerClick += new System.EventHandler(this.cmdDelete_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ShowRoles()
		{
			this.cboRoles.DataSource = Bussiness.Accounts.Tools.GetRoleList();
			this.cboRoles.DataTextField = "description";
			this.cboRoles.DataValueField = "role_id";
			this.cboRoles.DataBind(); 
			this.cboRoles.Items[0].Selected = true;
		}

		private void cmdSave_ServerClick(object sender, System.EventArgs e)
		{
			if (!blnValidPermission) return;
			if (Page.IsValid) {
				Bussiness.Accounts.User objData = new Bussiness.Accounts.User();
				objData.UserId = vntUserId;
				objData.Description = this.txtDescription.Value;
				objData.EmailAddress = this.txtEmailAddress.Value;
				objData.Status = this.cboStatus.Value;
				if (this.txtPassword01.Value.Length > 0) {
					objData.Password = Libraries.Encryption.Core.EncryptPassword(txtPassword01.Value);
					objData.Update(1);
				}
				else objData.Update(2);
				objData.RemoveRole(); 
				for (int intIndex=0;intIndex<this.cboUserRoles.Items.Count;intIndex++) 
					objData.AddToRole(int.Parse(this.cboUserRoles.Items[intIndex].Value.ToString()));
				objData = null;
				Response.Redirect("/AdieraManager/Modules/MainData/AccountsUsers_List.aspx");
			}
		}

		private void idDelete_ServerClick(object sender, System.EventArgs e)
		{
			if (!blnValidPermission) return;
			Bussiness.Accounts.User objData = new Bussiness.Accounts.User();
			objData.UserId = vntUserId;
			if (objData.Delete()) 
				Response.Redirect("/AdieraManager/Modules/Subscriber/AccountsUsers_List.aspx") ;
		}

		private void ShowData() 
		{
			Bussiness.Accounts.User objData = new Bussiness.Accounts.User(vntUserId);
			this.txtDescription.Value = objData.Description;
			this.txtEmailAddress.Value = objData.EmailAddress;
			ListItem lstItemStatus = new ListItem();
			lstItemStatus = cboStatus.Items.FindByValue(objData.Status);
			lstItemStatus.Selected = true;
			lblUser.Text = objData.UserName; 
			this.cboUserRoles.DataSource = objData.GetUserRoles() ;
			this.cboUserRoles.DataTextField = "description";
			this.cboUserRoles.DataValueField = "role_id";
			this.cboUserRoles.DataBind(); 
			this.cboUserRoles.Items[0].Selected = true;
			objData = null;
 		}

		private void cmdAdd_ServerClick(object sender, System.EventArgs e)
		{
			Libraries.Web.Core.ListAdd(this.cboRoles,this.cboUserRoles); 
		}

		private void cmdDelete_ServerClick(object sender, System.EventArgs e)
		{
			Libraries.Web.Core.ListDelete(this.cboUserRoles); 
		}

	}
}
