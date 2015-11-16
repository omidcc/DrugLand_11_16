using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class Customer : Balancika.BLL.Base.CustomerBase
	{
		private static Balancika.DAL.CustomerDal Dal = new Balancika.DAL.CustomerDal();
		public Customer() : base()
		{
		}
	}
}
