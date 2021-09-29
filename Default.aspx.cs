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

namespace InfogesEmape
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {


            Session["IdTipoConexion"] = ConfigurationManager.AppSettings.Get("IdTipoConexion");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session.Contents.RemoveAll();
            if (Page.IsValid)
            {
                Code.Logic.Accounts.SitePrincipal oUser = Code.Logic.Accounts.SitePrincipal.ValidateLogin(this.TextBox1.Text, this.TextBox2.Text, true);

                if (oUser == null)
                {
                    this.lblMessageLogin.Visible = true;
                    this.lblMessageLogin.Text = "Acceso fallido para el usuario " + this.TextBox1.Text;
                }
                else
                { 


                    Context.User = oUser;
                    DataSet r1;
                    int r = Code.Data.Accounts.User.Validate(this.TextBox1.Text, this.TextBox2.Text);
                    Session["IdPersonal"] = r.ToString();
                    r1 = Code.Data.Accounts.User.Validate1(r.ToString());

                     if (r1.Tables[0].Rows.Count == 1)
                     {
                         Session["SecEjecId"] = r1.Tables[0].Rows[0][0].ToString();
                         Session["IdSecEjecDesc"] = r1.Tables[0].Rows[0][1].ToString();
                         Session["IdBaseDeDatos"] = r1.Tables[0].Rows[0][2].ToString();
                         Session["EsEncargante"] = r1.Tables[0].Rows[0][3].ToString();
                         Session["IsUnico"] = 0;
                         Session["IdDni"] = this.TextBox2.Text;
                         FormsAuthentication.SetAuthCookie(this.TextBox1.Text, true);
                         string lPag = "";
                         if (this.TextBox1.Text == "GESOSUPERVISOR" || this.TextBox1.Text == "GESOCONTRATISTA")
                        {
                            r = 100;
                        }
                         if (this.TextBox1.Text == "GESOCOORDINADOR")
                        {
                            r = 101;
                        }
                         
                          
                         switch (r.ToString())
                         {
                             case "44":
                                 lPag = "~/Modules/Forms/Consulta/InfoGesDashBoardObrasGG.aspx";
                                 break;
                             case "45":
                                 lPag = "~/Modules/Forms/Consulta/InfoGesDashBoardObrasGG.aspx";
                                 break;
                             case "100":
                                 lPag = "~/Modules/Forms/Seguimiento/frmInfoGesGSOProyectoCoordinador.aspx";
                                 break;
                            case "101":
                                lPag = "~/Modules/Forms/Seguimiento/frmInfoGesGsoProyectoRegistroCoordinador_2.aspx";
                                break;
                            default:
                                 lPag = "~/Modules/Content.aspx";

                                 break;
                         }


                         Response.Redirect(lPag);

                         
                     }
                     else
                     {
                         Session["SecEjecId"]       = null;
                         Session["IdSecEjecDesc"]   = null;
                         Session["IdBaseDeDatos"]   = null;
                         Session["EsEncargante"]    = null;
                         Session["IsUnico"] = null;
                     }


                }
            }

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
