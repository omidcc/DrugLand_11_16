using System;
using System.Text;
using System.Data;
using System.Collections;
using BALANCIKA.BLL.Base;

namespace BALANCIKA.BLL
{
	public class JournalDetails : BALANCIKA.BLL.Base.JournalDetailsBase
	{
		private static BALANCIKA.DAL.JournalDetailsDal Dal = new BALANCIKA.DAL.JournalDetailsDal();
		public JournalDetails() : base()
		{
		}
	}
}
