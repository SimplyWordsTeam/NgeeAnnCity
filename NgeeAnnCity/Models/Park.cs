using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity.Models
{
	internal class Park : Building
	{
		public Park() :base()
		{
			Name = "Park";
			NameAbv = "O";
			Cost = 1;
		}

		public override int processPoints()
		{
			//implement the logic to add points for park here
			return 0;
		}
	}
}
