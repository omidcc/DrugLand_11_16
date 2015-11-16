using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class ChartOfAccountDalBase : SqlServerConnection
	{
		public DataTable GetAllChartOfAccount(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ChartOfAccount", "*", " Where ChartOfAccount.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetChartOfAccountByCoaId(Hashtable lstData)
		{
			string whereCondition = " where ChartOfAccount.CoaId = @CoaId And ChartOfAccount.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ChartOfAccount", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertChartOfAccount(Hashtable lstData)
		{
			string sqlQuery ="Insert into ChartOfAccount (CoaId, CoaType, CoaGroupId, CoaCode, CoaTitle, ParentId, IsActive, UpdateBy, UpdateDate, CompanyId) values(@CoaId, @CoaType, @CoaGroupId, @CoaCode, @CoaTitle, @ParentId, @IsActive, @UpdateBy, @UpdateDate, @CompanyId);";
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

		public int UpdateChartOfAccount(Hashtable lstData)
		{
			string sqlQuery = "Update ChartOfAccount set CoaType = @CoaType, CoaGroupId = @CoaGroupId, CoaCode = @CoaCode, CoaTitle = @CoaTitle, ParentId = @ParentId, IsActive = @IsActive, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate, CompanyId = @CompanyId where ChartOfAccount.CoaId = @CoaId;";
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

		public int DeleteChartOfAccountByCoaId(Hashtable lstData)
		{
			string sqlQuery = "delete from  ChartOfAccount where CoaId = @CoaId;";
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
