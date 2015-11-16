using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class UserRole : Balancika.BLL.Base.UserRoleBase
	{
		private static Balancika.DAL.UserRoleDal Dal = new Balancika.DAL.UserRoleDal();
		public UserRole() : base()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Id"></param>
        /// <param name="_Role"></param>
        /// <param name="isNewEntry"></param>
        /// <returns></returns>
        public int CheckRoleExistance(int _Id, string _Role, bool isNewEntry)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Role", _Role);

            if (!isNewEntry) lstItems.Add("@Id", _Id);

            return dal.CheckRoleExistance(lstItems, isNewEntry);
        }
	}
}
