using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using BALANCIKA.DAL;

namespace BALANCIKA.BLL.Base
{
	public class JournalDetailsBase
	{
		protected static BALANCIKA.DAL.JournalDetailsDal dal = new BALANCIKA.DAL.JournalDetailsDal();

		public System.Int64 JournalDetailsId		{ get ; set; }

		public System.Int64 MasterId		{ get ; set; }

		public System.Int64 AccountNo		{ get ; set; }

		public System.Decimal Debit		{ get ; set; }

		public System.Decimal Credit		{ get ; set; }

		public System.String Description		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }

		public System.String VoucherNo		{ get ; set; }


		public  Int32 InsertJournalDetails()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@JournalDetailsId", JournalDetailsId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@MasterId", MasterId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@AccountNo", AccountNo.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Debit", Debit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Credit", Credit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Description", Description);
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@VoucherNo", VoucherNo);

			return dal.InsertJournalDetails(lstItems);
		}

		public  Int32 UpdateJournalDetails()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@JournalDetailsId", JournalDetailsId.ToString());
			lstItems.Add("@MasterId", MasterId.ToString());
			lstItems.Add("@AccountNo", AccountNo.ToString());
			lstItems.Add("@Debit", Debit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Credit", Credit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Description", Description);
			lstItems.Add("@CompanyId", CompanyId.ToString());
			lstItems.Add("@VoucherNo", VoucherNo);

			return dal.UpdateJournalDetails(lstItems);
		}

		public  Int32 DeleteJournalDetailsByJournalDetailsId(Int64 JournalDetailsId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@JournalDetailsId", JournalDetailsId);

			return dal.DeleteJournalDetailsByJournalDetailsId(lstItems);
		}

		public List<JournalDetails> GetAllJournalDetails(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllJournalDetails(lstItems);
			List<JournalDetails> JournalDetailsList = new List<JournalDetails>();
			foreach (DataRow dr in dt.Rows)
			{
				JournalDetailsList.Add(GetObject(dr));
			}
			return JournalDetailsList;
		}

		public JournalDetails GetJournalDetailsByJournalDetailsId(int _JournalDetailsId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@JournalDetailsId", _JournalDetailsId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetJournalDetailsByJournalDetailsId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  JournalDetails GetObject(DataRow dr)
		{

			JournalDetails objJournalDetails = new JournalDetails();
			objJournalDetails.JournalDetailsId = (dr["JournalDetailsId"] == DBNull.Value) ? 0 : (Int64)dr["JournalDetailsId"];
			objJournalDetails.MasterId = (dr["MasterId"] == DBNull.Value) ? 0 : (Int64)dr["MasterId"];
			objJournalDetails.AccountNo = (dr["AccountNo"] == DBNull.Value) ? 0 : (Int64)dr["AccountNo"];
			objJournalDetails.Debit = (dr["Debit"] == DBNull.Value) ? 0 : (Decimal)dr["Debit"];
			objJournalDetails.Credit = (dr["Credit"] == DBNull.Value) ? 0 : (Decimal)dr["Credit"];
			objJournalDetails.Description = (dr["Description"] == DBNull.Value) ? "" : (String)dr["Description"];
			objJournalDetails.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];
			objJournalDetails.VoucherNo = (dr["VoucherNo"] == DBNull.Value) ? "" : (String)dr["VoucherNo"];

			return objJournalDetails;
		}
	}
}
