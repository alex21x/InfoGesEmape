using System;
using System.Diagnostics;
using System.Data;
using System.Text;

namespace InfogesEmape.Code.Logic.Accounts
{
	/// <summary>
	/// Summary description for User.
	/// </summary>
	public sealed class User 
	{	
        //Aubillus
		/*private string strConnectionDB;
		private int intUserId;
		private string strDescription;
		private string strEmailAddress;
		private string strStatus;
		private byte[] vntPassword;
		private string strUserName;*/
				
		public User()
		{ 
		}

        /// <summary>
        /// Create un arbol XML jerarquico para el menu y poder ser leido por el control treeview
        /// </summary>
        /// <param name="ds1"></param>
        /// <returns></returns>
        /// 
        public static string CreateXmlMenu(DataSet ds1)
        {
            int l1 = 0;
            int l2 = 0;
            bool f2 = false;
            bool f1 = false;
            bool f3 = false;
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Append("<?xml version='1.0' encoding='utf-8' ?><mainmenu>");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                l1 = int.Parse(ds1.Tables[0].Rows[i]["level1_id"].ToString());
                o1.Append("<item Text=" + '"' + ds1.Tables[0].Rows[i]["title_long"].ToString() + '"' + " Selected=" + '"' + "True" + '"' + ">");
                f1 = true;
                while (l1 == Code.Logic.Common.GetDecimal(ds1, i, "level1_id"))
                {
                    f3 = true;

                    if (f1)
                    {
                        i++;
                        f1 = false;
                    }
                    l2 = int.Parse(ds1.Tables[0].Rows[i]["level2_id"].ToString());

                    if (ds1.Tables[0].Rows[i]["link"].ToString().Length == 0)
                        o1.Append("<item Text=" + '"' + ds1.Tables[0].Rows[i]["title_long"].ToString() + '"' + " >");
                    else
                    {
                        o1.Append("<item Text=" + '"' + ds1.Tables[0].Rows[i]["title_long"].ToString() + '"' + " NavigateUrl=" + '"' + ds1.Tables[0].Rows[i]["link"].ToString() + '"' + " />");
                        f3 = false;
                    }

                    i++;
                    f2 = true;
                    while (l2 == Code.Logic.Common.GetDecimal(ds1, i, "level2_id"))
                    {
                        if (f2)
                        {
                            //                            i++;
                            f2 = false;
                        }
                        if (i < ds1.Tables[0].Rows.Count)
                        {
                            o1.Append("<item Text=" + '"' + ds1.Tables[0].Rows[i]["title_long"].ToString() + '"' + " NavigateUrl=" + '"' + ds1.Tables[0].Rows[i]["link"].ToString() + '"' + " />");
                            i++;
                        }
                    }
                    if (f3)
                        o1.Append("</item>");
                }
                o1.Append("</item>");
            }
            o1.Append("</mainmenu>");
            Trace.WriteLine("xml:" + o1.ToString());
            Console.WriteLine("xml:" + o1.ToString());
            return o1.ToString();
        }


        public static string CreateXmlMenuDD(DataSet ds1)
        {
            int l1 = 0;
            int l2 = 0;
            bool f2 = false;
            bool f1 = false;
            bool f3 = false;
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Append("<?xml version='1.0' encoding='utf-8' ?><mainmenu>");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                l1 = int.Parse(ds1.Tables[0].Rows[i]["level1_id"].ToString());
                //o1.Append("<item Text=" + '"' + ds1.Tables[0].Rows[i]["title_long"].ToString() + '"' + " Selected=" + '"' + "True" + '"' + ">");
                f1 = true;
                while (l1 == Code.Logic.Common.GetDecimal(ds1, i, "level1_id"))
                {
                    f3 = true;

                    if (f1)
                    {
                        i++;
                        f1 = false;
                    }
                    l2 = int.Parse(ds1.Tables[0].Rows[i]["level2_id"].ToString());

                    //if (ds1.Tables[0].Rows[i]["link"].ToString().Length == 0)
                    //    o1.Append("<item Text=" + '"' + ds1.Tables[0].Rows[i]["title_long"].ToString() + '"' + " >");
                    //else
                    //{
                    //    o1.Append("<item Text=" + '"' + ds1.Tables[0].Rows[i]["title_long"].ToString() + '"' + " NavigateUrl=" + '"' + ds1.Tables[0].Rows[i]["link"].ToString() + '"' + " />");
                    //    f3 = false;
                    //}

                    i++;
                    f2 = true;
                    while (l2 == Code.Logic.Common.GetDecimal(ds1, i, "level2_id"))
                    {
                        if (f2)
                        {
                            //                            i++;
                            f2 = false;
                        }
                        if (i < ds1.Tables[0].Rows.Count)
                        {
                           // o1.Append("<item Text=" + '"' + ds1.Tables[0].Rows[i]["title_long"].ToString() + '"' + " Selected=" + '"' + "True" + '"' + " NavigateUrl=" + '"' + ds1.Tables[0].Rows[i]["link"].ToString() + '"' + " />");
                            o1.Append("<item Text=" + '"' + ds1.Tables[0].Rows[i]["title_long"].ToString() + '"' + " Selected=" + '"' + "True" + '"' + " NavigateUrl=" + '"' + ds1.Tables[0].Rows[i]["link"].ToString() + '"' + " />");
                            //o1.Append("<item Text=" + '"' + ds1.Tables[0].Rows[i]["title_long"].ToString() + '"' + " NavigateUrl=" + '"' + ds1.Tables[0].Rows[i]["link"].ToString() + '"' + " />");
                            i++;
                        }
                    }
                    //if (f3)
                    //    o1.Append("</item>");
                }
                //o1.Append("</item>");
            }
            o1.Append("</mainmenu>");
            Trace.WriteLine("xml:" + o1.ToString());
            Console.WriteLine("xml:" + o1.ToString());
            return o1.ToString();
        }

        public static string CreateXmlMenu_Roles(DataSet ds1)
        {
            int l1 = 0;
            int l2 = 0;
            bool f2 = false;
            bool f1 = false;
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Append("<?xml version='1.0' encoding='utf-8' ?><menutree>");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                l1 = int.Parse(ds1.Tables[0].Rows[i]["level1_id"].ToString());
                o1.Append("<level1 Name='" + ds1.Tables[0].Rows[i]["permission_id"].ToString() + "' Title='" + ds1.Tables[0].Rows[i]["title_short"].ToString() + "' Link=''>");
                f1 = true;
                while (l1 == Code.Logic.Common.GetDecimal(ds1, i, "level1_id"))
                {
                    if (f1)
                    {
                        i++;
                        f1 = false;
                    }
                    l2 = int.Parse(ds1.Tables[0].Rows[i]["level2_id"].ToString());
                    o1.Append("<level2 Name='" + ds1.Tables[0].Rows[i]["permission_id"].ToString() + "' Title='" + ds1.Tables[0].Rows[i]["title_short"].ToString() + "' Link=''>");
                    f2 = true;
                    while (l2 == Code.Logic.Common.GetDecimal(ds1, i, "level2_id"))
                    {
                        if (f2)
                        {
                            i++;
                            f2 = false;
                        }
                        if (i < ds1.Tables[0].Rows.Count)
                        {
                            o1.Append("<level3 Name='" + ds1.Tables[0].Rows[i]["permission_id"].ToString() + "' Title='" + ds1.Tables[0].Rows[i]["title_short"].ToString() + "' Link='" + ds1.Tables[0].Rows[i]["link"].ToString() + "' />");
                            i++;
                        }
                    }
                    o1.Append("</level2>");
                }
                o1.Append("</level1>");
            }
            o1.Append("</menutree>");
            Trace.WriteLine("xml:" + o1.ToString());
            Console.WriteLine("xml:" + o1.ToString());
            return o1.ToString();
        }

        public static string CreateXmlMenuMovil(DataSet ds1)
        {
            int l1 = 0;
            int l2 = 0;
            bool f2 = false;
            bool f1 = false;
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Append("<?xml version='1.0' encoding='utf-8' ?><menutree>");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                l1 = int.Parse(ds1.Tables[0].Rows[i]["level1_id"].ToString());
                o1.Append("<level1 Name='" + ds1.Tables[0].Rows[i]["permission_id"].ToString() + "' Title='" + ds1.Tables[0].Rows[i]["title_short"].ToString() + "' Link=''>");
                f1 = true;
                while (l1 == Code.Logic.Common.GetDecimal(ds1, i, "level1_id"))
                {
                    if (f1)
                    {
                        i++;
                        f1 = false;
                    }
                    l2 = int.Parse(ds1.Tables[0].Rows[i]["level2_id"].ToString());
                    o1.Append("<level2 Name='" + ds1.Tables[0].Rows[i]["permission_id"].ToString() + "' Title='" + ds1.Tables[0].Rows[i]["title_short"].ToString() + "' Link=''>");
                    f2 = true;
                    while (l2 == Code.Logic.Common.GetDecimal(ds1, i, "level2_id"))
                    {
                        if (f2)
                        {
                            i++;
                            f2 = false;
                        }
                        if (i < ds1.Tables[0].Rows.Count)
                        {
                            o1.Append("<level3 Name='" + ds1.Tables[0].Rows[i]["permission_id"].ToString() + "' Title='" + ds1.Tables[0].Rows[i]["title_short"].ToString() + "' Link='" + ds1.Tables[0].Rows[i]["link"].ToString() + "' />");
                            i++;
                        }
                    }
                    o1.Append("</level2>");
                }
                o1.Append("</level1>");
            }
            o1.Append("</menutree>");
            Trace.WriteLine("xml:" + o1.ToString());
            Console.WriteLine("xml:" + o1.ToString());
            return o1.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public static DataSet GetAllPermissions()
        //{
        //    return Code.Data.Accounts.User.GetAllPermissions();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int Delete(string userId)
        {
            return Code.Data.Accounts.User.Delete(userId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static DataSet GetUserRoles(string userId)
        {
            return Code.Data.Accounts.User.GetUserRoles(userId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static DataRow Get(string userId)
        {
            return Code.Data.Accounts.User.Get(int.Parse(userId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static int AddRole(string userId, string roleId)
        {
            return Code.Data.Accounts.User.AddRole(userId, roleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int RemoveRole(string userId, string IdRole)
        {
            return Code.Data.Accounts.User.RemoveRole(userId, IdRole);
        }



        public static int RemoveEjecutora(string userId, string IdSecEjec)
        {
            return Code.Data.Accounts.User.RemoveEjecutora(userId, IdSecEjec);
        }

        public static int AddEjecutora(string userId, string IdSecEjec)
        {
            return Code.Data.Accounts.User.AddEjecutora(userId, IdSecEjec);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        //public static int Update(string[] parameterValues)
        //{
        //    return Code.Data.Accounts.User.Update(parameterValues);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static int Insert(string[] parameterValues)
        {
            return Code.Data.Accounts.User.Insert(parameterValues);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetUserList()
        {
            return Code.Data.Accounts.User.GetUserList();
        }

/*		
		public User( int existingUserID )
		{			
			strConnectionDB = BuildSolutionsIT.Utilities.SaltedHash.SecureConnection.GetCnxString("Reserved02");
			this.intUserId = existingUserID;
			LoadFromID();						
		}

		private void LoadFromID()
		{
			AccessData.Accounts.User dataUser = new AccessData.Accounts.User( strConnectionDB );
			DataRow userRow = dataUser.Get( this.intUserId);

			this.strDescription = (string)userRow["description"];
			this.strEmailAddress = (string)userRow["email_address"];
			this.strStatus = (string)userRow["status"];
			this.vntPassword = (byte[])userRow["password"];
			this.strUserName = (string)userRow["user_name"];
		}

		public void GetByUserName(string userName) 
		{
			AccessData.Accounts.User o1 = new AccessData.Accounts.User( strConnectionDB );
			try { 
				DataRow dr1 = o1.Get(userName);
				this.strDescription = (string)dr1["description"];
				this.strEmailAddress = (string)dr1["email_address"];
				this.strStatus = (string)dr1["status"];
				this.vntPassword = (byte[])dr1["password"];
				this.strUserName = (string)dr1["user_name"];
			}
			catch {}
			o1 = null;
		}

		public int Create()
		{		
			AccessData.Accounts.User dataUser = new AccessData.Accounts.User( strConnectionDB );
			this.intUserId  = dataUser.Create(this.strDescription,this.strEmailAddress,this.vntPassword,this.strStatus,this.strUserName);
			return this.intUserId;
		}

		public bool Update(int intTypeUpdate)
		{
			AccessData.Accounts.User dataUser = new AccessData.Accounts.User( strConnectionDB );
			return dataUser.Update(this.intUserId,this.strDescription,this.strEmailAddress,this.vntPassword,this.strStatus,intTypeUpdate);
		}

		public bool Delete()
		{
			AccessData.Accounts.User dataUser = new AccessData.Accounts.User( strConnectionDB );
			return dataUser.Delete(this.intUserId); 
		}
        */
        /*
		public DataSet GetUserRoles() 
		{
			AccessData.Accounts.User dataUser = new AccessData.Accounts.User( strConnectionDB );
			return dataUser.GetUserRoles(this.intUserId); 
		}

		public bool AddToRole(int intRoleId)
		{
			AccessData.Accounts.User dataUser = new AccessData.Accounts.User( strConnectionDB );
			return dataUser.AddRole(this.intUserId, intRoleId);
		}

		public bool RemoveRole()
		{
			AccessData.Accounts.User dataUser = new AccessData.Accounts.User( strConnectionDB );
			return dataUser.RemoveRole( this.intUserId);
		}

		//Attributes
		public int UserId 
		{
			get {
				return this.intUserId;
			}
			set {
				this.intUserId = value;
			}
		}
 
		public string Description 
		{
			get {
				return this.strDescription;
			}
			set {
				this.strDescription = value;
			}
		}
 
		public string EmailAddress 
		{
			get {
				return this.strEmailAddress;
			}
			set {
				this.strEmailAddress = value;
			}
		}
 
		public string Status 
		{
			get {
				return this.strStatus;
			}
			set {
				this.strStatus = value;
			}
		}
 
		public byte[] Password 
		{
			get {
				return this.vntPassword;
			}
			set {
				this.vntPassword = value;
			}
		}

		public string UserName 
		{
			get 
			{
				return this.strUserName;
			}
			set 
			{
				this.strUserName = value;
			}
		}
*/ 
	}
}
