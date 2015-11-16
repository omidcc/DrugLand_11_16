using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Balancika.DAL;

namespace Balancika.BLL.Base
{
	public class UserRoleBase
	{
		protected static Balancika.DAL.UserRoleDal dal = new Balancika.DAL.UserRoleDal();

		public System.Int32 RoleId		{ get ; set; }

		public System.String RoleName		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Int32 UpdateBy		{ get ; set; }

		public System.DateTime UpdateDate		{ get ; set; }

		public System.Int32 CompanyId		{ get ; set; }


		public  Int32 InsertUserRole()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@RoleId", RoleId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@RoleName", RoleName);
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertUserRole(lstItems);
		}

		public  Int32 UpdateUserRole()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@RoleId", RoleId.ToString());
			lstItems.Add("@RoleName", RoleName);
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@UpdateBy", UpdateBy.ToString());
			lstItems.Add("@UpdateDate", UpdateDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyId", CompanyId.ToString());

			return dal.UpdateUserRole(lstItems);
		}

		public  Int32 DeleteUserRoleByRoleId(Int32 RoleId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@RoleId", RoleId);

			return dal.DeleteUserRoleByRoleId(lstItems);
		}

		public List<UserRole> GetAllUserRole(int CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CompanyId", CompanyId);
			DataTable dt = dal.GetAllUserRole(lstItems);
			List<UserRole> UserRoleList = new List<UserRole>();
			foreach (DataRow dr in dt.Rows)
			{
				UserRoleList.Add(GetObject(dr));
			}
			return UserRoleList;
		}

		public UserRole GetUserRoleById(int _RoleId,int _CompanyId)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@RoleId", _RoleId);
			lstItems.Add("@CompanyId", _CompanyId);

			DataTable dt = dal.GetUserRoleByRoleId(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  UserRole GetObject(DataRow dr)
		{

			UserRole objUserRole = new UserRole();
			objUserRole.RoleId = (dr["RoleId"] == DBNull.Value) ? 0 : (Int32)dr["RoleId"];
			objUserRole.RoleName = (dr["RoleName"] == DBNull.Value) ? "" : (String)dr["RoleName"];
			objUserRole.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objUserRole.UpdateBy = (dr["UpdateBy"] == DBNull.Value) ? 0 : (Int32)dr["UpdateBy"];
			objUserRole.UpdateDate = (dr["UpdateDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UpdateDate"];
			objUserRole.CompanyId = (dr["CompanyId"] == DBNull.Value) ? 0 : (Int32)dr["CompanyId"];

			return objUserRole;
		}
	}
}
