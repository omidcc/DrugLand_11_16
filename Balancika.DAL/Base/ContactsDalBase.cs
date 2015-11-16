using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class ContactsDalBase : SqlServerConnection
	{
		public DataTable GetAllContacts(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Contacts", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetContactsByContactId(Hashtable lstData)
		{
			string whereCondition = " where Contacts.ContactId = @ContactId ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Contacts", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertContacts(Hashtable lstData)
		{
			string sqlQuery ="Insert into Contacts (ContactId, SourceType, SourceId, ContactName, ContactDesignation, IsMainContact, Phone, Mobile, Email, CompanyId) values(@ContactId, @SourceType, @SourceId, @ContactName, @ContactDesignation, @IsMainContact, @Phone, @Mobile, @Email, @CompanyId);";
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

		public int UpdateContacts(Hashtable lstData)
		{
			string sqlQuery = "Update Contacts set SourceType = @SourceType, SourceId = @SourceId, ContactName = @ContactName, ContactDesignation = @ContactDesignation, IsMainContact = @IsMainContact, Phone = @Phone, Mobile = @Mobile, Email = @Email, CompanyId = @CompanyId where Contacts.ContactId = @ContactId;";
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

		public int DeleteContactsByContactId(Hashtable lstData)
		{
			string sqlQuery = "delete from  Contacts where ContactId = @ContactId;";
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
