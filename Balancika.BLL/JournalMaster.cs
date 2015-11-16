using System;
using System.Text;
using System.Data;
using System.Collections;
using BALANCIKA.BLL.Base;

namespace BALANCIKA.BLL
{
	public class JournalMaster : BALANCIKA.BLL.Base.JournalMasterBase
	{
		private static BALANCIKA.DAL.JournalMasterDal Dal = new BALANCIKA.DAL.JournalMasterDal();
		public JournalMaster() : base()
		{
		}
	}
}
