using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class CompanyDalBase : SqlServerConnection
	{
		public DataTable GetAllCompany(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Company", "*", " Where Company.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetCompanyByCompanyId(Hashtable lstData)
		{
			string whereCondition = " where Company.CompanyId = @CompanyId And Company.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Company", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertCompany(Hashtable lstData)
		{
			string sqlQuery ="Insert into Company (CompanyName, Address, Phone, Email, Web, LogoPath, UpdateBy, UpdateDate, IsActive) values(@CompanyName, @Address, @Phone, @Email, @Web, @LogoPath, @UpdateBy, @UpdateDate, @IsActive);";
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

		public int UpdateCompany(Hashtable lstData)
		{
			string sqlQuery = "Update Company set CompanyName = @CompanyName, Address = @Address, Phone = @Phone, Email = @Email, Web = @Web, LogoPath = @LogoPath, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate, IsActive = @IsActive where Company.CompanyId = @CompanyId;";
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

		public int DeleteCompanyByCompanyId(Hashtable lstData)
		{
			string sqlQuery = "delete from  Company where CompanyId = @CompanyId;";
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
