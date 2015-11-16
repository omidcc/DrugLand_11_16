using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class AddressesDalBase : SqlServerConnection
	{
		public DataTable GetAllAddresses(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Addresses", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAddressesByAddressId(Hashtable lstData)
		{
			string whereCondition = " where Addresses.AddressId = @AddressId ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Addresses", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertAddresses(Hashtable lstData)
		{
			string sqlQuery ="Insert into Addresses (AddressId, SourceType, SourceId, AddressType, AddressLine1, AddressLine2, City, ZipCode, CountryId, Phone, Mobile, Email, Web, CompanyId) values(@AddressId, @SourceType, @SourceId, @AddressType, @AddressLine1, @AddressLine2, @City, @ZipCode, @CountryId, @Phone, @Mobile, @Email, @Web, @CompanyId);";
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

		public int UpdateAddresses(Hashtable lstData)
		{
			string sqlQuery = "Update Addresses set SourceType = @SourceType, SourceId = @SourceId, AddressType = @AddressType, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, City = @City, ZipCode = @ZipCode, CountryId = @CountryId, Phone = @Phone, Mobile = @Mobile, Email = @Email, Web = @Web, CompanyId = @CompanyId where Addresses.AddressId = @AddressId;";
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

		public int DeleteAddressesByAddressId(Hashtable lstData)
		{
			string sqlQuery = "delete from  Addresses where AddressId = @AddressId;";
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
