using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class ListTable : Balancika.BLL.Base.ListTableBase
	{
		private static Balancika.DAL.ListTableDal Dal = new Balancika.DAL.ListTableDal();
		public ListTable() : base()
		{
		}
	}
}
