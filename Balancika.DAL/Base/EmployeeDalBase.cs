using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class EmployeeDalBase : SqlServerConnection
	{
		public DataTable GetAllEmployee(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Employee", "*", " Where Employee.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetEmployeeByEmployeeId(Hashtable lstData)
		{
			string whereCondition = " where Employee.EmployeeId = @EmployeeId And Employee.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Employee", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertEmployee(Hashtable lstData)
		{
			string sqlQuery ="Insert into Employee (EmployeeId, EmployeeCode, EmployeeName, Address, DOB, JoinDate, DepartmentId, DesignationId, CompanyId, IsActive, UpdateBy, UpdateDate) values(@EmployeeId, @EmployeeCode, @EmployeeName, @Address, @DOB, @JoinDate, @DepartmentId, @DesignationId, @CompanyId, @IsActive, @UpdateBy, @UpdateDate);";
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

		public int UpdateEmployee(Hashtable lstData)
		{
			string sqlQuery = "Update Employee set EmployeeCode = @EmployeeCode, EmployeeName = @EmployeeName, Address = @Address, DOB = @DOB, JoinDate = @JoinDate, DepartmentId = @DepartmentId, DesignationId = @DesignationId, CompanyId = @CompanyId, IsActive = @IsActive, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate where Employee.EmployeeId = @EmployeeId;";
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

		public int DeleteEmployeeByEmployeeId(Hashtable lstData)
		{
			string sqlQuery = "delete from  Employee where EmployeeId = @EmployeeId;";
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
