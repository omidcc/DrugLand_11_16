using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class CompanyBase
	{
		protected static Balancika.DAL.CompanyDal dal = new Balancika.DAL.CompanyDal();

		public System.Int32 CompanyId		{ get ; set; }

		public System.String CompanyName		{ get ; set; }

		public System.String Address		{ get ; set; }

		public System.String Phone		{ get ; set; }

		public System.String Email		{ get ; set; }

		public System.String Web		{ get ; set; }

		public System.String LogoPath		{ get ; set; }

		public System.Int32 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }


		public  Int32 InsertCompany()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyName", CompanyName);
			lstItems.Add("@Address", Address);
			lstItems.Add("@Phone", Phone);
			lstItems.Add("@Email", Email);
			lstItems.Add("@Web", Web);
			lstItems.Add("@LogoPath", LogoPath);
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);

			return dal.InsertCompany(lstItems);
		}

		public  Int32 UpdateCompany()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId.ToString());
			lstItems.Add("@CompanyName", CompanyName);
			lstItems.Add("@Address", Address);
			lstItems.Add("@Phone", Phone);
			lstItems.Add("@Email", Email);
			lstItems.Add("@Web", Web);
			lstItems.Add("@LogoPath", LogoPath);
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);

			return dal.UpdateCompany(lstItems);
		}

		public  Int32 DeleteCompanyByCompanyId(Int32 CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);

			return dal.DeleteCompanyByCompanyId(lstItems);
		}

		public List<Company> GetAllCompany(int CompanyName)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyName", CompanyName);
			DataTable dt = dal.GetAllCompany(lstItems);
			List<Company> CompanyList = new List<Company>();
			foreach (DataRow dr in dt.Rows)
			{
				CompanyList.Add(GetObject(dr));
			}
			return CompanyList;
		}

		public Company GetCompanyByCompanyId(int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", _CompanyId);
			

			DataTable dt = dal.GetCompanyByCompanyId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Company GetObject(DataRow dr)
		{

			Company objCompany = new Company();
			objCompany.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];
			objCompany.CompanyName = (dr["CompanyName"] == DBNull.Value) ? "" : (String)dr["CompanyName"];
			objCompany.Address = (dr["Address"] == DBNull.Value) ? "" : (String)dr["Address"];
			objCompany.Phone = (dr["Phone"] == DBNull.Value) ? "" : (String)dr["Phone"];
			objCompany.Email = (dr["Email"] == DBNull.Value) ? "" : (String)dr["Email"];
			objCompany.Web = (dr["Web"] == DBNull.Value) ? "" : (String)dr["Web"];
			objCompany.LogoPath = (dr["LogoPath"] == DBNull.Value) ? "" : (String)dr["LogoPath"];
			objCompany.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int32)dr["UpdateBy"];
			objCompany.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];
			objCompany.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];

			return objCompany;
		}

	   
	}
}
