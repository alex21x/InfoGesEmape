using System;
using System.Data;


namespace InfogesEmape.Code.Logic.Accounts
{
	/// <summary>
	/// Summary description for Role.
	/// </summary>
	public class Role
	{
		protected string strConnectionDB;
		//private int intRoleId;
		//private string strDescription;
		//private DataSet dsPermissions;

		public Role()
		{
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="level1Id"></param>
        /// <param name="level2Id"></param>
        /// <param name="level3Id"></param>
        /// <returns></returns>
        public static int RemovePermission(string roleId, string level1Id, string level2Id, string level3Id, int total2, int total3)
        {
            int r = -1;
            r = Code.Data.Accounts.Role.RemovePermission(roleId, level3Id);
            if (total3 == 1)
            {
                r = Code.Data.Accounts.Role.RemovePermission(roleId, level2Id);
                if (total2 == 1)
                    r = Code.Data.Accounts.Role.RemovePermission(roleId, level1Id);
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="level1Id"></param>
        /// <param name="level2Id"></param>
        /// <param name="level3Id"></param>
        /// <returns></returns>
        public static int AddPermission(string roleId, string level1Id, string level2Id, string level3Id)
        {
            int r = -1;
            r = Code.Data.Accounts.Role.AddPermission(roleId, level1Id);
            r = Code.Data.Accounts.Role.AddPermission(roleId, level2Id);
            r = Code.Data.Accounts.Role.AddPermission(roleId, level3Id);
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static int Delete(string roleId)
        {
            return Code.Data.Accounts.Role.Delete(roleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public static int Insert(string descripcion)
        {
            return Code.Data.Accounts.Role.Insert(descripcion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetRoleList()
        {
            return Code.Data.Accounts.Role.GetRoleList();
        }
        
        /*
		public Role(int intCurrentRoleId)
		{
			strConnectionDB = BuildSolutionsIT.Utilities.SaltedHash.SecureConnection.GetCnxString("Reserved02");

			AccessData.Accounts.Role dataRole = new AccessData.Accounts.Role(strConnectionDB );
			DataRow roleRow;
		
			roleRow = dataRole.Get( intCurrentRoleId );
			this.intRoleId = intCurrentRoleId;
			this.strDescription = (string)roleRow["Description"];

			AccessData.Accounts.Permission dataPermission = new AccessData.Accounts.Permission( strConnectionDB );
			this.dsPermissions = dataPermission.GetPermissionList( intCurrentRoleId );
		}

		public int Create()
		{
			AccessData.Accounts.Role dataRole = new AccessData.Accounts.Role( strConnectionDB );
			this.intRoleId = dataRole.Create(this.strDescription);
			return intRoleId;
		}

		public bool Update()
		{
			AccessData.Accounts.Role dataRole = new AccessData.Accounts.Role( strConnectionDB );
			return dataRole.Update(this.intRoleId, this.strDescription);
		}

		public bool Delete()
		{
			AccessData.Accounts.Role dataRole = new AccessData.Accounts.Role( strConnectionDB );
			return dataRole.Delete( this.intRoleId );
		}

		public DataSet GetRoleList()
		{
			AccessData.Accounts.Role dataRole = new AccessData.Accounts.Role( strConnectionDB );
			return dataRole.GetRoleList(); 
		}

		public void AddPermission(int intPermissionId)
		{
			AccessData.Accounts.Role dataRole = new AccessData.Accounts.Role( strConnectionDB );
			dataRole.AddPermission( this.intRoleId, intPermissionId );
		}

		public void RemovePermission(int intPermissionId)
		{
			AccessData.Accounts.Role dataRole = new AccessData.Accounts.Role( strConnectionDB );
			dataRole.RemovePermission( intRoleId, intPermissionId );
		}

		public void ClearPermissions()
		{
			AccessData.Accounts.Role dataRole = new AccessData.Accounts.Role( strConnectionDB );
			dataRole.ClearPermissions( this.intRoleId );
		}
		
		//Attributes
		public int RoleId
		{
			set {
				this.intRoleId = value;
			}
			get 
			{
				return intRoleId;
			}
		}

		public string Description
		{
			get 
			{
				return this.strDescription;
			}
			set 
			{
				this.strDescription = value;
			}
		}

		public DataSet Permissions
		{
			get 
			{
				return this.dsPermissions;
			}
		}
        */
	}
}
