using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class AppFunctionality : Balancika.BLL.Base.AppFunctionalityBase
	{
		private static Balancika.DAL.AppFunctionalityDAL Dal = new Balancika.DAL.AppFunctionalityDAL();
		public AppFunctionality() : base()
		{
		}
	}
}
