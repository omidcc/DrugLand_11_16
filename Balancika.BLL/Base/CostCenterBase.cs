using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using BALANCIKA.DAL;

namespace BALANCIKA.BLL.Base
{
	public class CostCenterBase
	{
		protected static BALANCIKA.DAL.CostCenterDal dal = new BALANCIKA.DAL.CostCenterDal();

		public System.Int32 CostCenterId		{ get ; set; }

		public System.String CostCenterType		{ get ; set; }

		public System.String CostCenterName		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }

		public System.Int32 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }


		public  Int32 InsertCostCenter()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CostCenterId", CostCenterId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CostCenterType", CostCenterType);
			lstItems.Add("@CostCenterName", CostCenterName);
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));

			return dal.InsertCostCenter(lstItems);
		}

		public  Int32 UpdateCostCenter()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CostCenterId", CostCenterId.ToString());
			lstItems.Add("@CostCenterType", CostCenterType);
			lstItems.Add("@CostCenterName", CostCenterName);
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@CompanyId", CompanyId.ToString());
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateCostCenter(lstItems);
		}

		public  Int32 DeleteCostCenterByCostCenterId(Int32 CostCenterId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CostCenterId", CostCenterId);

			return dal.DeleteCostCenterByCostCenterId(lstItems);
		}

		public List<CostCenter> GetAllCostCenter(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllCostCenter(lstItems);
			List<CostCenter> CostCenterList = new List<CostCenter>();
			foreach (DataRow dr in dt.Rows)
			{
				CostCenterList.Add(GetObject(dr));
			}
			return CostCenterList;
		}

		public CostCenter GetCostCenterByCostCenterId(int _CostCenterId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CostCenterId", _CostCenterId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetCostCenterByCostCenterId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  CostCenter GetObject(DataRow dr)
		{

			CostCenter objCostCenter = new CostCenter();
			objCostCenter.CostCenterId = (dr["CostCenterId"] == DBNull.Value) ? 0 : (Int32)dr["CostCenterId"];
			objCostCenter.CostCenterType = (dr["CostCenterType"] == DBNull.Value) ? "" : (String)dr["CostCenterType"];
			objCostCenter.CostCenterName = (dr["CostCenterName"] == DBNull.Value) ? "" : (String)dr["CostCenterName"];
			objCostCenter.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objCostCenter.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];
			objCostCenter.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int32)dr["UpdateBy"];
			objCostCenter.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];

			return objCostCenter;
		}
	}
}
