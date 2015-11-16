using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Balancika.DAL;

namespace BALANCIKA.DAL.Base
{
	public class JournalDetailsDalBase : SqlServerConnection
	{
		public DataTable GetAllJournalDetails(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("JournalDetails", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetJournalDetailsByJournalDetailsId(Hashtable lstData)
		{
			string whereCondition = " where JournalDetails.JournalDetailsId = @JournalDetailsId ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("JournalDetails", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertJournalDetails(Hashtable lstData)
		{
			string sqlQuery ="Insert into JournalDetails (JournalDetailsId, MasterId, AccountNo, Debit, Credit, Description, CompanyId, VoucherNo) values(@JournalDetailsId, @MasterId, @AccountNo, @Debit, @Credit, @Description, @CompanyId, @VoucherNo);";
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

		public int UpdateJournalDetails(Hashtable lstData)
		{
			string sqlQuery = "Update JournalDetails set MasterId = @MasterId, AccountNo = @AccountNo, Debit = @Debit, Credit = @Credit, Description = @Description, CompanyId = @CompanyId, VoucherNo = @VoucherNo where JournalDetails.JournalDetailsId = @JournalDetailsId;";
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

		public int DeleteJournalDetailsByJournalDetailsId(Hashtable lstData)
		{
			string sqlQuery = "delete from  JournalDetails where JournalDetailsId = @JournalDetailsId;";
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
