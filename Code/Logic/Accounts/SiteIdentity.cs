#region Using Directives
using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Web.Security;
using System.Security.Cryptography;

#endregion

namespace InfogesEmape.Code.Logic.Accounts
{
	public class SiteIdentity : System.Security.Principal.IIdentity
    {

        #region Declatives Variables
        private string strDescription;
		private string strUserName;
        private byte[] vntPassword;
        //private string  vntPassword;
        private int intUserId;
        #endregion

        #region Constructors
        public SiteIdentity( string userName )
		{
            DataRow dr1 = Code.Data.Accounts.User.Get(userName);

            this.strUserName = userName;
            this.strDescription = dr1["description"].ToString();
            this.vntPassword = (byte[])dr1["password"]; 
            //paswrod modificacion ubillus
            //this.vntPassword = dr1["password"].ToString();
            this.intUserId = int.Parse(dr1["user_id"].ToString());
		}
		
		public SiteIdentity( int userId )
		{
            DataRow dr1 = Code.Data.Accounts.User.Get(userId);

            this.strUserName = (string)dr1["user_name"];
            this.strDescription = dr1["description"].ToString();
            //this.vntPassword = dr1["password"].ToString();
            this.vntPassword = (byte[])dr1["password"];
            this.intUserId = userId;
        }
        #endregion

        #region Attributes
        public string UserName
		{
			get 
			{
				return this.strUserName; 
			}
		}

		public int UserId
		{
			get 
			{
				return this.intUserId;
			}
		}

        public byte[] Password
       //public string Password
        {
			get 
			{
				return this.vntPassword;
			}
        }
        public string AuthenticationType
        {
            get
            {
                return "Custom Authentication BioLatina";
            }
            set
            {
                // do nothing
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                // assumption: all instances of a SiteIdentity have already
                // been authenticated.
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this.strDescription;
            }
        }
        #endregion

    }
}
