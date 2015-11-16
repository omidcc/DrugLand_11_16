using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class AppModule : Balancika.BLL.Base.AppModuleBase
	{
		private static Balancika.DAL.AppModuleDAL Dal = new Balancika.DAL.AppModuleDAL();
		public AppModule() : base()
		{
		}
	}
}
