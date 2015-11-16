using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class CustomerBase
	{
		protected static Balancika.DAL.CustomerDal dal = new Balancika.DAL.CustomerDal();

		public System.Int64 CustomerId		{ get ; set; }

		public System.String CustomerName		{ get ; set; }

		public System.Int32 CustomerCategoryId		{ get ; set; }

		public System.Int64 SalesPersonId		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }

		public System.Decimal CreditLimit		{ get ; set; }

		public System.Int64 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }

		public System.Decimal TotalDebit		{ get ; set; }

		public System.Decimal TotalCredit		{ get ; set; }

		public System.Decimal Balance		{ get ; set; }


		public  Int32 InsertCustomer()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CustomerId", CustomerId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CustomerName", CustomerName);
			lstItems.Add("@CustomerCategoryId", CustomerCategoryId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@SalesPersonId", SalesPersonId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CreditLimit", CreditLimit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalDebit", TotalDebit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalCredit", TotalCredit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Balance", Balance.ToString(CultureInfo.InvariantCulture));

			return dal.InsertCustomer(lstItems);
		}

		public  Int32 UpdateCustomer()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CustomerId", CustomerId.ToString());
			lstItems.Add("@CustomerName", CustomerName);
			lstItems.Add("@CustomerCategoryId", CustomerCategoryId.ToString());
			lstItems.Add("@SalesPersonId", SalesPersonId.ToString());
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@CompanyId", CompanyId.ToString());
			lstItems.Add("@CreditLimit", CreditLimit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalDebit", TotalDebit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalCredit", TotalCredit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Balance", Balance.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateCustomer(lstItems);
		}

		public  Int32 DeleteCustomerByCustomerId(Int64 CustomerId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CustomerId", CustomerId);

			return dal.DeleteCustomerByCustomerId(lstItems);
		}

		public List<Customer> GetAllCustomer(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllCustomer(lstItems);
			List<Customer> CustomerList = new List<Customer>();
			foreach (DataRow dr in dt.Rows)
			{
				CustomerList.Add(GetObject(dr));
			}
			return CustomerList;
		}

		public Customer GetCustomerByCustomerId(int _CustomerId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CustomerId", _CustomerId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetCustomerByCustomerId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Customer GetObject(DataRow dr)
		{

			Customer objCustomer = new Customer();
			objCustomer.CustomerId = (dr["CustomerId"] == DBNull.Value) ? 0 : (Int64)dr["CustomerId"];
			objCustomer.CustomerName = (dr["CustomerName"] == DBNull.Value) ? "" : (String)dr["CustomerName"];
			objCustomer.CustomerCategoryId = (dr["CustomerCategoryId"] == DBNull.Value) ? 0 : (Int32)dr["CustomerCategoryId"];
			objCustomer.SalesPersonId = (dr["SalesPersonId"] == DBNull.Value) ? 0 : (Int64)dr["SalesPersonId"];
			objCustomer.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objCustomer.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];
			objCustomer.CreditLimit = (dr["CreditLimit"] == DBNull.Value) ? 0 : (Decimal)dr["CreditLimit"];
			objCustomer.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int64)dr["UpdateBy"];
			objCustomer.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];
			objCustomer.TotalDebit = (dr["TotalDebit"] == DBNull.Value) ? 0 : (Decimal)dr["TotalDebit"];
			objCustomer.TotalCredit = (dr["TotalCredit"] == DBNull.Value) ? 0 : (Decimal)dr["TotalCredit"];
			objCustomer.Balance = (dr["Balance"] == DBNull.Value) ? 0 : (Decimal)dr["Balance"];

			return objCustomer;
		}
	}
}
