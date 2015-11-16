using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class SupplierBase
	{
		protected static Balancika.DAL.SupplierDal dal = new Balancika.DAL.SupplierDal();

		public System.Int64 SupplierId		{ get ; set; }

		public System.String SupplierName		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }

		public System.Int64 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }

		public System.Decimal TotalDebit		{ get ; set; }

		public System.Decimal TotalCredit		{ get ; set; }

		public System.Decimal Balance		{ get ; set; }


		public  Int32 InsertSupplier()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@SupplierId", SupplierId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@SupplierName", SupplierName);
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalDebit", TotalDebit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalCredit", TotalCredit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Balance", Balance.ToString(CultureInfo.InvariantCulture));

			return dal.InsertSupplier(lstItems);
		}

		public  Int32 UpdateSupplier()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@SupplierId", SupplierId.ToString());
			lstItems.Add("@SupplierName", SupplierName);
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@CompanyId", CompanyId.ToString());
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalDebit", TotalDebit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalCredit", TotalCredit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Balance", Balance.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateSupplier(lstItems);
		}

		public  Int32 DeleteSupplierBySupplierId(Int64 SupplierId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@SupplierId", SupplierId);

			return dal.DeleteSupplierBySupplierId(lstItems);
		}

		public List<Supplier> GetAllSupplier(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllSupplier(lstItems);
			List<Supplier> SupplierList = new List<Supplier>();
			foreach (DataRow dr in dt.Rows)
			{
				SupplierList.Add(GetObject(dr));
			}
			return SupplierList;
		}

		public Supplier GetSupplierBySupplierId(int _SupplierId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@SupplierId", _SupplierId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetSupplierBySupplierId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Supplier GetObject(DataRow dr)
		{

			Supplier objSupplier = new Supplier();
			objSupplier.SupplierId = (dr["SupplierId"] == DBNull.Value) ? 0 : (Int64)dr["SupplierId"];
			objSupplier.SupplierName = (dr["SupplierName"] == DBNull.Value) ? "" : (String)dr["SupplierName"];
			objSupplier.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objSupplier.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];
			objSupplier.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int64)dr["UpdateBy"];
			objSupplier.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];
			objSupplier.TotalDebit = (dr["TotalDebit"] == DBNull.Value) ? 0 : (Decimal)dr["TotalDebit"];
			objSupplier.TotalCredit = (dr["TotalCredit"] == DBNull.Value) ? 0 : (Decimal)dr["TotalCredit"];
			objSupplier.Balance = (dr["Balance"] == DBNull.Value) ? 0 : (Decimal)dr["Balance"];

			return objSupplier;
		}
	}
}
