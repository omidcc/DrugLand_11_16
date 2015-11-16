using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class Addresses : Balancika.BLL.Base.AddressesBase
	{
		private static Balancika.DAL.AddressesDal Dal = new Balancika.DAL.AddressesDal();
		public Addresses() : base()
		{
		}
	}
}
