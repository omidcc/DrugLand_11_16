using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class Users : Balancika.BLL.Base.UsersBase
	{
		private static Balancika.DAL.UsersDal Dal = new Balancika.DAL.UsersDal();
		
        public bool IsSuperUser { get; set; }

        public Users()
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Id"></param>
        /// <param name="_UserName"></param>
        /// <param name="isNewEntry"></param>
        /// <returns></returns>
        public int CheckUserNameExistance(int _Id, string _UserName, bool isNewEntry)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@UserName", _UserName);

            if (!isNewEntry) lstItems.Add("@Id", _Id);

            return dal.CheckUserNameExistance(lstItems, isNewEntry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_EmployeeId"></param>
        /// <returns></returns>
        public int CheckUserExistance(int _EmployeeId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@EmployeeId", _EmployeeId);

            return dal.CheckUserExistance(lstItems);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public int GetLastId(int companyId)
        {
            return dal.GetLastId(companyId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userName"></param>
        /// <returns></returns>
        public Users GetUserByUserName(string _userName)
        {
            Hashtable lstItems = new Hashtable { { "@UserName", _userName } };

            DataTable dt = dal.GetUserByUserName(lstItems);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                return GetObject(row);
            }
            else
            {
                return new Users();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Users> GetAllUsersList()
        {
            Hashtable lstItems = new Hashtable();
            //lstItems.Add("@CompanyId", CompanyId);
            DataTable dt = dal.GetAllUsersList(lstItems);
            return (from DataRow dr in dt.Rows select GetObject(dr)).ToList();
        }
        public DataTable GetUserListFromViewList()
        {
            Hashtable lstItems = new Hashtable();

            DataTable dt = dal.GetUserListFromViewList(lstItems);
            return dt;
        }

	}
}
