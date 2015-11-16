using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class ChartOfAccount : Balancika.BLL.Base.ChartOfAccountBase
	{
		private static Balancika.DAL.ChartOfAccountDal Dal = new Balancika.DAL.ChartOfAccountDal();
		public ChartOfAccount() : base()
		{
		}
	}
}
