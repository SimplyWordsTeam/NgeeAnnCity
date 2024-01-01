using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity.Models
{
	internal class Road :Building
	{
		public Road()
		{
			Name = "Road";
			NameAbv = "*";
			Cost = 1;
		}

		public override int processPoints()
		{
			//implement the logic to add points for road here
			return 0;
		}
	}
}
