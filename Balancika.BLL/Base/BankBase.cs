using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class BankBase
	{
		protected static Balancika.DAL.BankDal dal = new Balancika.DAL.BankDal();

		public System.Int32 BankId		{ get ; set; }

		public System.String BankCode		{ get ; set; }

		public System.String BankName		{ get ; set; }

		public System.String ContactPerson		{ get ; set; }

		public System.String ContactDesignation		{ get ; set; }

		public System.String ContactNo		{ get ; set; }

		public System.String ContactEmail		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Int32 UpdatedBy		{ get ; set; }

		public System.DateTime UpdatedDate		{ get ; set; }


		public  Int32 InsertBank()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@BankId", BankId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BankCode", BankCode);
			lstItems.Add("@BankName", BankName);
			lstItems.Add("@ContactPerson", ContactPerson);
			lstItems.Add("@ContactDesignation", ContactDesignation);
			lstItems.Add("@ContactNo", ContactNo);
			lstItems.Add("@ContactEmail", ContactEmail);
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdatedBy", UpdatedBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdatedDate", UpdatedDate.ToString(CultureInfo.InvariantCulture));

			return dal.InsertBank(lstItems);
		}

		public  Int32 UpdateBank()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@BankId", BankId.ToString());
			lstItems.Add("@BankCode", BankCode);
			lstItems.Add("@BankName", BankName);
			lstItems.Add("@ContactPerson", ContactPerson);
			lstItems.Add("@ContactDesignation", ContactDesignation);
			lstItems.Add("@ContactNo", ContactNo);
			lstItems.Add("@ContactEmail", ContactEmail);
			lstItems.Add("@CompanyId", CompanyId.ToString());
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdatedBy", UpdatedBy.ToString());
			lstItems.Add("@UpdatedDate", UpdatedDate.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateBank(lstItems);
		}

		public  Int32 DeleteBankByBankId(Int32 BankId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@BankId", BankId);

			return dal.DeleteBankByBankId(lstItems);
		}

		public List<Bank> GetAllBank(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllBank(lstItems);
			List<Bank> BankList = new List<Bank>();
			foreach (DataRow dr in dt.Rows)
			{
				BankList.Add(GetObject(dr));
			}
			return BankList;
		}

		public Bank GetBankByBankId(int _BankId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@BankId", _BankId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetBankByBankId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Bank GetObject(DataRow dr)
		{

			Bank objBank = new Bank();
			objBank.BankId = (dr["BankId"] == DBNull.Value) ? 0 : (Int32)dr["BankId"];
			objBank.BankCode = (dr["BankCode"] == DBNull.Value) ? "" : (String)dr["BankCode"];
			objBank.BankName = (dr["BankName"] == DBNull.Value) ? "" : (String)dr["BankName"];
			objBank.ContactPerson = (dr["ContactPerson"] == DBNull.Value) ? "" : (String)dr["ContactPerson"];
			objBank.ContactDesignation = (dr["ContactDesignation"] == DBNull.Value) ? "" : (String)dr["ContactDesignation"];
			objBank.ContactNo = (dr["ContactNo"] == DBNull.Value) ? "" : (String)dr["ContactNo"];
			objBank.ContactEmail = (dr["ContactEmail"] == DBNull.Value) ? "" : (String)dr["ContactEmail"];
			objBank.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];
			objBank.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objBank.UpdatedBy = (dr["UpdatedBy"] == DBNull.Value) ? 0 : (Int32)dr["UpdatedBy"];
			objBank.UpdatedDate = (dr["UpdatedDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdatedDate"];

			return objBank;
		}
	}
}
