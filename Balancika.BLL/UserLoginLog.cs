using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class UserLoginLog : Balancika.BLL.Base.UserLoginLogBase
	{
		private static Balancika.DAL.UserLoginLogDAL Dal = new Balancika.DAL.UserLoginLogDAL();
		public UserLoginLog() : base()
		{
		}


        public UserLoginLog GetUserLastLogin(Int64 _UserId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@UserId", _UserId);

            DataTable dt = dal.GetUserLastLogin(lstItems);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return GetObject(dr);
            }
            else
            {
                return new UserLoginLog();
            }
        }

        public int UpdateStatus(Int64 _Id, string _status)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", _Id);
            lstItems.Add("@Status", _status);
            lstItems.Add("@LogOutTime", DateTime.Now);

            return dal.UpdateStatus(lstItems);
        }
	}
}
