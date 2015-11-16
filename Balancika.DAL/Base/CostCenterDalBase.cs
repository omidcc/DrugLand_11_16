using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Balancika.DAL;

namespace BALANCIKA.DAL.Base
{
	public class CostCenterDalBase : SqlServerConnection
	{
		public DataTable GetAllCostCenter(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("CostCenter", "*", " Where CostCenter.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetCostCenterByCostCenterId(Hashtable lstData)
		{
			string whereCondition = " where CostCenter.CostCenterId = @CostCenterId And CostCenter.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("CostCenter", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertCostCenter(Hashtable lstData)
		{
			string sqlQuery ="Insert into CostCenter (CostCenterId, CostCenterType, CostCenterName, IsActive, CompanyId, UpdateBy, UpdateDate) values(@CostCenterId, @CostCenterType, @CostCenterName, @IsActive, @CompanyId, @UpdateBy, @UpdateDate);";
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

		public int UpdateCostCenter(Hashtable lstData)
		{
			string sqlQuery = "Update CostCenter set CostCenterType = @CostCenterType, CostCenterName = @CostCenterName, IsActive = @IsActive, CompanyId = @CompanyId, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate where CostCenter.CostCenterId = @CostCenterId;";
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

		public int DeleteCostCenterByCostCenterId(Hashtable lstData)
		{
			string sqlQuery = "delete from  CostCenter where CostCenterId = @CostCenterId;";
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
