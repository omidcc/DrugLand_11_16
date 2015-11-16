using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class SupplierDalBase : SqlServerConnection
	{
		public DataTable GetAllSupplier(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Supplier", "*", " Where Supplier.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetSupplierBySupplierId(Hashtable lstData)
		{
			string whereCondition = " where Supplier.SupplierId = @SupplierId And Supplier.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Supplier", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertSupplier(Hashtable lstData)
		{
            // changes occured Supplier-->, Balance Values --> , @Balance
			string sqlQuery ="Insert into Supplier (SupplierId, SupplierName, IsActive, CompanyId, UpdateBy, UpdateDate, TotalDebit, TotalCredit) values(@SupplierId, @SupplierName, @IsActive, @CompanyId, @UpdateBy, @UpdateDate, @TotalDebit, @TotalCredit);";
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

		public int UpdateSupplier(Hashtable lstData)
		{
			string sqlQuery = "Update Supplier set SupplierName = @SupplierName, IsActive = @IsActive, CompanyId = @CompanyId, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate, TotalDebit = @TotalDebit, TotalCredit = @TotalCredit, Balance = @Balance where Supplier.SupplierId = @SupplierId;";
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

		public int DeleteSupplierBySupplierId(Hashtable lstData)
		{
			string sqlQuery = "delete from  Supplier where SupplierId = @SupplierId;";
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
