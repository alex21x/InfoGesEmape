#region Using Directives
using System;
using System.Data;
using System.Collections;
using System.Security;
using System.Security.Cryptography;
using System.Text;
#endregion

namespace InfoGes.Code.Logic.Accounts
{
    public class SitePrincipal : System.Security.Principal.IPrincipal
    {
        #region Declatives Variables
        protected System.Security.Principal.IIdentity identity;
		protected ArrayList permissionList;
		protected ArrayList roleList;
		protected DataSet dsRolesPermis;
        protected string xmlMenuTree;
        #endregion

        #region Constructors
        public SitePrincipal( int userId )
		{
			identity = new SiteIdentity( userId );
            GetMenu(userId);
		}

		public SitePrincipal( string userName )
		{
            identity = new SiteIdentity(userName);
            DataRow dr1 = Code.Data.Accounts.User.Get(userName);
            int userId = int.Parse(dr1["user_id"].ToString());
            GetMenu(userId);
        }
        #endregion

        #region Methods
        private void GetMenu(int userId)
        {
            DataSet ds1 = Code.Data.Accounts.User.GetPermissions(Code.Data.Accounts.User.GetRoleId(userId));
            this.xmlMenuTree = Code.Logic.Accounts.User.CreateXmlMenu(ds1);

        }
        public static SitePrincipal ValidateLogin(string userName, string password)
		{
            int result = Code.Data.Accounts.User.Validate(userName, password);
            if (result > -1)
                return new SitePrincipal(result);
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
