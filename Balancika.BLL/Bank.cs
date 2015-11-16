using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class Bank : Balancika.BLL.Base.BankBase
	{
		private static Balancika.DAL.BankDal Dal = new Balancika.DAL.BankDal();
		public Bank() : base()
		{
		}

	    public int GetMaxBankId(int companyID)
	    {
	        return dal.GetMaximumBankId();
	    }
	}
}
