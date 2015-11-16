using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Balancika.DAL;

namespace BALANCIKA.DAL.Base
{
	public class JournalMasterDalBase : SqlServerConnection
	{
		public DataTable GetAllJournalMaster(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("JournalMaster", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetJournalMasterByJournalId(Hashtable lstData)
		{
			string whereCondition = " where JournalMaster.JournalId = @JournalId ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("JournalMaster", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertJournalMaster(Hashtable lstData)
		{
            string sqlQuery = "Insert into JournalMaster (JournalId, JournalDate, JournalType, JournalDescription, UpdateBy, UpdateDate, CompanyId, CostCenterId) values(@JournalId, @JournalDate, @JournalType, @JournalDescription, @UpdateBy, @UpdateDate, @CompanyId, @CostCenterId);";
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



            /***

			string sqlQuery ="Insert into JournalMaster (JournalId, JournalDate, JournalType, JournalDescription, UpdateBy, UpdateDate, ApprovedBy, ApprovedDate, CompanyId, PostDate, CostCenterId) values(@JournalId, @JournalDate, @JournalType, @JournalDescription, @UpdateBy, @UpdateDate, @ApprovedBy, @ApprovedDate, @CompanyId, @PostDate, @CostCenterId);";
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

            ***/
		}

		public int UpdateJournalMaster(Hashtable lstData)
		{
			string sqlQuery = "Update JournalMaster set JournalDate = @JournalDate, JournalType = @JournalType, JournalDescription = @JournalDescription, UpdateBy = @UpdateBy, UpdateDate = @UpdateDate, ApprovedBy = @ApprovedBy, ApprovedDate = @ApprovedDate, CompanyId = @CompanyId, PostDate = @PostDate, CostCenterId = @CostCenterId where JournalMaster.JournalId = @JournalId;";
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

		public int DeleteJournalMasterByJournalId(Hashtable lstData)
		{
			string sqlQuery = "delete from  JournalMaster where JournalId = @JournalId;";
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
