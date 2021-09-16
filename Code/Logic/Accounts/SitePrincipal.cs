#region Using Directives
using System;
using System.Data;
using System.Collections;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

#endregion

namespace InfogesEmape.Code.Logic.Accounts
{
    public class SitePrincipal : System.Security.Principal.IPrincipal
    {
        #region Declatives Variables
        protected System.Security.Principal.IIdentity identity;
		protected ArrayList permissionList;
		protected ArrayList roleList;
		protected DataSet dsRolesPermis;
        protected string xmlMenuTree;
        protected string xmlMenuTreeMovil;

        #endregion

        #region Constructors
        public SitePrincipal(int userId, Boolean Smovil)
		{
			identity = new SiteIdentity( userId );
            GetMenu(userId,Smovil);

		}

        public SitePrincipal(string userName, Boolean Smovil)
		{
            identity = new SiteIdentity(userName);
            DataRow dr1 = Code.Data.Accounts.User.Get(userName);
            int userId = int.Parse(dr1["user_id"].ToString());
            GetMenu(userId,Smovil);

        }
        #endregion

        #region Methods
        private void GetMenu(int userId, Boolean Smovil )
        {
            DataSet ds1 = Code.Data.Accounts.User.GetPermissions(Code.Data.Accounts.User.GetRoleId(userId));
            //if(Smovil)
            //    this.xmlMenuTreeMovil = Code.Logic.Accounts.User.CreateXmlMenuMovil(ds1);
            //else
                this.xmlMenuTree = Code.Logic.Accounts.User.CreateXmlMenuDD(ds1);
            //this.xmlMenuTree = Code.Logic.Accounts.User.CreateXmlMenu(ds1);

        }
        public static SitePrincipal ValidateLogin(string userName, string password, Boolean Smovil)
		{
            int result = Code.Data.Accounts.User.Validate(userName, password);
            if (result > -1)
                return new SitePrincipal(result,Smovil);
            else
                return null;	
		}		
        #endregion

        #region Attributes
        public System.Security.Principal.IIdentity Identity
        {
            get
            {
                return identity;
            }
            set
            {
                identity = value;
            }
        }

        public bool IsInRole(string strRole)
        {
            return roleList.Contains(strRole);
        }

        public bool HasPermission(int intPermissionId)
        {
            return permissionList.Contains(intPermissionId);
        }

        public string XmlMenuTree()
        {
            return this.xmlMenuTree;
        }
        
        public string XmlMenuTreeMovil()
        {
            return this.xmlMenuTreeMovil;
        }

        public ArrayList Roles
        {
            get
            {
                return roleList;
            }
        }

        public ArrayList Permissions
        {
            get
            {
                return permissionList;
            }
        }

        public DataSet RolesPermissions
        {
            get
            {
                return this.dsRolesPermis;
            }
        }
        #endregion

    }
}
