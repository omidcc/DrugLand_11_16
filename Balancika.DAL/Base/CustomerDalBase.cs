using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class CustomerDalBase : SqlServerConnection
	{
		public DataTable GetAllCustomer(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Customer", "*", " Where Customer.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetCustomerByCustomerId(Hashtable lstData)
		{
			string whereCondition = " where Customer.CustomerId = @CustomerId And Customer.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Customer", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertCustomer(Hashtable lstData)
		{

            //Changes Balance Deleted ** values-->, @Balance  Customer-->, Balance
			string sqlQuery ="Insert into Customer (CustomerId, CustomerName, CustomerCategoryId, SalesPersonId, IsActive, CompanyId, CreditLimit, UpdateBy, UpdateDate, TotalDebit, TotalCredit) values(@CustomerId, @CustomerName, @CustomerCategoryId, @SalesPersonId, @IsActive, @CompanyId, @CreditLimit, @UpdateBy, @UpdateDate, @TotalDebit, @TotalCredit);";
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

		public int UpdateCustomer(Hashtable lstData)
		{
			string sqlQuery = "Update Customer set CustomerName = @CustomerName, CustomerCategoryId = @CustomerCategoryId, SalesPersonId = @SalesPersonId, IsActive = @IsActive, CompanyId = @CompanyId, CreditLimit = @CreditLimit, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate, TotalDebit = @TotalDebit, TotalCredit = @TotalCredit, Balance = @Balance where Customer.CustomerId = @CustomerId;";
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

		public int DeleteCustomerByCustomerId(Hashtable lstData)
		{
			string sqlQuery = "delete from  Customer where CustomerId = @CustomerId;";
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
