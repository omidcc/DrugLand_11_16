using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class Supplier : Balancika.BLL.Base.SupplierBase
	{
		private static Balancika.DAL.SupplierDal Dal = new Balancika.DAL.SupplierDal();
		public Supplier() : base()
		{
		}
	}
}
