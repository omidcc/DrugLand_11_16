using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class Designation : Balancika.BLL.Base.DesignationBase
	{
		private static Balancika.DAL.DesignationDal Dal = new Balancika.DAL.DesignationDal();
		public Designation() : base()
		{
		}
	}
}
