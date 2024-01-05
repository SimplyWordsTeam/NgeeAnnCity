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

		public override int ProcessPoints(Building[,] grid, int x_coord, int y_coord)
		{
			//implement the logic to add points for road here
			int addedPoints = 0;
			bool yp1 = y_coord + 1 < 20;
			bool ym1 = y_coord - 1 >= 0;
			bool xp1 = x_coord + 1 < 20;
			bool xm1 = x_coord - 1 >= 0;
			if (xp1)
			{
				if (grid[y_coord, x_coord+1] is Road)
				{
					addedPoints++;
				}
			}

			if (xm1)
			{
				if (grid[y_coord, x_coord-1] is Road)
				{
					addedPoints++;
				}
			}
			return addedPoints;
		}

		public override int ProcessCoins(Building[,] grid, int x_coord, int y_coord)
		{
			int addedCoins = 0;


			return addedCoins;
		}
	}
}
