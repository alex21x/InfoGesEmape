#region Using Directives
using System;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using Microsoft.Practices.EnterpriseLibrary.Data;
using EntLibContrib.Data.MySql;
#endregion

namespace InfogesEmape.Code.Data.Accounts
{	
	/// <summary>
	/// Summary description for User.
	/// </summary>	
	public class User 
	{




        #region Delete
        public static int Delete(string userId)
        {
            int r = 0;
            try
            {

                r = -1;
                Database db = DatabaseFactory.CreateDatabase();

                db.ExecuteNonQuery(CommandType.Text, "DELETE account_user_roles WHERE user_id = " + userId);
                db.ExecuteNonQuery(CommandType.Text, "DELETE account_user WHERE user_id = " + userId);
                r = 0;
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return r; 
        }
        #endregion

        #region Insert
        public static int Insert(string[] parameterValues)
        {
            int r = 0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    string cadenaInsertar = "INSERT INTO account_user(description,email_address,password,status,user_name) VALUES(@description,@email_address,@password,@status,@user_name) ";
                    SqlCommand comando = new SqlCommand(cadenaInsertar, conexion);
                    //comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                    //comando.Parameters["@descripcion"].Value = descripcion.ToString();    
                    comando.Parameters.AddWithValue("@description", parameterValues[0].ToString());//1
                    comando.Parameters.AddWithValue("@email_address", parameterValues[1].ToString());//1
                    comando.Parameters.AddWithValue("@password", parameterValues[2].ToString());//1
                    //sqlCommand += "AES_ENCRYPT('" + parameterValues[2].ToString() + "','" + Code.Logic.Common.KEY_GUID_PWD + "'),"; 
                    comando.Parameters.AddWithValue("@status", parameterValues[4].ToString());//1
                    comando.Parameters.AddWithValue("@user_name", parameterValues[3].ToString());//1

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    //ENCRIPTAR

                }
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
            DataSet ds1 = new DataSet();
            try
            {
                string StringSql = "SELECT ur.role_id, r.description FROM account_user_roles ur, account_role r WHERE ur.role_id = r.role_id AND ur.user_id = " + userId.ToString();
                MySqlConnection Conexion = new MySqlConnection();
                MySqlCommand Query = new MySqlCommand();
                MySqlDataAdapter MySqlDa;
                Conexion.ConnectionString = Code.ConeccionString2.mysql();
                Conexion.Open();
                Query.CommandText = StringSql;
                Query.Connection = Conexion;
                MySqlDa = new MySqlDataAdapter(Query);
                MySqlDa.Fill(ds1);
                Conexion.Close();
                roleId = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
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


            DataSet ds1 = new DataSet();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {

                    string StringSql = "SELECT ur.role_id, r.description FROM account_user_roles ur, account_role r WHERE ur.role_id = r.role_id AND ur.user_id ='"+userId+"' ";
                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                    int i = ds1.Tables[0].Rows.Count;
                    conexion.Close();
                }
            }
            catch (Exception e1) { Trace.Write("GetUserList, Error : " + e1.Message.ToString()); }
            return ds1;

        }


        #endregion

        #region GetAllPermissions

        public static DataSet GetAllPermissions()
        {

            DataSet ds1 = new DataSet();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    string StringSql = "SELECT ap.permission_id, ap.level1_id, ap.level2_id, ap.level3_id, ap.title_short, ap.title_long, ap.Link  ";
                    StringSql += " FROM account_permission ap ";
                    StringSql += " WHERE ap.status = 'A'  ";
                    StringSql += " ORDER BY ap.level1_id, ap.level2_id,ap.level3_id ";
                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                    int i = ds1.Tables[0].Rows.Count;
                    conexion.Close();
                }
            }
            catch (Exception e1) { Trace.Write("GetUserList, Error : " + e1.Message.ToString()); }
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
            DataSet ds1 = new DataSet();


            try
            {

                string StringSql = "SELECT ap.permission_id, ap.level1_id, ap.level2_id, ap.level3_id, ap.title_short, ap.title_long, ap.Link ";
                StringSql += " FROM account_permission ap, account_role_permissions apr ";
                StringSql += " WHERE ap.permission_id = apr.permission_id ";
                StringSql += " AND apr.role_id = " + roleId.ToString();
                StringSql += " AND ap.status = 'A' ";
                StringSql += " ORDER BY ap.level1_id, ap.level2_id, ap.level3_id";
                MySqlConnection Conexion = new MySqlConnection();
                MySqlCommand Query = new MySqlCommand();
                MySqlDataAdapter MySqlDa;
                Conexion.ConnectionString = Code.ConeccionString2.mysql();
                Conexion.Open();
                Query.CommandText = StringSql;
                Query.Connection = Conexion;
                MySqlDa = new MySqlDataAdapter(Query);
                MySqlDa.Fill(ds1);
                Conexion.Close();                
            }
            catch (Exception e1) { Trace.Write("GetPermissions, Error : " + e1.Message.ToString()); }
            return ds1;
        }
        #endregion

        #region GetById
        public static DataRow Get(int userId)
        {
            DataSet ds1 = new DataSet();
            string StringSql = "SELECT * FROM  account_user WHERE user_id= " + userId.ToString();

            MySqlConnection Conexion = new MySqlConnection();
            MySqlCommand Query = new MySqlCommand();
            MySqlDataAdapter MySqlDa;
            Conexion.ConnectionString = Code.ConeccionString2.mysql();
            Conexion.Open();
            Query.CommandText = StringSql;
            Query.Connection = Conexion;
            MySqlDa = new MySqlDataAdapter(Query);
            MySqlDa.Fill(ds1);
            Conexion.Close();
            if (ds1.Tables[0].Rows.Count == 0)
            {
                throw new Exception("No user found on user for id:" + userId.ToString());
            }
            else
                return ds1.Tables[0].Rows[0];

        }
        #endregion

		#region Get by UserName
        public static DataRow Get(string userName)
		{

            userName = userName.Replace("\\", "-");
            DataSet ds1 = new DataSet();

            try
            {
                string StringSql = "SELECT * FROM account_user WHERE user_name= '" + userName + "'";

                MySqlConnection Conexion = new MySqlConnection();
                MySqlCommand Query = new MySqlCommand();
                MySqlDataAdapter MySqlDa;
                Conexion.ConnectionString = Code.ConeccionString2.mysql();
                Conexion.Open();
                Query.CommandText = StringSql;
                Query.Connection = Conexion;
                MySqlDa = new MySqlDataAdapter(Query);
                MySqlDa.Fill(ds1);
                Conexion.Close();
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }

            return ds1.Tables[0].Rows[0];

        }
		#endregion

		#region Validate
		/*CAMBIO						FECHA			AUTOR
		LOGIN SUPERVISORES,CONTRATISTA	08-06-2021	    ALEXANDER FERNÁNDEZ 08-06-2021*/
		public static int Validate(string userName, string password)
         {
            int r = -1;
            string StringSql = "";
            DataSet ds1 = new DataSet();
            MySqlConnection Conexion = new MySqlConnection();
            MySqlCommand Query = new MySqlCommand();
            MySqlDataAdapter MySqlDa;
            if (userName == "GESOCOORDINADOR" || userName == "GESOSUPERVISOR" || userName == "GESOCONTRATISTA")
            {
                StringSql = "SELECT IDPERSONA FROM obrasemp.persona WHERE documento='" + password + "' ";
                try
                {

                    Conexion.ConnectionString = Code.ConeccionString2.mysql();
                    Conexion.Open();
                    Query.CommandText = StringSql;
                    Query.Connection = Conexion;
                    MySqlDa = new MySqlDataAdapter(Query);
                    MySqlDa.Fill(ds1);
                    Conexion.Close();
                    if (ds1.Tables[0].Rows.Count > 0) r = int.Parse(ds1.Tables[0].Rows[0][0].ToString());

                    if (r != -1)
                    {
                        r = -1;
                        StringSql = "SELECT user_id FROM account_user WHERE user_name='GESOCOORDINADOR' ";
                        Conexion.ConnectionString = Code.ConeccionString2.mysql();
                        Conexion.Open();
                        Query.CommandText = StringSql;
                        Query.Connection = Conexion;
                        MySqlDa = new MySqlDataAdapter(Query);
                        DataSet ds2 = new DataSet();

                        MySqlDa.Fill(ds2);
                        Conexion.Close();
                        if (ds2.Tables[0].Rows.Count > 0) r = int.Parse(ds2.Tables[0].Rows[0][0].ToString());
                    }
                }
                catch (Exception e1) { Trace.Write("Validate, Error : " + e1.Message.ToString()); }
            }
            else
            {
                StringSql = "SELECT user_id FROM account_user WHERE user_name='" + userName + "' ";
                StringSql += " AND password='" + password + "'; ";

                try
                {
                    Conexion.ConnectionString = Code.ConeccionString2.mysql();
                    Conexion.Open();
                    Query.CommandText = StringSql;
                    Query.Connection = Conexion;
                    MySqlDa = new MySqlDataAdapter(Query);
                    MySqlDa.Fill(ds1);
                    Conexion.Close();

                    if (ds1.Tables[0].Rows.Count > 0) r = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                }
                catch (Exception e1) { Trace.Write("Validate, Error : " + e1.Message.ToString()); }
            }
             return r;
        }
        #endregion

        #region Validate1
        public static DataSet Validate1(string userid)
        {
            //int r = -1;
            DataSet ds1 = new DataSet();
            DataSet r1 = new DataSet();
            string StringSql = "SELECT a.sec_ejec, b.nombre as descripcion_ejecutora,BASEDEDATOS, B.ESENCARGANTE FROM InfoReg_User_Ejecutora a, ejecutora b WHERE a.sec_ejec=b.sec_ejec and a.user_id=" + userid;
            try
            {
                MySqlConnection Conexion = new MySqlConnection();
                MySqlCommand Query = new MySqlCommand();
                MySqlDataAdapter MySqlDa;
                Conexion.ConnectionString = Code.ConeccionString2.mysql();
                Conexion.Open();
                Query.CommandText = StringSql;
                Query.Connection = Conexion;
                MySqlDa = new MySqlDataAdapter(Query);
                MySqlDa.Fill(ds1);
                Conexion.Close();
                r1 = ds1;
            }
            catch (Exception e1) { Trace.Write("Validate, Error : " + e1.Message.ToString()); }
            return r1;
        }
        #endregion

        #region Validate2
        public static DataSet Validate2(string userid,string SecEjec)
        {
            //int r = -1;
            DataSet ds1 = new DataSet();
            DataSet r1 = new DataSet();
            try
            {
                string StringSql = "SELECT a.sec_ejec, b.nombre as descripcion_ejecutora,BASEDEDATOS FROM InfoReg_User_Ejecutora a, ejecutora b WHERE a.sec_ejec=b.sec_ejec and a.user_id=" + userid + " and a.sec_ejec='" + SecEjec.PadLeft(6, '0') + "'";
                MySqlConnection Conexion = new MySqlConnection();
                MySqlCommand Query = new MySqlCommand();
                MySqlDataAdapter MySqlDa;
                Conexion.ConnectionString = Code.ConeccionString2.mysql();
                Conexion.Open();
                Query.CommandText = StringSql;
                Query.Connection = Conexion;
                MySqlDa = new MySqlDataAdapter(Query);
                MySqlDa.Fill(ds1);
                Conexion.Close();
                r1 = ds1;
            }
            catch (Exception e1) { Trace.Write("Validate, Error : " + e1.Message.ToString()); }
            return r1;
        }
        #endregion

        #region Validate1
        public static int Validate1(string userName, string password)
        {
             int r = -1;
             DataSet ds1 = new DataSet();

             try
             {

                 string StringSql = "SELECT ID_PERSONAL FROM account_user WHERE user_name='" + userName + "' ";
                 StringSql += " AND password='" + password + "'; "; 

                MySqlConnection Conexion = new MySqlConnection();
                MySqlCommand Query = new MySqlCommand();
                MySqlDataAdapter MySqlDa;
                Conexion.ConnectionString = Code.ConeccionString2.mysql();
                Conexion.Open();
                Query.CommandText = StringSql;
                Query.Connection = Conexion;
                MySqlDa = new MySqlDataAdapter(Query);
                MySqlDa.Fill(ds1);
                Conexion.Close();
             }
             catch (Exception e1) { Trace.Write("Validate, Error : " + e1.Message.ToString()); }
             return r;
  
        }
        #endregion

        /*Falta modificar todo haci abajo*/

		#region GetUserList
        public static DataSet GetUserList()
        {
			//MySqlConnection Conexion = new MySqlConnection();
			//MySqlCommand Query = new MySqlCommand();
			//MySqlDataAdapter MySqlDa;


			DataSet ds1 = new DataSet();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Code.ConeccionString2.mysql()))
                {
                    string StringSql = "Select * from account_user";
					MySqlDataAdapter adapter = new MySqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                }

            }
            catch (Exception e1) { Trace.Write("GetUserList, Error : " + e1.Message.ToString()); }
            return ds1;
        }
		#endregion

        #region AddRole
        public static int AddRole(string userId, string roleId)
        {
            int r = 0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    string cadenaInsertar = "INSERT INTO account_user_roles(role_id, user_id) VALUES (@roleId ,@userId)";
                    SqlCommand comando = new SqlCommand(cadenaInsertar, conexion);
                    //comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                    //comando.Parameters["@descripcion"].Value = descripcion.ToString();    
                    comando.Parameters.AddWithValue("@roleId", roleId.ToString());//1
                    comando.Parameters.AddWithValue("@userId", userId.ToString());//1

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();

                }
            }
            catch (Exception e1) { Trace.Write("Insert, Error : " + e1.Message.ToString()); }
            return r;

        }
        #endregion

        #region RemoveRole
        public static int RemoveRole(string userId, string IdRole)
        {

            int r = 0;
            try
            {
                string cadenaEliminar = "DELETE FROM account_user_roles WHERE user_id ='"+userId +"' and role_id='"+IdRole+"'";
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    SqlCommand comando = new SqlCommand(cadenaEliminar, conexion);
                    //comando.Parameters.Add("@userId", SqlDbType.VarChar);
                    //comando.Parameters.Add("@IdRole", SqlDbType.VarChar);
                    //comando.Parameters["@userId"].Value = userId.ToString();
                    //comando.Parameters["@IdRole"].Value = IdRole.ToString();
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


        #region RemoveEjecutora
        public static int RemoveEjecutora(string userId, string IdSecEjec)
        {

            int r = 0;
            try
            {
                string cadenaEliminar = "DELETE FROM InfoReg_user_ejecutora WHERE user_id ='" + userId + "' and sec_ejec='" + IdSecEjec+ "'";
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    SqlCommand comando = new SqlCommand(cadenaEliminar, conexion);
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

        #region AddEjecutora
        public static int AddEjecutora(string userId, string idSecjec)
        {
            int r = 0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    string cadenaInsertar = "INSERT INTO InfoReg_user_ejecutora(user_id,sec_ejec) ";
                    cadenaInsertar += "VALUES ('"+userId.ToString()+"','"+idSecjec.ToString()+"')";
                    SqlCommand comando = new SqlCommand(cadenaInsertar, conexion);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();

                }
            }
            catch (Exception e1) { Trace.Write("Insert, Error : " + e1.Message.ToString()); }
            return r;

        }
        #endregion

	}
}
