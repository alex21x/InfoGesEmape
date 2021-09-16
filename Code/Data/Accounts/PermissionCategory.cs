using System;
using System.Data;

namespace InfogesEmape.Code.Data.Accounts
{
	/// <summary>
	/// Summary description for PermissionCategory.
	/// </summary>
	public class PermissionCategory
	{

        /*
		#region Retrieve
		public DataRow Retrieve(int intCategoryId)
		{
			OracleParameter[] parameters = { new OracleParameter("p_category_id", OracleType.Number) };
			parameters[0].Value = intCategoryId;
			using (DataSet categories = ExecuteProcedure("MANAGER_USERS.get_permission_categorydetail", parameters, "Categories"))
			{
				return categories.Tables[0].Rows[0];
			}
		}
		#endregion

		#region GetPermissionsInCategory
//		public DataSet GetPermissionsInCategory(int intCategoryId)
//		{
//			SqlParameter[] parameters =
//			{
//				new SqlParameter("@CategoryId", SqlDbType.Int, 4)
//			};
//			parameters[0].Value = intCategoryId;
//			using (DataSet permissions = ExecuteProcedure("spAccounts_GetPermissionsInCategory",
//					   parameters, "Categories"))
//			{
//				return permissions;
//			}		
//		}
		#endregion

		#region GetCategoryList
		public DataSet GetCategoryList()
		{
			using (DataSet categories = ExecuteProcedure("MANAGER_USERS.get_permission_categories", new IDbDataParameter[]{}, "Categories"))
			{
				return categories;
			}
		}
		#endregion
        */

	}
}
