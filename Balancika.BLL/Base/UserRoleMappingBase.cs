using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class UserRoleMappingBase
	{
		protected static Balancika.DAL.UserRoleMappingDal dal = new Balancika.DAL.UserRoleMappingDal();

		public System.Int64 MappingId		{ get ; set; }

		public System.Int32 UserId		{ get ; set; }

		public System.Int32 RoleId		{ get ; set; }


		public  Int32 InsertUserRoleMapping()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@MappingId", MappingId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UserId", UserId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@RoleId", RoleId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertUserRoleMapping(lstItems);
		}

		public  Int32 UpdateUserRoleMapping()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@MappingId", MappingId.ToString());
			lstItems.Add("@UserId", UserId.ToString());
			lstItems.Add("@RoleId", RoleId.ToString());

			return dal.UpdateUserRoleMapping(lstItems);
		}

		public  Int32 DeleteUserRoleMappingByMappingId(Int64 MappingId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@MappingId", MappingId);

			return dal.DeleteUserRoleMappingByMappingId(lstItems);
		}

		public List<UserRoleMapping> GetAllUserRoleMapping()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllUserRoleMapping(lstItems);
			List<UserRoleMapping> UserRoleMappingList = new List<UserRoleMapping>();
			foreach (DataRow dr in dt.Rows)
			{
				UserRoleMappingList.Add(GetObject(dr));
			}
			return UserRoleMappingList;
		}

		public UserRoleMapping  GetUserRoleMappingByMappingId(Int64 _MappingId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@MappingId", _MappingId);

			DataTable dt = dal.GetUserRoleMappingByMappingId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  UserRoleMapping GetObject(DataRow dr)
		{

			UserRoleMapping objUserRoleMapping = new UserRoleMapping();
			objUserRoleMapping.MappingId = (dr["MappingId"] == DBNull.Value) ? 0 : (Int64)dr["MappingId"];
			objUserRoleMapping.UserId = (dr["UserId"] == DBNull.Value) ? 0 : (Int32)dr["UserId"];
			objUserRoleMapping.RoleId = (dr["RoleId"] == DBNull.Value) ? 0 : (Int32)dr["RoleId"];

			return objUserRoleMapping;
		}
	}
}
