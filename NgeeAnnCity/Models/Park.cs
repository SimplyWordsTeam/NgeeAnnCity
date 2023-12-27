using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity.Models
{
	internal class Park : Building
	{
		public Park()
		{
			Name = "Park";
			NameAbv = "P";
		}

		public override int processPoints()
		{
			//implement the logic to add points for park here
			return 0;
		}
	}
}
