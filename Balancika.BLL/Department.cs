using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class Department : Balancika.BLL.Base.DepartmentBase
	{
		private static Balancika.DAL.DepartmentDal Dal = new Balancika.DAL.DepartmentDal();
		public Department() : base()
		{
		}
	}
}
