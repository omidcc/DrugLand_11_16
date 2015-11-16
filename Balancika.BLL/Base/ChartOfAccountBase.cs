using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class ChartOfAccountBase
	{
		protected static Balancika.DAL.ChartOfAccountDal dal = new Balancika.DAL.ChartOfAccountDal();

		public System.Int32 CoaId		{ get ; set; }

		public System.String CoaType		{ get ; set; }

		public System.Int32 CoaGroupId		{ get ; set; }

		public System.String CoaCode		{ get ; set; }

		public System.String CoaTitle		{ get ; set; }

		public System.Int32 ParentId		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Int32 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }


		public  Int32 InsertChartOfAccount()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CoaId", CoaId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CoaType", CoaType);
			lstItems.Add("@CoaGroupId", CoaGroupId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CoaCode", CoaCode);
			lstItems.Add("@CoaTitle", CoaTitle);
			lstItems.Add("@ParentId", ParentId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertChartOfAccount(lstItems);
		}

		public  Int32 UpdateChartOfAccount()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CoaId", CoaId.ToString());
			lstItems.Add("@CoaType", CoaType);
			lstItems.Add("@CoaGroupId", CoaGroupId.ToString());
			lstItems.Add("@CoaCode", CoaCode);
			lstItems.Add("@CoaTitle", CoaTitle);
			lstItems.Add("@ParentId", ParentId.ToString());
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString());

			return dal.UpdateChartOfAccount(lstItems);
		}

		public  Int32 DeleteChartOfAccountByCoaId(Int32 CoaId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CoaId", CoaId);

			return dal.DeleteChartOfAccountByCoaId(lstItems);
		}

		public List<ChartOfAccount> GetAllChartOfAccount(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllChartOfAccount(lstItems);
			List<ChartOfAccount> ChartOfAccountList = new List<ChartOfAccount>();
			foreach (DataRow dr in dt.Rows)
			{
				ChartOfAccountList.Add(GetObject(dr));
			}
			return ChartOfAccountList;
		}

		public ChartOfAccount GetChartOfAccountByCoaId(int _CoaId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CoaId", _CoaId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetChartOfAccountByCoaId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  ChartOfAccount GetObject(DataRow dr)
		{

			ChartOfAccount objChartOfAccount = new ChartOfAccount();
			objChartOfAccount.CoaId = (dr["CoaId"] == DBNull.Value) ? 0 : (Int32)dr["CoaId"];
			objChartOfAccount.CoaType = (dr["CoaType"] == DBNull.Value) ? "" : (String)dr["CoaType"];
			objChartOfAccount.CoaGroupId = (dr["CoaGroupId"] == DBNull.Value) ? 0 : (Int32)dr["CoaGroupId"];
			objChartOfAccount.CoaCode = (dr["CoaCode"] == DBNull.Value) ? "" : (String)dr["CoaCode"];
			objChartOfAccount.CoaTitle = (dr["CoaTitle"] == DBNull.Value) ? "" : (String)dr["CoaTitle"];
			objChartOfAccount.ParentId = (dr["ParentId"] == DBNull.Value) ? 0 : (Int32)dr["ParentId"];
			objChartOfAccount.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objChartOfAccount.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int32)dr["UpdateBy"];
			objChartOfAccount.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];
			objChartOfAccount.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];

			return objChartOfAccount;
		}
	}
}
