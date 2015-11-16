using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class AppPermission : Balancika.BLL.Base.AppPermissionBase
	{
		private static Balancika.DAL.AppPermissionDAL Dal = new Balancika.DAL.AppPermissionDAL();
		public AppPermission() : base()
		{
		}

        public string FunctionalityName { get; set; }
        public string ModuleName { get; set; }
        public string Url { get; set; }
        public int ParentId { get; set; }
        public int ModuleId { get; set; }
        public int Sequence { get; set; }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<AppPermission> GetViewAllAppPermission(int CompanyId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@CompanyId", CompanyId);
            DataTable dt = dal.GetViewAllAppPermission(lstItems);
            List<AppPermission> AppPermissionList = new List<AppPermission>();
            foreach (DataRow dr in dt.Rows)
            {
                AppPermission appPermission = GetObject(dr);

                appPermission.FunctionalityName = (dr["Functionality"] == DBNull.Value) ? "" : (String)dr["Functionality"];

                AppPermissionList.Add(appPermission);
            }
            return AppPermissionList;
        }

        public List<AppPermission> GetViewAllAppPermission(int companyId, int roleId, int userId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@CompanyId", companyId);
            lstItems.Add("@RoleId", roleId);
            lstItems.Add("@UserId", userId);

            //get all permissions assigned to the user/role
            DataTable dt = dal.GetAppPermissions(lstItems);
            List<AppPermission> AppPermissionList = new List<AppPermission>();
            foreach (DataRow dr in dt.Rows)
            {
                AppPermission appPermission = GetObject(dr);

                appPermission.FunctionalityName = (dr["Functionality"] == DBNull.Value) ? "" : (String)dr["Functionality"];
                appPermission.ModuleName = (dr["Module"] == DBNull.Value) ? "" : (String)dr["Module"];
                appPermission.Url = (dr["Url"] == DBNull.Value) ? "" : (String)dr["Url"];
                appPermission.ParentId = (dr["ParentId"] == DBNull.Value) ? 0 : (int)dr["ParentId"];
                appPermission.ModuleId = (dr["ModuleId"] == DBNull.Value) ? 0 : (int)dr["ModuleId"];
                appPermission.Sequence = (dr["Sequence"] == DBNull.Value) ? 0 : (int)dr["Sequence"];

                AppPermissionList.Add(appPermission);
            }

            return AppPermissionList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_companyId"></param>
        /// <param name="_userId"></param>
        /// <returns></returns>
        public List<AppPermission> GelAppFunctionalityForMenu(int _companyId, int _userId)
        {
            List<AppPermission> AppPermissionList = new List<AppPermission>();

            Hashtable lstItems = new Hashtable();
            lstItems.Add("@CompanyId", _companyId);
            lstItems.Add("@UserId", _userId);

            DataTable dt = dal.GelAppFunctionalityForMenu(lstItems);

            if (dt.Rows.Count == 0)
            {
                int roleId = new UserRoleMapping().GetRoleIdForUser(_userId);
                if (roleId > 0)
                {
                    lstItems = new Hashtable();
                    lstItems.Add("@CompanyId", _companyId);
                    lstItems.Add("@RoleId", roleId);

                    dt = dal.GelAppFunctionalityForMenuByRoleId(lstItems);
                }
            }

            foreach (DataRow dr in dt.Rows)
            {
                AppPermission appPermission = GetObject(dr);

                appPermission.FunctionalityName = (dr["Functionality"] == DBNull.Value) ? "" : (String)dr["Functionality"];
                //appPermission.FunctionalityNameArabic = (dr["FunctionalityArabic"] == DBNull.Value) ? "" : (String)dr["FunctionalityArabic"];
                appPermission.ModuleName = (dr["Module"] == DBNull.Value) ? "" : (String)dr["Module"];
                appPermission.Url = (dr["Url"] == DBNull.Value) ? "" : (String)dr["Url"];
                appPermission.ParentId = (dr["ParentId"] == DBNull.Value) ? 0 : (int)dr["ParentId"];
                appPermission.ModuleId = (dr["ModuleId"] == DBNull.Value) ? 0 : (int)dr["ModuleId"];
                appPermission.Sequence = (dr["Sequence"] == DBNull.Value) ? 0 : (int)dr["Sequence"];

                AppPermissionList.Add(appPermission);
            }
            return AppPermissionList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_FunctionalityId"></param>
        /// <param name="_UserId"></param>
        /// <param name="_RoleId"></param>
        /// <param name="_CompanyId"></param>
        /// <returns></returns>
        public AppPermission GetAppPermissionId(int _FunctionalityId, int _UserId, int _RoleId, int _CompanyId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@FunctionalityId", _FunctionalityId);
            lstItems.Add("@UserId", _UserId);
            lstItems.Add("@RoleId", _RoleId);
            lstItems.Add("@CompanyId", _CompanyId);

            DataTable dt = dal.GetAppPermissionId(lstItems);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return GetObject(dr);
            }
            else
                return new AppPermission();
        }
        /// <summary>
        /// Created by Rabbi for check existing data
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<AppPermission> GetViewAllAppPermissionList(int companyId, int roleId, int userId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@CompanyId", companyId);
            lstItems.Add("@RoleId", roleId);
            lstItems.Add("@UserId", userId);

            //get all permissions assigned to the user/role
            DataTable dt = dal.GetAppPermissionsList(lstItems);
            List<AppPermission> AppPermissionList = new List<AppPermission>();
            foreach (DataRow dr in dt.Rows)
            {
                AppPermission appPermission = GetObject(dr);

                appPermission.FunctionalityName = (dr["Functionality"] == DBNull.Value) ? "" : (String)dr["Functionality"];

                AppPermissionList.Add(appPermission);
            }

            return AppPermissionList;
        }

        public Int32 DeleteAppPermissionByRoleId(Int32 Id)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@RoleId", Id);

            return dal.DeleteAllListRoleInAppPermision(lstItems);
        }
	}
}
