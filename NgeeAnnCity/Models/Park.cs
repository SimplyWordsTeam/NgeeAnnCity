using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity.Models
{
	internal class Park : Building
	{
		public Park() : base()
		{
			Name = "Park";
			NameAbv = "O";
			Cost = 1;
		}

		public override int ProcessPoints(Building[,] grid, int x_coord, int y_coord)
		{
			bool yp1 = y_coord + 1 < 20;
			bool ym1 = y_coord - 1 >= 0;
			bool xp1 = x_coord + 1 < 20;
			bool xm1 = x_coord - 1 >= 0;
			//implement the logic to add points for park here
			int addedPoints = 0;
			if (xp1)
			{
				if (grid[y_coord, x_coord + 1] is Park)
				{
					addedPoints++;
				}
			}

			if (xm1)
			{
				if (grid[y_coord, x_coord - 1] is Park)
				{
					addedPoints++;
				}
			}
			if (yp1)
			{
				if (grid[y_coord + 1, x_coord] is Park)
				{
					addedPoints++;
				}
			}

			if (ym1)
			{
				if (grid[y_coord - 1, x_coord] is Park)
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
