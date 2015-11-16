using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class BankAccountsDalBase : SqlServerConnection
	{
		public DataTable GetAllBankAccounts(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("BankAccounts", "*", " Where BankAccounts.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetBankAccountsByBankAccountId(Hashtable lstData)
		{
			string whereCondition = " where BankAccounts.BankAccountId = @BankAccountId And BankAccounts.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("BankAccounts", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertBankAccounts(Hashtable lstData)
		{
			string sqlQuery ="Insert into BankAccounts (BankAccountId, BankId, BranchName, AccountNo, AccountTitle, AccountType, OpeningDate, CompanyId, IsActive) values(@BankAccountId, @BankId, @BranchName, @AccountNo, @AccountTitle, @AccountType, @OpeningDate, @CompanyId, @IsActive);";
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

		public int UpdateBankAccounts(Hashtable lstData)
		{
			string sqlQuery = "Update BankAccounts set BankId = @BankId, BranchName = @BranchName, AccountNo = @AccountNo, AccountTitle = @AccountTitle, AccountType = @AccountType, OpeningDate = @OpeningDate, CompanyId = @CompanyId, IsActive = @IsActive where BankAccounts.BankAccountId = @BankAccountId;";
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

		public int DeleteBankAccountsByBankAccountId(Hashtable lstData)
		{
			string sqlQuery = "delete from  BankAccounts where BankAccountId = @BankAccountId;";
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
