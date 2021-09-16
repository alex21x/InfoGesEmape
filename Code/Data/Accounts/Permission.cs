using System;
using System.Data;

namespace InfogesEmape.Code.Data.Accounts
{
	/// <summary>
	/// Summary description for Permission.
	/// </summary>
	public class Permission 
	{
        /*

		#region GetPermissionList
		/// <summary>
		/// Levanta en memoria las tablas de Permisos y Categorias relacionadas.
		/// </summary>
		/// <returns></returns>
		// para poder listar los permisos segun su categoria.
		public DataSet GetPermissionList()
		{
			using (DataSet permissions = ExecuteProcedure( "MANAGER_USERS.get_permission_categories", new IDbDataParameter[]{}, "Categories"))
			{
				CreateInstance();
				OracleParameter[] parameters = { new OracleParameter("p_role_id", OracleType.Number) };
				parameters[0].Value = OracleNumber.Null;
				ExecuteProcedure("MANAGER_USERS.get_permission_list", parameters, "Permissions",permissions);
				DataRelation permissionCategories = new DataRelation("PermissionCategories",
					permissions.Tables["Categories"].Columns["category_id"],
					permissions.Tables["Permissions"].Columns["category_id"], true);
				//TODO: 13/08/2004 21:02:00 Flag active for treeview control
				permissionCategories.Nested = true; 
				permissions.Relations.Add( permissionCategories );
				DataColumn[] categoryKeys = new DataColumn[1];
				categoryKeys[0] = permissions.Tables["Categories"].Columns["category_id"];
				DataColumn[] permissionKeys = new DataColumn[1];
				permissionKeys[0] = permissions.Tables["Permissions"].Columns["permission_id"];
				permissions.Tables["Categories"].PrimaryKey = categoryKeys;
				permissions.Tables["Permissions"].PrimaryKey = permissionKeys;
				return permissions;
			}		
		}
		#endregion

		#region GetPermissionList overload
		public DataSet GetPermissionList(int roleId)
		{
			using (DataSet permissions = ExecuteProcedure("MANAGER_USERS.get_permission_categories", new IDbDataParameter[]{}, "Categories"))
			{
				CreateInstance(); 
				OracleParameter[] parameters = { new OracleParameter("p_role_id", OracleType.Number) };
				parameters[0].Value = roleId;
				ExecuteProcedure("MANAGER_USERS.get_permission_list", parameters, "Permissions",permissions);
				DataRelation permissionCategories = new DataRelation("PermissionCategories",
					permissions.Tables["Categories"].Columns["category_id"],
					permissions.Tables["Permissions"].Columns["category_id"], true);
				permissionCategories.Nested = true; 
				permissions.Relations.Add( permissionCategories );
				DataColumn[] categoryKeys = new DataColumn[1];
				categoryKeys[0] = permissions.Tables["Categories"].Columns["category_id"];
				DataColumn[] permissionKeys = new DataColumn[1];
				permissionKeys[0] = permissions.Tables["Permissions"].Columns["permission_id"];
				permissions.Tables["Categories"].PrimaryKey = categoryKeys;
				permissions.Tables["Permissions"].PrimaryKey = permissionKeys;
				return permissions;
			}
		}
		#endregion

        */
	}
}
