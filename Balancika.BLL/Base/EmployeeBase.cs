using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class EmployeeBase
	{
		protected static Balancika.DAL.EmployeeDal dal = new Balancika.DAL.EmployeeDal();

		public System.Int32 EmployeeId		{ get ; set; }

		public System.String EmployeeCode		{ get ; set; }

		public System.String EmployeeName		{ get ; set; }

		public System.String Address		{ get ; set; }

		public System.String DOB		{ get ; set; }

		public System.String JoinDate		{ get ; set; }

		public System.Int32 DepartmentId		{ get ; set; }

		public System.Int32 DesignationId		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Int32 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }


		public  Int32 InsertEmployee()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@EmployeeId", EmployeeId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@EmployeeCode", EmployeeCode);
			lstItems.Add("@EmployeeName", EmployeeName);
			lstItems.Add("@Address", Address);
			lstItems.Add("@DOB", DOB);
			lstItems.Add("@JoinDate", JoinDate);
			lstItems.Add("@DepartmentId", DepartmentId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DesignationId", DesignationId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));

			return dal.InsertEmployee(lstItems);
		}

		public  Int32 UpdateEmployee()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@EmployeeId", EmployeeId.ToString());
			lstItems.Add("@EmployeeCode", EmployeeCode);
			lstItems.Add("@EmployeeName", EmployeeName);
			lstItems.Add("@Address", Address);
			lstItems.Add("@DOB", DOB);
			lstItems.Add("@JoinDate", JoinDate);
			lstItems.Add("@DepartmentId", DepartmentId.ToString());
			lstItems.Add("@DesignationId", DesignationId.ToString());
			lstItems.Add("@CompanyId", CompanyId.ToString());
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateEmployee(lstItems);
		}

		public  Int32 DeleteEmployeeByEmployeeId(Int32 EmployeeId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@EmployeeId", EmployeeId);

			return dal.DeleteEmployeeByEmployeeId(lstItems);
		}

		public List<Employee> GetAllEmployee(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllEmployee(lstItems);
			List<Employee> EmployeeList = new List<Employee>();
			foreach (DataRow dr in dt.Rows)
			{
				EmployeeList.Add(GetObject(dr));
			}
			return EmployeeList;
		}

		public Employee GetEmployeeByEmployeeId(int _EmployeeId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@EmployeeId", _EmployeeId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetEmployeeByEmployeeId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Employee GetObject(DataRow dr)
		{

			Employee objEmployee = new Employee();
			objEmployee.EmployeeId = (dr["EmployeeId"] == DBNull.Value) ? 0 : (Int32)dr["EmployeeId"];
			objEmployee.EmployeeCode = (dr["EmployeeCode"] == DBNull.Value) ? "" : (String)dr["EmployeeCode"];
			objEmployee.EmployeeName = (dr["EmployeeName"] == DBNull.Value) ? "" : (String)dr["EmployeeName"];
			objEmployee.Address = (dr["Address"] == DBNull.Value) ? "" : (String)dr["Address"];
			objEmployee.DOB = (dr["DOB"] == DBNull.Value) ? "" : (String)dr["DOB"].ToString();
			objEmployee.JoinDate = (dr["JoinDate"] == DBNull.Value) ? "" : (String)dr["JoinDate"].ToString();
			objEmployee.DepartmentId = (dr["DepartmentId"] == DBNull.Value) ? 0 : (Int32)dr["DepartmentId"];
			objEmployee.DesignationId = (dr["DesignationId"] == DBNull.Value) ? 0 : (Int32)dr["DesignationId"];
			objEmployee.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];
			objEmployee.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objEmployee.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int32)dr["UpdateBy"];
			objEmployee.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];

			return objEmployee;
		}
	}
}
