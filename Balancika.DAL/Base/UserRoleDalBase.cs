using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class UserRoleDalBase : SqlServerConnection
	{
		public DataTable GetAllUserRole(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("UserRole", "*", " Where UserRole.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetUserRoleByRoleId(Hashtable lstData)
		{
			string whereCondition = " where UserRole.RoleId = @RoleId And UserRole.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("UserRole", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertUserRole(Hashtable lstData)
		{
			string sqlQuery ="Insert into UserRole (RoleId, RoleName, IsActive, UpdateBy, UpdateDate, CompanyId) values(@RoleId, @RoleName, @IsActive, @UpdateBy, @UpdateDate, @CompanyId);";
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

		public int UpdateUserRole(Hashtable lstData)
		{
			string sqlQuery = "Update UserRole set RoleName = @RoleName, IsActive = @IsActive, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate, CompanyId = @CompanyId where UserRole.RoleId = @RoleId;";
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

		public int DeleteUserRoleByRoleId(Hashtable lstData)
		{
			string sqlQuery = "delete from  UserRole where RoleId = @RoleId;";
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
