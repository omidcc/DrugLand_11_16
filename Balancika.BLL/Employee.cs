using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class Employee : Balancika.BLL.Base.EmployeeBase
	{
		private static Balancika.DAL.EmployeeDal Dal = new Balancika.DAL.EmployeeDal();
		public Employee() : base()
		{
		}
	}
}
