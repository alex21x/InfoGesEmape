#region Using Directives
using System;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EntLibContrib.Data.MySql;
using MySql.Data.MySqlClient;
#endregion

namespace InfoGesRegional.Code.Data.Accounts
{	
	/// <summary>
	/// Summary description for User.
	/// </summary>	
	public class User 
	{

        #region Update
        public static int Update(string[] parameterValues)
        {
            int r = -1;
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "UPDATE account_user SET ";
            sqlCommand += "description = '" + parameterValues[1].ToString() + "',";
            sqlCommand += "email_address = '" + parameterValues[2].ToString() + "',";
            if (parameterValues[3].ToString().Length>0)
                sqlCommand += "password = AES_ENCRYPT('" + parameterValues[3].ToString() + "','" + Code.Logic.Common.KEY_GUID_PWD + "'),";
            sqlCommand += "status = '" + parameterValues[4].ToString() + "' ";
            sqlCommand += "WHERE = user_id = " + parameterValues[0].ToString();

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                r = db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e1) { Trace.Write("Update, Error : " + e1.Message.ToString()); }
            return r;
        }
        #endregion

        #region Delete
        public static int Delete(string userId)
        {
            int r = -1;
            Database db = DatabaseFactory.CreateDatabase();
            try
            {
                db.ExecuteNonQuery(CommandType.Text, "DELETE account_user_roles WHERE user_id = " + userId);
                db.ExecuteNonQuery(CommandType.Text, "DELETE account_user WHERE user_id = " + userId);
                r = 0;
            }
            catch (Exception e1) { Trace.Write("Delete, Error : " + e1.Message.ToString()); }
            return r;
        }
        #endregion

        #region Insert
        public static int Insert(string[] parameterValues)
        {
            int r = -1;
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "INSERT INTO account_user(description,email_address,password,status,user_name) VALUES( ";
            sqlCommand += "'" + parameterValues[0].ToString() + "',";
            sqlCommand += "'" + parameterValues[1].ToString() + "',";
            sqlCommand += "AES_ENCRYPT('" + parameterValues[2].ToString() + "','" + Code.Logic.Common.KEY_GUID_PWD + "'),";
            sqlCommand += "'" + parameterValues[4].ToString() + "',";
            sqlCommand += "'" + parameterValues[3].ToString() + "'); ";
            sqlCommand += "select LAST_INSERT_ID() as last_id_generate from dual;  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            DataSet ds1 = null;
            try
            {
                ds1 = db.ExecuteDataSet(dbCommand);
                r = int.Parse(ds1.Tables[0].Rows[0]["last_id_generate"].ToString());
            }
            catch (Exception e1) { Trace.Write("Insert, Error : " + e1.Message.ToString()); }
            return r;
        }
        #endregion

        #region GetRoleId
        /// <summary>
        /// Obtiene el id del rol segun el codigo del usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetRoleId(int userId)
        {
            int roleId = -1;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT ur.role_id, r.description ";
            sqlCommand += "        FROM account_user_roles ur, account_role r ";
            sqlCommand += "       WHERE ur.role_id = r.role_id ";
            sqlCommand += "         AND ur.user_id = " + userId.ToString();
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                DataSet ds1 = null;
                ds1 = db.ExecuteDataSet(dbCommand);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    roleId = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                }
                ds1.Dispose();
                ds1 = null;
            }
            catch (Exception e1) { Trace.Write("GetRoleId, Error : " + e1.Message.ToString()); }
            return roleId;
        }
        #endregion

        #region GetUserRoles
        /// <summary>
        /// Obtiene los roles del usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static DataSet GetUserRoles(string userId)
        {
            DataSet ds1 = null;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT ur.role_id, r.description ";
            sqlCommand += "        FROM account_user_roles ur, account_role r ";
            sqlCommand += "       WHERE ur.role_id = r.role_id ";
            sqlCommand += "         AND ur.user_id = " + userId;
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                ds1 = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e1) { Trace.Write("GetUserRoles, Error : " + e1.Message.ToString()); }
            return ds1;
        }
        #endregion

        #region GetAllPermissions
        /// <summary>
        /// Obtiene todos los permisos existentes en el sistema
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static DataSet GetAllPermissions()
        {
            DataSet ds1 = null;

            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT ap.permission_id, ap.level1_id, ap.level2_id, ap.level3_id, ap.title_short, ap.title_long, ap.Link  ";
            sqlCommand += "       FROM account_permission ap ";
            sqlCommand += "      WHERE ap.status = 'A'  AND  ap.ind_password IS NULL ";
            sqlCommand += " ORDER BY ap.level1_id, ap.level2_id,ap.level3_id ";
            //sqlCommand += "   ORDER BY ap.permission_id ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                ds1 = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e1) { Trace.Write("GetAllPermissions, Error : " + e1.Message.ToString()); }
            return ds1;
        }
        #endregion

        #region GetPermissions
        /// <summary>
        /// Obtiene los permisos segun el codigo de rol
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static DataSet GetPermissions(int roleId)
        {
            DataSet ds1 = null;

            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "SELECT ap.permission_id, ap.level1_id, ap.level2_id, ap.level3_id, ap.title_short, ap.title_long, ap.Link ";
            sqlCommand += "       FROM account_permission ap, account_role_permissions apr ";
            sqlCommand += "      WHERE ap.permission_id = apr.permission_id ";
            sqlCommand += "        AND apr.role_id = " + roleId.ToString();
            sqlCommand += "        AND ap.status = 'A'  AND  ap.ind_password IS NULL ";
//            sqlCommand += "   ORDER BY ap.permission_id";
            sqlCommand += "   ORDER BY ap.level1_id, ap.level2_id, ap.level3_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                ds1 = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e1) { Trace.Write("GetPermissions, Error : " + e1.Message.ToString()); }
            return ds1;
        }
        #endregion

        #region GetById
		public static DataRow Get(int userId)
		{
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "SELECT * FROM account_user WHERE user_id= " + userId.ToString();
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            DataSet ds1 = null;
            //try
            //{
                ds1 = db.ExecuteDataSet(dbCommand);
                if (ds1.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No user found on user for id:" + userId.ToString());
                }
                else
                    return ds1.Tables[0].Rows[0];
            //}
            //catch (Exception e1) { Trace.Write("Get, Error : " + e1.Message.ToString()); }
		}
		#endregion

		#region Get by UserName
        public static DataRow Get(string userName)
		{
            Database db = DatabaseFactory.CreateDatabase();

            userName = userName.Replace("\\", "-");
            string sqlCommand = "SELECT * FROM account_user WHERE user_name= '" + userName + "'";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            DataSet ds1 = null;
            //try
            //{
                ds1 = db.ExecuteDataSet(dbCommand);
                if (ds1.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No user found on user for name:" + userName);
                }
                else
                    return ds1.Tables[0].Rows[0];
            //}
            //catch (Exception e1) { Trace.Write("Get, Error : " + e1.Message.ToString()); }
        }
		#endregion

        #region Validate
        public static int Validate(string userName, string password)
         {
             int r = -1;
             Database db = DatabaseFactory.CreateDatabase();

             //string sqlCommand = "SELECT user_id FROM account_user WHERE user_name='" + userName + "' ";
             string sqlCommand = "SELECT user_id FROM account_user WHERE user_name='" + userName + "' ";
             sqlCommand += " AND password=AES_ENCRYPT('" + password + "','" + Code.Logic.Common.KEY_GUID_PWD + "'); ";
             DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
             DataSet ds1 = null;
             try
             {
                 ds1 = db.ExecuteDataSet(dbCommand);
                 if (ds1.Tables[0].Rows.Count > 0) r = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
             }
             catch (Exception e1) { Trace.Write("Validate, Error : " + e1.Message.ToString()); }
             return r;
        }
        #endregion

        #region Validate1
        public static int Validate1(string userName, string password)
        {
            int r = -1;
            Database db = DatabaseFactory.CreateDatabase();

            //string sqlCommand = "SELECT user_id FROM account_user WHERE user_name='" + userName + "' ";
            string sqlCommand = "SELECT ID_PERSONAL FROM account_user WHERE user_name='" + userName + "' ";
            sqlCommand += " AND password=AES_ENCRYPT('" + password + "','" + Code.Logic.Common.KEY_GUID_PWD + "'); ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            DataSet ds1 = null;
            try
            {
                ds1 = db.ExecuteDataSet(dbCommand);
                if (ds1.Tables[0].Rows.Count > 0) r = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception e1) { Trace.Write("Validate, Error : " + e1.Message.ToString()); }
            return r;
        }
        #endregion

/*
		#region Update
		public bool Update(int userId,string description,string emailAddress,byte[] password,string status, int typeUpdate)
		{
			int result =0;
            OracleParameter[] parameters = {
                new OracleParameter("p_description", OracleType.VarChar, 30),
                new OracleParameter("p_email_address", OracleType.VarChar, 255),
                new OracleParameter("p_password", OracleType.Raw, 20),
                new OracleParameter("p_status", OracleType.VarChar, 10),
                new OracleParameter("p_user_id", OracleType.Number),
                new OracleParameter("p_type_update", OracleType.Number)
            };
            parameters[0].Value = description;
            parameters[1].Value = emailAddress;
            parameters[2].Value = password;
            parameters[3].Value = status;
            parameters[4].Value = userId;
            parameters[5].Value = typeUpdate;
            result = ExecuteProcedure("MANAGER_USERS.upd_account_user", parameters);
            return (result == 0);
		}
		#endregion

		#region Delete
		public bool Delete(int userId)
		{
            OracleParameter[] parameters = { new OracleParameter("p_user_id", OracleType.Number) };
            parameters[0].Value = userId;
            return (ExecuteProcedure("MANAGER_USERS.del_account_user", parameters) == 0);
            return true;
		}
		#endregion


		#region TestPassword
		public int TestPassword(int userId, byte[] password)
		{
			OracleParameter[] parameters = {   new OracleParameter("p_user_id", OracleType.Number),
											   new OracleParameter("p_password", OracleType.Raw,20)};
			parameters[0].Value = userId;
			parameters[1].Value = password;
			return ExecuteProcedure("MANAGER_USERS.ope_user_test_password", parameters);
		}
		#endregion

		#region GetUserRoles_To_List
		public ArrayList GetUserRoles_To_List( int userId )
		{
			ArrayList roles = new ArrayList();
			OracleParameter[] parameters = { new OracleParameter("p_user_id", OracleType.Number) };
			parameters[0].Value = userId;

			OracleDataReader tmpReader = ExecuteProcedureReader("MANAGER_USERS.get_user_roles", parameters);
			while (tmpReader.Read()) {
				roles.Add( tmpReader.GetInt32(0).ToString() ); //return value code "RoleId"
			}			
			m_OracleConnecion.Close();
			return roles;
		}
		#endregion

		#region GetUserRoles
		public DataSet GetUserRoles( int userId )
		{
			OracleParameter[] parameters = { new OracleParameter("p_user_id", OracleType.Number) };
			parameters[0].Value = userId;
			DataSet users = ExecuteProcedure( "MANAGER_USERS.get_user_roles", parameters, "Users" );
			return users;
		}
		#endregion

		#region GetEffectivePermissionList
		public ArrayList GetEffectivePermissionList( int userId )
		{
			ArrayList permissions = new ArrayList();
			OracleParameter[] parameters = { new OracleParameter("p_user_id", OracleType.Number)};

			parameters[0].Value = userId;

			OracleDataReader tmpReader = ExecuteProcedureReader("MANAGER_USERS.get_effective_list", parameters);
			while (tmpReader.Read()) {
				permissions.Add( tmpReader.GetInt32(0) );
			}			
			this.m_OracleConnecion.Close();
			return permissions;
		}
		#endregion
*/
		#region GetUserList
        public static DataSet GetUserList()
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "Select * from account_user";
            DbCommand dbcommand = db.GetSqlStringCommand(sqlCommand);
            DataSet ds1 = null;
            try
            {
                ds1 = db.ExecuteDataSet(dbcommand);
            }
            catch (Exception e1) { Trace.Write("GetUserList, Error : " + e1.Message.ToString()); }
            return ds1;
        }
		#endregion

        #region AddRole
        public static int AddRole(string userId, string roleId)
        {
            int r = -1;
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "INSERT INTO account_user_roles(role_id, user_id) VALUES (" + roleId + "," + userId  + ")";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                r = db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e1) { Trace.Write("AddRole, Error : " + e1.Message.ToString()); }
            return r;
        }
        #endregion

        #region RemoveRole
        public static int RemoveRole(string userId, string IdRole)
        {
            int r = -1;
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "DELETE FROM account_user_roles WHERE user_id = " + userId+" and role_id="+IdRole;
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                r = db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e1) { Trace.Write("RemoveRole, Error : " + e1.Message.ToString()); }
            return r;
        }
        #endregion

	}
}
