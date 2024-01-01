using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity.Models
{
	internal class Commercial : Building
	{
		public Commercial() : base()
		{
			// Set the name and abbreviation using the properties from the base class
			Name = "Commercial";
			NameAbv = "C";
			Cost = 1;
		}
		public override int processPoints()
		{
			// Implement the logic for processing points in the Commercial subclass
			// You need to provide the actual implementation based on your requirements
			// For now, returning 0 as a placeholder
			return 0;
		}
	}
}
