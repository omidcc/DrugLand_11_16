using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class DepartmentDalBase : SqlServerConnection
	{
		public DataTable GetAllDepartment(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Department", "*", " Where Department.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetDepartmentByDepartmentId(Hashtable lstData)
		{
			string whereCondition = " where Department.DepartmentId = @DepartmentId And Department.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Department", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertDepartment(Hashtable lstData)
		{
			string sqlQuery ="Insert into Department (DepartmentId, DepartmentName, ParentDepartmentId, IsActive, UpdateBy, UpdateDate, CompanyId) values(@DepartmentId, @DepartmentName, @ParentDepartmentId, @IsActive, @UpdateBy, @UpdateDate, @CompanyId);";
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

		public int UpdateDepartment(Hashtable lstData)
		{
			string sqlQuery = "Update Department set DepartmentName = @DepartmentName, ParentDepartmentId = @ParentDepartmentId, IsActive = @IsActive, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate, CompanyId = @CompanyId where Department.DepartmentId = @DepartmentId;";
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

		public int DeleteDepartmentByDepartmentId(Hashtable lstData)
		{
			string sqlQuery = "delete from  Department where DepartmentId = @DepartmentId;";
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
