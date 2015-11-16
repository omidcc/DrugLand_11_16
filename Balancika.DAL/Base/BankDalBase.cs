using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class BankDalBase : SqlServerConnection
	{
		public DataTable GetAllBank(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Bank", "*", " Where Bank.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetBankByBankId(Hashtable lstData)
		{
			string whereCondition = " where Bank.BankId = @BankId And Bank.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Bank", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertBank(Hashtable lstData)
		{
			string sqlQuery ="Insert into Bank (BankId, BankCode, BankName, ContactPerson, ContactDesignation, ContactNo, ContactEmail, CompanyId, IsActive, UpdatedBy, UpdatedDate) values(@BankId, @BankCode, @BankName, @ContactPerson, @ContactDesignation, @ContactNo, @ContactEmail, @CompanyId, @IsActive, @UpdatedBy, @UpdatedDate);";
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

		public int UpdateBank(Hashtable lstData)
		{
			string sqlQuery = "Update Bank set BankCode = @BankCode, BankName = @BankName, ContactPerson = @ContactPerson, ContactDesignation = @ContactDesignation, ContactNo = @ContactNo, ContactEmail = @ContactEmail, CompanyId = @CompanyId, IsActive = @IsActive, UpdatedBy = @UpdatedBy, UpdatedDate = @UpdatedDate where Bank.BankId = @BankId;";
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

		public int DeleteBankByBankId(Hashtable lstData)
		{
			string sqlQuery = "delete from  Bank where BankId = @BankId;";
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
