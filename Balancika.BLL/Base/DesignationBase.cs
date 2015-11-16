using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class DesignationBase
	{
		protected static Balancika.DAL.DesignationDal dal = new Balancika.DAL.DesignationDal();

		public System.Int32 DesignationId		{ get ; set; }

		public System.String Designation		{ get ; set; }

		public System.Int32 DepartmentId		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Int32 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }


		public  Int32 InsertDesignation()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@DesignationId", DesignationId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Designation", Designation);
			lstItems.Add("@DepartmentId", DepartmentId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));

			return dal.InsertDesignation(lstItems);
		}

		public  Int32 UpdateDesignation()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@DesignationId", DesignationId.ToString());
			lstItems.Add("@Designation", Designation);
			lstItems.Add("@DepartmentId", DepartmentId.ToString());
			lstItems.Add("@CompanyId", CompanyId.ToString());
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateDesignation(lstItems);
		}

		public  Int32 DeleteDesignationByDesignationId(Int32 DesignationId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@DesignationId", DesignationId);

			return dal.DeleteDesignationByDesignationId(lstItems);
		}

		public List<Designation> GetAllDesignation(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllDesignation(lstItems);
			List<Designation> DesignationList = new List<Designation>();
			foreach (DataRow dr in dt.Rows)
			{
				DesignationList.Add(GetObject(dr));
			}
			return DesignationList;
		}

		public Designation GetDesignationByDesignationId(int _DesignationId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@DesignationId", _DesignationId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetDesignationByDesignationId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Designation GetObject(DataRow dr)
		{

			Designation objDesignation = new Designation();
			objDesignation.DesignationId = (dr["DesignationId"] == DBNull.Value) ? 0 : (Int32)dr["DesignationId"];
			objDesignation.Designation = (dr["Designation"] == DBNull.Value) ? "" : (String)dr["Designation"];
			objDesignation.DepartmentId = (dr["DepartmentId"] == DBNull.Value) ? 0 : (Int32)dr["DepartmentId"];
			objDesignation.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];
			objDesignation.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objDesignation.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int32)dr["UpdateBy"];
			objDesignation.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];

			return objDesignation;
		}
	}
}
