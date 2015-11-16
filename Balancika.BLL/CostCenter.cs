using System;
using System.Text;
using System.Data;
using System.Collections;
using BALANCIKA.BLL.Base;

namespace BALANCIKA.BLL
{
	public class CostCenter : BALANCIKA.BLL.Base.CostCenterBase
	{
		private static BALANCIKA.DAL.CostCenterDal Dal = new BALANCIKA.DAL.CostCenterDal();
		public CostCenter() : base()
		{
		}
	}
}
