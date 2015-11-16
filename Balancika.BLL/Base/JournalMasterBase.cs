using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using BALANCIKA.DAL;

namespace BALANCIKA.BLL.Base
{
	public class JournalMasterBase
	{
		protected static BALANCIKA.DAL.JournalMasterDal dal = new BALANCIKA.DAL.JournalMasterDal();

		public System.Int64 JournalId		{ get ; set; }

		public System.String JournalDate		{ get ; set; }

		public System.String JournalType		{ get ; set; }

		public System.String JournalDescription		{ get ; set; }

		public System.Int32 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }

		public System.Int32 ApprovedBy		{ get ; set; }

		public System.DateTime ApprovedDate		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }

		public System.DateTime PostDate		{ get ; set; }

		public System.Int32 CostCenterId		{ get ; set; }


		public  Int32 InsertJournalMaster()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@JournalId", JournalId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@JournalDate", JournalDate);
			lstItems.Add("@JournalType", JournalType);
			lstItems.Add("@JournalDescription", JournalDescription);
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ApprovedBy", ApprovedBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ApprovedDate", ApprovedDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PostDate", PostDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CostCenterId", CostCenterId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertJournalMaster(lstItems);
		}

		public  Int32 UpdateJournalMaster()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@JournalId", JournalId.ToString());
			lstItems.Add("@JournalDate", JournalDate);
			lstItems.Add("@JournalType", JournalType);
			lstItems.Add("@JournalDescription", JournalDescription);
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ApprovedBy", ApprovedBy.ToString());
			lstItems.Add("@ApprovedDate", ApprovedDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString());
			lstItems.Add("@PostDate", PostDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CostCenterId", CostCenterId.ToString());

			return dal.UpdateJournalMaster(lstItems);
		}

		public  Int32 DeleteJournalMasterByJournalId(Int64 JournalId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@JournalId", JournalId);

			return dal.DeleteJournalMasterByJournalId(lstItems);
		}

		public List<JournalMaster> GetAllJournalMaster(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllJournalMaster(lstItems);
			List<JournalMaster> JournalMasterList = new List<JournalMaster>();
			foreach (DataRow dr in dt.Rows)
			{
				JournalMasterList.Add(GetObject(dr));
			}
			return JournalMasterList;
		}

		public JournalMaster GetJournalMasterByJournalId(int _JournalId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@JournalId", _JournalId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetJournalMasterByJournalId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  JournalMaster GetObject(DataRow dr)
		{

			JournalMaster objJournalMaster = new JournalMaster();
			objJournalMaster.JournalId = (dr["JournalId"] == DBNull.Value) ? 0 : (Int64)dr["JournalId"];
			objJournalMaster.JournalDate = (dr["JournalDate"] == DBNull.Value) ? "" : (String)dr["JournalDate"].ToString();
			objJournalMaster.JournalType = (dr["JournalType"] == DBNull.Value) ? "" : (String)dr["JournalType"];
			objJournalMaster.JournalDescription = (dr["JournalDescription"] == DBNull.Value) ? "" : (String)dr["JournalDescription"];
			objJournalMaster.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int32)dr["UpdateBy"];
			objJournalMaster.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];
			objJournalMaster.ApprovedBy = (dr["ApprovedBy"] == DBNull.Value) ? 0 : (Int32)dr["ApprovedBy"];
			objJournalMaster.ApprovedDate = (dr["ApprovedDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["ApprovedDate"];
			objJournalMaster.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];
			objJournalMaster.PostDate = (dr["PostDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["PostDate"];
			objJournalMaster.CostCenterId = (dr["CostCenterId"] == DBNull.Value) ? 0 : (Int32)dr["CostCenterId"];

			return objJournalMaster;
		}
	}
}
