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
		public override int processPoints(Building[,] grid, int x_coord, int y_coord)
		{
			// Implement the logic for processing points in the Commercial subclass
			// You need to provide the actual implementation based on your requirements
			// For now, returning 0 as a placeholder
			int addedPoints = 0;
			if (grid[x_coord, y_coord + 1] is Residential|| grid[x_coord, y_coord + 1] is Commercial)
			{
				addedPoints++;
			}
			if (grid[x_coord, y_coord - 1] is Residential || grid[x_coord, y_coord - 1] is Commercial)
			{
				addedPoints++;
			}
			if (grid[x_coord + 1, y_coord] is Residential || grid[x_coord + 1, y_coord] is Commercial)
			{
				addedPoints++;
			}

			if (grid[x_coord - 1, y_coord] is Residential|| grid[x_coord - 1, y_coord] is Commercial)
			{
				addedPoints++;
			}


			return addedPoints;
		}
	}
}
