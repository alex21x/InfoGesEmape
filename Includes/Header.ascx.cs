#region Using Directives
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
#endregion

namespace InfogesEmape.Includes
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                this.lblUser.Text = "Usuario   : [" + Context.User.Identity.Name + "]";
                this.lblOperador.Text = "Ejecutora : [No Seleccionada]";
                if (Session["IdSecEjecDesc"] != null)
                {
                    this.lblOperador.Text = "Ejecutora : [" + (string)(Session["SecEjecId"]).ToString() + "-" + (string)(Session["IdSecEjecDesc"]).ToString() + "]";
                    this.IdLogo.ImageUrl = "~//Images//" + (string)(Session["IdBaseDeDatos"]) + ".jpg";
                }

                if (!Page.IsPostBack)
                {				
				DataRow dr1 = Code.Data.Accounts.User.Get(Context.User.Identity.Name.ToString());
                    int userId = int.Parse(dr1["user_id"].ToString());
                    DataSet ds1 = Code.Data.Accounts.User.GetPermissions(Code.Data.Accounts.User.GetRoleId(userId));
                    BuildMenu(ASPxMenu2, ds1);
                    

                }
        }



        protected void BuildMenu(DevExpress.Web.ASPxMenu menu, DataSet ds1)
        {

            int end = ds1.Tables[0].Rows.Count;
            for (int i = 0; i < end; i++)
            {
                if (Convert.ToInt16(ds1.Tables[0].Rows[i]["level3_id"]) > 0)
                {
                DevExpress.Web.MenuItem item = CreateMenuItem(ds1.Tables[0].Rows[i]["title_short"].ToString(), ds1.Tables[0].Rows[i]["Link"].ToString());
                menu.Items.Add(item);
                }

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }


        private DevExpress.Web.MenuItem CreateMenuItem(string ptitle, string plink)
        {
            DevExpress.Web.MenuItem ret = new DevExpress.Web.MenuItem();
            ret.Text = ptitle.ToString();
            ret.NavigateUrl = plink.ToString();
            return ret;
        }

    }
}