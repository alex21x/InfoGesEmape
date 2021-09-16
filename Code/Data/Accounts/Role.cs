#region Using Directives
using System;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
#endregion

namespace InfogesEmape.Code.Data.Accounts
{
	/// <summary>
	/// Summary description for Role.
	/// </summary>
	public class Role
    {

        #region RemovePermission
        public static int RemovePermission(string roleId, string permissionId)
        {

            int r = 0;
            try
            {
                string cadenaEliminar = "DELETE FROM account_role_permissions WHERE role_id = @roleId AND permission_Id = @permissionId;";
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    SqlCommand comando = new SqlCommand(cadenaEliminar, conexion);
                    comando.Parameters.Add("@roleId", SqlDbType.VarChar);
                    comando.Parameters.Add("@permissionId", SqlDbType.VarChar);
                    comando.Parameters["@roleId"].Value = roleId.ToString();
                    comando.Parameters["@permissionId"].Value = permissionId.ToString();
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return r;
        }
        #endregion

        #region AddPermission
        public static int AddPermission(string roleId, string permissionId)
        {
            DataSet ds1 = new DataSet();
            int r = 0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    string StringSql = "SELECT * FROM account_role_permissions ";
                    StringSql += " WHERE role_id = " + roleId;
                    StringSql += " AND permission_id = " + permissionId;

                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                    int i = ds1.Tables[0].Rows.Count;
                    if (i == 0)
                    {
                        //using (SqlConnection conexion1 = new SqlConnection(Code.ConeccionString.sql()))
                        //{
                            string cadenaInsertar = "INSERT INTO account_role_permissions(role_id, permission_id) VALUES (@roleId, @permissionId );";
                            SqlCommand comando = new SqlCommand(cadenaInsertar, conexion);
                            comando.Parameters.Add("@roleId", SqlDbType.VarChar);
                            comando.Parameters.Add("@permissionId", SqlDbType.VarChar);
                            comando.Parameters["@roleId"].Value = roleId.ToString();
                            comando.Parameters["@permissionId"].Value = permissionId.ToString();

                            conexion.Open();
                            comando.ExecuteNonQuery();
                            conexion.Close();

                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return r;
        }
        #endregion

        #region Delete
        public static int Delete(string roleId)
        {
            int r = 0;
            try
            {
                string cadenaEliminar = "DELETE FROM account_role_permissions WHERE role_id = @roleId; ";
                cadenaEliminar += " DELETE FROM account_user_roles WHERE role_id = @roleId; ";
                cadenaEliminar += " DELETE FROM account_role WHERE role_id = @roleId; ";

                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    SqlCommand comando = new SqlCommand(cadenaEliminar, conexion);
                    comando.Parameters.Add("@roleId", SqlDbType.VarChar);
                    comando.Parameters["@roleId"].Value = roleId.ToString();
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return r;
        }
        #endregion

        #region Insert
        public static int Insert(string descripcion)
        {
            int r = 0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    string cadenaInsertar = "INSERT INTO account_role(description) VALUES (@descripcion)";
                    SqlCommand comando = new SqlCommand(cadenaInsertar, conexion);
                    //comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                    //comando.Parameters["@descripcion"].Value = descripcion.ToString();    
                    comando.Parameters.AddWithValue("@descripcion", descripcion.ToString());//1

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();

                }
            }
            catch (Exception e1) { Trace.Write("Insert, Error : " + e1.Message.ToString()); }
            return r;
        }
        #endregion

        #region GetRoleList
        public static DataSet GetRoleList()
        {

            DataSet ds1 = new DataSet();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Code.ConeccionString2.mysql()))
                {
                    string StringSql = "SELECT role_id, description FROM account_role ORDER BY description ASC";
					MySqlDataAdapter adapter = new MySqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                    int i = ds1.Tables[0].Rows.Count;
                    conexion.Close();
                }
            }
                catch (Exception e1) { Trace.Write("GetUserList, Error : " + e1.Message.ToString()); }
            return ds1;
        }
        #endregion

	}
}
