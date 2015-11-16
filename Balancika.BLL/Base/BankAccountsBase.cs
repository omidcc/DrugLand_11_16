using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class BankAccountsBase
	{
		protected static Balancika.DAL.BankAccountsDal dal = new Balancika.DAL.BankAccountsDal();

		public System.Int64 BankAccountId		{ get ; set; }

		public System.Int64 BankId		{ get ; set; }

		public System.String BranchName		{ get ; set; }

		public System.String AccountNo		{ get ; set; }

		public System.String AccountTitle		{ get ; set; }

		public System.String AccountType		{ get ; set; }

		public System.String OpeningDate		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }


		public  Int32 InsertBankAccounts()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@BankAccountId", BankAccountId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BankId", BankId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BranchName", BranchName);
			lstItems.Add("@AccountNo", AccountNo);
			lstItems.Add("@AccountTitle", AccountTitle);
			lstItems.Add("@AccountType", AccountType);
			lstItems.Add("@OpeningDate", OpeningDate);
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);

			return dal.InsertBankAccounts(lstItems);
		}

		public  Int32 UpdateBankAccounts()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@BankAccountId", BankAccountId.ToString());
			lstItems.Add("@BankId", BankId.ToString());
			lstItems.Add("@BranchName", BranchName);
			lstItems.Add("@AccountNo", AccountNo);
			lstItems.Add("@AccountTitle", AccountTitle);
			lstItems.Add("@AccountType", AccountType);
			lstItems.Add("@OpeningDate", OpeningDate);
			lstItems.Add("@CompanyId", CompanyId.ToString());
			lstItems.Add("@IsActive", IsActive);

			return dal.UpdateBankAccounts(lstItems);
		}

		public  Int32 DeleteBankAccountsByBankAccountId(Int64 BankAccountId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@BankAccountId", BankAccountId);

			return dal.DeleteBankAccountsByBankAccountId(lstItems);
		}

		public List<BankAccounts> GetAllBankAccounts(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllBankAccounts(lstItems);
			List<BankAccounts> BankAccountsList = new List<BankAccounts>();
			foreach (DataRow dr in dt.Rows)
			{
				BankAccountsList.Add(GetObject(dr));
			}
			return BankAccountsList;
		}

		public BankAccounts GetBankAccountsByBankAccountId(int _BankAccountId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@BankAccountId", _BankAccountId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetBankAccountsByBankAccountId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  BankAccounts GetObject(DataRow dr)
		{

			BankAccounts objBankAccounts = new BankAccounts();
			objBankAccounts.BankAccountId = (dr["BankAccountId"] == DBNull.Value) ? 0 : (Int64)dr["BankAccountId"];
			objBankAccounts.BankId = (dr["BankId"] == DBNull.Value) ? 0 : (Int64)dr["BankId"];
			objBankAccounts.BranchName = (dr["BranchName"] == DBNull.Value) ? "" : (String)dr["BranchName"];
			objBankAccounts.AccountNo = (dr["AccountNo"] == DBNull.Value) ? "" : (String)dr["AccountNo"];
			objBankAccounts.AccountTitle = (dr["AccountTitle"] == DBNull.Value) ? "" : (String)dr["AccountTitle"];
			objBankAccounts.AccountType = (dr["AccountType"] == DBNull.Value) ? "" : (String)dr["AccountType"];
			objBankAccounts.OpeningDate = (dr["OpeningDate"] == DBNull.Value) ? "" : (String)dr["OpeningDate"].ToString();
			objBankAccounts.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];
			objBankAccounts.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];

			return objBankAccounts;
		}
	}
}
