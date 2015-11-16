using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class ChartOfAccountGroup : Balancika.BLL.Base.ChartOfAccountGroupBase
	{
		private static Balancika.DAL.ChartOfAccountGroupDal Dal = new Balancika.DAL.ChartOfAccountGroupDal();
		public ChartOfAccountGroup() : base()
		{
		}
	}
}
