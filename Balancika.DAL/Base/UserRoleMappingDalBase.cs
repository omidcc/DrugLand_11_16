using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class UserRoleMappingDalBase : SqlServerConnection
	{
		public DataTable GetAllUserRoleMapping(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("UserRoleMapping", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetUserRoleMappingByMappingId(Hashtable lstData)
		{
			string whereCondition = " where UserRoleMapping.MappingId = @MappingId ";
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

		public int InsertUserRoleMapping(Hashtable lstData)
		{
			string sqlQuery ="Insert into UserRoleMapping (MappingId, UserId, RoleId) values(@MappingId, @UserId, @RoleId);";
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

		public int UpdateUserRoleMapping(Hashtable lstData)
		{
			string sqlQuery = "Update UserRoleMapping set UserId = @UserId, RoleId = @RoleId where UserRoleMapping.MappingId = @MappingId;";
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

		public int DeleteUserRoleMappingByMappingId(Hashtable lstData)
		{
			string sqlQuery = "delete from  UserRoleMapping where MappingId = @MappingId;";
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
	}
}
