using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class Contacts : Balancika.BLL.Base.ContactsBase
	{
		private static Balancika.DAL.ContactsDal Dal = new Balancika.DAL.ContactsDal();
		public Contacts() : base()
		{
		}
	}
}
