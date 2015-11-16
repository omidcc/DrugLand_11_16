using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class Company : Balancika.BLL.Base.CompanyBase
	{
		private static Balancika.DAL.CompanyDal Dal = new Balancika.DAL.CompanyDal();
		public Company() : base()
		{
		}
	}
}
