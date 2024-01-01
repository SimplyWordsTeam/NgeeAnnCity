using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity.Models
{
	internal class Industry : Building
	{

		public Industry()
		{
			Name = "Industry";
			NameAbv = "I";
			Cost = 1;
		}

		public override int processPoints()
		{
			//implement the logic to add points here
			return 0;
		}
	}
}
