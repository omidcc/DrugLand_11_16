using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class AppPermissionDAL : Balancika.DAL.Base.AppPermissionDALBase
	{
		public AppPermissionDAL() : base()
		{
		}

        public DataTable GetViewAllAppPermission(Hashtable lstData)
        {
            string whereCondition = " where CompanyId = @CompanyId";
            if (lstData.Count > 1)
            {
                whereCondition = whereCondition + " and (RoleId = @RoleID and UserId = @UserId)";
            }

            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewFunctionalit", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public DataTable GelAppFunctionalityForMenu(Hashtable lstData)
        {
            string whereCondition = " where UserId = @UserId and CompanyId = @CompanyId Order by UserId, ModuleId, Sequence";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewAppFunctionalityMenu", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public DataTable GelAppFunctionalityForMenuByRoleId(Hashtable lstData)
        {
            string whereCondition = " where RoleId = @RoleId  AND CompanyId = @CompanyId  Order by RoleId, ModuleId, Sequence";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewAppFunctionalityMenu", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public DataTable GetAppPermissionId(Hashtable lstData)
        {
            string whereCondition = " where AppPermission.FunctionalityId = @FunctionalityId And (AppPermission.UserId=@UserId Or AppPermission.RoleId=@RoleId) And AppPermission.CompanyId=@CompanyId ";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("AppPermission", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAppPermissions(Hashtable lstData)
        {
            //string query = "Select * from vewFunctionalit where CompanyId = @CompanyId and RoleId = @RoleID and UserId = @UserId Union " +
            //    " select Functionality, 0 as Id, @RoleID as roleID, @UserId as userId, @CompanyId as companyId, id as functionalityId, convert(bit,'false') as isInsert, " +
            //    " convert(bit,'false') as isUpdate, convert(bit,'false') as isDelete, convert(bit,'false') as isView, convert(bit,'false') as isApprove,  functionalityArabic, ModuleId from AppFunctionality where " +
            //    " CompanyId=@CompanyId and Id not in(select FunctionalityId from AppPermission where CompanyId=@CompanyId and RoleId=@Ro;leID and UserId=@UserId) " +
            //               " Order by ModuleId, Functionality";

            string query = "Select * from vewFunctionalit where CompanyId = @CompanyId and RoleId = @RoleID and UserId = @UserId " +
                           " Union select Functionality, 0 as Id, @RoleID as roleID, @UserId as userId, @CompanyId as companyId, AppFunctionality.id as functionalityId, convert(bit,'false') as isInsert, " +
                           " convert(bit,'false') as isUpdate, convert(bit,'false') as isDelete, convert(bit,'false') as isView,  " +
                           " convert(bit,'false') as isApprove,  functionalityArabic, ModuleId,Url,ParentId,Sequence,Module from AppFunctionality  " +
                           " Inner join AppModule on AppFunctionality.ModuleId = AppModule.Id where  " +
                           " AppFunctionality.CompanyId=@CompanyId and AppFunctionality.Id not in(select FunctionalityId from AppPermission where CompanyId=@CompanyId and RoleId=@RoleID and UserId=@UserId)  " +
                           " Order by ModuleId, FunctionalityId";

            DataTable dt = GetDataTable(query, lstData);
            return dt;
        }
        public DataTable GetAppPermissionsList(Hashtable lstData)
        {
            string query = "Select * from vewFunctionalit where CompanyId = @CompanyId and RoleId = @RoleID and UserId = @UserId";

            DataTable dt = GetDataTable(query, lstData);
            return dt;
        }

        //Create By Rabbi
        public int DeleteAllListRoleInAppPermision(Hashtable lstData)
        {
            string query = "Delete AppPermission where RoleId=@RoleId ";
            try
            {
                int success = ExecuteNonQuery(query, lstData);
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

	}
}
