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

namespace AdieraManager.Modules.MainData
{
	/// <summary>
	/// Summary description for Subscribers_List.
	/// </summary>
	public class AccountsUsers_List : AdieraManager.Modules.stAdminPage
	{
		protected System.Web.UI.WebControls.Label lblTotal;
		protected System.Web.UI.WebControls.DataGrid grdData;
		protected bool blnValidPermission=false;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//TODO Rev. 04/10/2004 01:18:00 Ingresar en la demas paginas la validacion de los permisos
			if (Context.User.Identity.IsAuthenticated && ((Bussiness.Accounts.SitePrincipal)Context.User).HasPermission((int)MainDataPermissions.AccountsUsers)) 
			{
				blnValidPermission=true;
			}

			if (!Page.IsPostBack) 
			{
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
			
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ShowData()
		{
			if (!blnValidPermission) return;
			Bussiness.Accounts.User objData =new Bussiness.Accounts.User();
			DataSet dsResult = objData.GetUserList(); 
			this.grdData.DataSource = dsResult;
			this.grdData.DataBind();
			this.lblTotal.Text = System.Convert.ToString(dsResult.Tables[0].Rows.Count);
			objData=null;
		}


	}
}
