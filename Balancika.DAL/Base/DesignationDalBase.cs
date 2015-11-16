using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class DesignationDalBase : SqlServerConnection
	{
		public DataTable GetAllDesignation(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Designation", "*", " Where Designation.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetDesignationByDesignationId(Hashtable lstData)
		{
			string whereCondition = " where Designation.DesignationId = @DesignationId And Designation.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Designation", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertDesignation(Hashtable lstData)
		{
			string sqlQuery ="Insert into Designation (DesignationId, Designation, DepartmentId, CompanyId, IsActive, UpdateBy, UpdateDate) values(@DesignationId, @Designation, @DepartmentId, @CompanyId, @IsActive, @UpdateBy, @UpdateDate);";
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

		public int UpdateDesignation(Hashtable lstData)
		{
			string sqlQuery = "Update Designation set Designation = @Designation, DepartmentId = @DepartmentId, CompanyId = @CompanyId, IsActive = @IsActive, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate where Designation.DesignationId = @DesignationId;";
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

		public int DeleteDesignationByDesignationId(Hashtable lstData)
		{
			string sqlQuery = "delete from  Designation where DesignationId = @DesignationId;";
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
