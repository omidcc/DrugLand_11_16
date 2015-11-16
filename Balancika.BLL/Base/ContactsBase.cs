using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class ContactsBase
	{
		protected static Balancika.DAL.ContactsDal dal = new Balancika.DAL.ContactsDal();

		public System.Int64 ContactId		{ get ; set; }

		public System.String SourceType		{ get ; set; }

		public System.Int64 SourceId		{ get ; set; }

		public System.String ContactName		{ get ; set; }

		public System.String ContactDesignation		{ get ; set; }

		public System.Boolean IsMainContact		{ get ; set; }

		public System.String Phone		{ get ; set; }

		public System.String Mobile		{ get ; set; }

		public System.String Email		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }


		public  Int32 InsertContacts()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ContactId", ContactId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@SourceType", SourceType);
			lstItems.Add("@SourceId", SourceId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ContactName", ContactName);
			lstItems.Add("@ContactDesignation", ContactDesignation);
			lstItems.Add("@IsMainContact", IsMainContact);
			lstItems.Add("@Phone", Phone);
			lstItems.Add("@Mobile", Mobile);
			lstItems.Add("@Email", Email);
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertContacts(lstItems);
		}

		public  Int32 UpdateContacts()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ContactId", ContactId.ToString());
			lstItems.Add("@SourceType", SourceType);
			lstItems.Add("@SourceId", SourceId.ToString());
			lstItems.Add("@ContactName", ContactName);
			lstItems.Add("@ContactDesignation", ContactDesignation);
			lstItems.Add("@IsMainContact", IsMainContact);
			lstItems.Add("@Phone", Phone);
			lstItems.Add("@Mobile", Mobile);
			lstItems.Add("@Email", Email);
			lstItems.Add("@CompanyId", CompanyId.ToString());

			return dal.UpdateContacts(lstItems);
		}

		public  Int32 DeleteContactsByContactId(Int64 ContactId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ContactId", ContactId);

			return dal.DeleteContactsByContactId(lstItems);
		}

		public List<Contacts> GetAllContacts(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllContacts(lstItems);
			List<Contacts> ContactsList = new List<Contacts>();
			foreach (DataRow dr in dt.Rows)
			{
				ContactsList.Add(GetObject(dr));
			}
			return ContactsList;
		}

		public Contacts GetContactsByContactId(int _ContactId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ContactId", _ContactId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetContactsByContactId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Contacts GetObject(DataRow dr)
		{

			Contacts objContacts = new Contacts();
			objContacts.ContactId = (dr["ContactId"] == DBNull.Value) ? 0 : (Int64)dr["ContactId"];
			objContacts.SourceType = (dr["SourceType"] == DBNull.Value) ? "" : (String)dr["SourceType"];
			objContacts.SourceId = (dr["SourceId"] == DBNull.Value) ? 0 : (Int64)dr["SourceId"];
			objContacts.ContactName = (dr["ContactName"] == DBNull.Value) ? "" : (String)dr["ContactName"];
			objContacts.ContactDesignation = (dr["ContactDesignation"] == DBNull.Value) ? "" : (String)dr["ContactDesignation"];
			objContacts.IsMainContact = (dr["IsMainContact"] == DBNull.Value) ? false : (Boolean)dr["IsMainContact"];
			objContacts.Phone = (dr["Phone"] == DBNull.Value) ? "" : (String)dr["Phone"];
			objContacts.Mobile = (dr["Mobile"] == DBNull.Value) ? "" : (String)dr["Mobile"];
			objContacts.Email = (dr["Email"] == DBNull.Value) ? "" : (String)dr["Email"];
			objContacts.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];

			return objContacts;
		}
	}
}
