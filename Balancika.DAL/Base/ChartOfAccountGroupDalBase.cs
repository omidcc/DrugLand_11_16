using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class ChartOfAccountGroupDalBase : SqlServerConnection
	{
		public DataTable GetAllChartOfAccountGroup(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ChartOfAccountGroup", "*", " Where ChartOfAccountGroup.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetChartOfAccountGroupByCoaGroupId(Hashtable lstData)
		{
			string whereCondition = " where ChartOfAccountGroup.CoaGroupId = @CoaGroupId And ChartOfAccountGroup.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ChartOfAccountGroup", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertChartOfAccountGroup(Hashtable lstData)
		{
			string sqlQuery ="Insert into ChartOfAccountGroup (CoaGroupId, CoaGroupName, ParentId, IsActive, UpdateBy, UpdateDate, CompanyId) values(@CoaGroupId, @CoaGroupName, @ParentId, @IsActive, @UpdateBy, @UpdateDate, @CompanyId);";
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

		public int UpdateChartOfAccountGroup(Hashtable lstData)
		{
			string sqlQuery = "Update ChartOfAccountGroup set CoaGroupName = @CoaGroupName, ParentId = @ParentId, IsActive = @IsActive, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate, CompanyId = @CompanyId where ChartOfAccountGroup.CoaGroupId = @CoaGroupId;";
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

		public int DeleteChartOfAccountGroupByCoaGroupId(Hashtable lstData)
		{
			string sqlQuery = "delete from  ChartOfAccountGroup where CoaGroupId = @CoaGroupId;";
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
