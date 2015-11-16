using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class BankAccounts : Balancika.BLL.Base.BankAccountsBase
	{
		private static Balancika.DAL.BankAccountsDal Dal = new Balancika.DAL.BankAccountsDal();
		public BankAccounts() : base()
		{
		}
	}
}
