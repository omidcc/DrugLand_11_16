using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Balancika.DAL.Base
{
	public class ListTableDalBase : SqlServerConnection
	{
		public DataTable GetAllListTable(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ListTable", "*", " Where ListTable.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetListTableById(Hashtable lstData)
		{
			string whereCondition = " where ListTable.Id = @Id And ListTable.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ListTable", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertListTable(Hashtable lstData)
		{
			string sqlQuery ="Insert into ListTable (Id, ListType, ListId, ListValue, CompanyId, IsActive, UpdateBy, UpdateDate) values(@Id, @ListType, @ListId, @ListValue, @CompanyId, @IsActive, @UpdateBy, @UpdateDate);";
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

		public int UpdateListTable(Hashtable lstData)
		{
			string sqlQuery = "Update ListTable set ListType = @ListType, ListId = @ListId, ListValue = @ListValue, CompanyId = @CompanyId, IsActive = @IsActive, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate where ListTable.Id = @Id;";
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

		public int DeleteListTableById(Hashtable lstData)
		{
			string sqlQuery = "delete from  ListTable where Id = @Id;";
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
