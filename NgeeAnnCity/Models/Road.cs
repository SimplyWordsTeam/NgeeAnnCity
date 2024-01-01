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

		public override int processPoints(Building[,] grid, int x_coord, int y_coord)
		{
			//implement the logic to add points for road here
			int addedPoints = 0;
			if (grid[x_coord, y_coord + 1] is Road )
			{
				addedPoints++;
			}
			return addedPoints;
		}
	}
}
