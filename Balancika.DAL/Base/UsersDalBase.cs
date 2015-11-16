using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class UsersDalBase : SqlServerConnection
	{
		public DataTable GetAllUsers(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Users", "*", " Where Users.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
        public DataTable GetAllUsersActiveInactive(Hashtable lstData)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("Users", "*", ";", lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public DataTable GetUsersByUserId(Hashtable lstData)
		{
			string whereCondition = " where Users.UserId = @UserId And Users.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Users", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertUsers(Hashtable lstData)
		{
            string sqlQuery = "Insert into Users (UserId, UserName, UserPassword, IsActive, UpdateBy, UpdateDate, CompanyId, EmployeeId) values(@UserId, @UserName, @UserPassword, @IsActive, @UpdateBy, @UpdateDate, @CompanyId, @EmployeeId);";
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

		public int UpdateUsers(Hashtable lstData)
		{
            string sqlQuery = "Update Users set UserName = @UserName, UserPassword = @UserPassword, IsActive = @IsActive, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate, CompanyId = @CompanyId, EmployeeId = @EmployeeId where Users.UserId = @UserId;";
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

		public int DeleteUsersByUserId(Hashtable lstData)
		{
			string sqlQuery = "delete from  Users where UserId = @UserId;";
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
