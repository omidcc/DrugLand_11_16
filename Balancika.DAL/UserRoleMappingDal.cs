using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class UserRoleMappingDal : Balancika.DAL.Base.UserRoleMappingDalBase
	{
		public UserRoleMappingDal() : base()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public int DeleteUserRoleMappingByUserId(Hashtable lstData)
        {
            string sqlQuery = "delete from  UserRoleMapping where UserId = @UserId;";
            try
            {
                int success = ExecuteNonQuery(sqlQuery, lstData);
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public DataTable GetUserRoleMappingByUserId(Hashtable lstData)
        {
            string whereCondition = " where UserRoleMapping.UserId = @UserId";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("UserRoleMapping", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public string GetRoleIdForUser(Hashtable lstData)
        {
            string whereCondition = " where UserRoleMapping.UserId = @UserId";
            DataTable dt = new DataTable();
            try
            {
                return ExecuteScaler("UserRoleMapping", "RoleId", whereCondition, lstData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	
	}
}
