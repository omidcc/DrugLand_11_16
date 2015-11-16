using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class BankDal : Balancika.DAL.Base.BankDalBase
	{
		public BankDal() : base()
		{
		}
        //Hashtable lstData
        public int GetMaximumBankId()
        {
            try
            {
                int maxId = GetMaximumID("Bank", "BankId",0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
