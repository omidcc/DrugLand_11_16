using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class DepartmentBase
	{
		protected static Balancika.DAL.DepartmentDal dal = new Balancika.DAL.DepartmentDal();

		public System.Int32 DepartmentId		{ get ; set; }

		public System.String DepartmentName		{ get ; set; }

		public System.Int32 ParentDepartmentId		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Int32 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }


		public  Int32 InsertDepartment()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@DepartmentId", DepartmentId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DepartmentName", DepartmentName);
			lstItems.Add("@ParentDepartmentId", ParentDepartmentId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertDepartment(lstItems);
		}

		public  Int32 UpdateDepartment()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@DepartmentId", DepartmentId.ToString());
			lstItems.Add("@DepartmentName", DepartmentName);
			lstItems.Add("@ParentDepartmentId", ParentDepartmentId.ToString());
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString());

			return dal.UpdateDepartment(lstItems);
		}

		public  Int32 DeleteDepartmentByDepartmentId(Int32 DepartmentId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@DepartmentId", DepartmentId);

			return dal.DeleteDepartmentByDepartmentId(lstItems);
		}

		public List<Department> GetAllDepartment(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllDepartment(lstItems);
			List<Department> DepartmentList = new List<Department>();
			foreach (DataRow dr in dt.Rows)
			{
				DepartmentList.Add(GetObject(dr));
			}
			return DepartmentList;
		}

		public Department GetDepartmentByDepartmentId(int _DepartmentId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@DepartmentId", _DepartmentId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetDepartmentByDepartmentId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Department GetObject(DataRow dr)
		{

			Department objDepartment = new Department();
			objDepartment.DepartmentId = (dr["DepartmentId"] == DBNull.Value) ? 0 : (Int32)dr["DepartmentId"];
			objDepartment.DepartmentName = (dr["DepartmentName"] == DBNull.Value) ? "" : (String)dr["DepartmentName"];
			objDepartment.ParentDepartmentId = (dr["ParentDepartmentId"] == DBNull.Value) ? 0 : (Int32)dr["ParentDepartmentId"];
			objDepartment.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objDepartment.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int32)dr["UpdateBy"];
			objDepartment.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];
			objDepartment.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];

			return objDepartment;
		}
	}
}
