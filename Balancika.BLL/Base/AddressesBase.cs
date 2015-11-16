using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class AddressesBase
	{
		protected static Balancika.DAL.AddressesDal dal = new Balancika.DAL.AddressesDal();

		public System.Int64 AddressId		{ get ; set; }

		public System.String SourceType		{ get ; set; }

		public System.Int64 SourceId		{ get ; set; }

		public System.String AddressType		{ get ; set; }

		public System.String AddressLine1		{ get ; set; }

		public System.String AddressLine2		{ get ; set; }

		public System.String City		{ get ; set; }

		public System.String ZipCode		{ get ; set; }

		public System.Int32 CountryId		{ get ; set; }

		public System.String Phone		{ get ; set; }

		public System.String Mobile		{ get ; set; }

		public System.String Email		{ get ; set; }

		public System.String Web		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }


		public  Int32 InsertAddresses()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@AddressId", AddressId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@SourceType", SourceType);
			lstItems.Add("@SourceId", SourceId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@AddressType", AddressType);
			lstItems.Add("@AddressLine1", AddressLine1);
			lstItems.Add("@AddressLine2", AddressLine2);
			lstItems.Add("@City", City);
			lstItems.Add("@ZipCode", ZipCode);
			lstItems.Add("@CountryId", CountryId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Phone", Phone);
			lstItems.Add("@Mobile", Mobile);
			lstItems.Add("@Email", Email);
			lstItems.Add("@Web", Web);
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertAddresses(lstItems);
		}

		public  Int32 UpdateAddresses()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@AddressId", AddressId.ToString());
			lstItems.Add("@SourceType", SourceType);
			lstItems.Add("@SourceId", SourceId.ToString());
			lstItems.Add("@AddressType", AddressType);
			lstItems.Add("@AddressLine1", AddressLine1);
			lstItems.Add("@AddressLine2", AddressLine2);
			lstItems.Add("@City", City);
			lstItems.Add("@ZipCode", ZipCode);
			lstItems.Add("@CountryId", CountryId.ToString());
			lstItems.Add("@Phone", Phone);
			lstItems.Add("@Mobile", Mobile);
			lstItems.Add("@Email", Email);
			lstItems.Add("@Web", Web);
			lstItems.Add("@CompanyId", CompanyId.ToString());

			return dal.UpdateAddresses(lstItems);
		}

		public  Int32 DeleteAddressesByAddressId(Int64 AddressId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@AddressId", AddressId);

			return dal.DeleteAddressesByAddressId(lstItems);
		}

		public List<Addresses> GetAllAddresses(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllAddresses(lstItems);
			List<Addresses> AddressesList = new List<Addresses>();
			foreach (DataRow dr in dt.Rows)
			{
				AddressesList.Add(GetObject(dr));
			}
			return AddressesList;
		}

		public Addresses GetAddressesByAddressId(int _AddressId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@AddressId", _AddressId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetAddressesByAddressId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Addresses GetObject(DataRow dr)
		{

			Addresses objAddresses = new Addresses();
			objAddresses.AddressId = (dr["AddressId"] == DBNull.Value) ? 0 : (Int64)dr["AddressId"];
			objAddresses.SourceType = (dr["SourceType"] == DBNull.Value) ? "" : (String)dr["SourceType"];
			objAddresses.SourceId = (dr["SourceId"] == DBNull.Value) ? 0 : (Int64)dr["SourceId"];
			objAddresses.AddressType = (dr["AddressType"] == DBNull.Value) ? "" : (String)dr["AddressType"];
			objAddresses.AddressLine1 = (dr["AddressLine1"] == DBNull.Value) ? "" : (String)dr["AddressLine1"];
			objAddresses.AddressLine2 = (dr["AddressLine2"] == DBNull.Value) ? "" : (String)dr["AddressLine2"];
			objAddresses.City = (dr["City"] == DBNull.Value) ? "" : (String)dr["City"];
			objAddresses.ZipCode = (dr["ZipCode"] == DBNull.Value) ? "" : (String)dr["ZipCode"];
			objAddresses.CountryId = (dr["CountryId"] == DBNull.Value) ? 0 : (Int32)dr["CountryId"];
			objAddresses.Phone = (dr["Phone"] == DBNull.Value) ? "" : (String)dr["Phone"];
			objAddresses.Mobile = (dr["Mobile"] == DBNull.Value) ? "" : (String)dr["Mobile"];
			objAddresses.Email = (dr["Email"] == DBNull.Value) ? "" : (String)dr["Email"];
			objAddresses.Web = (dr["Web"] == DBNull.Value) ? "" : (String)dr["Web"];
			objAddresses.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];

			return objAddresses;
		}
	}
}
