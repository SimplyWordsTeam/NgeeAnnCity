﻿using System;
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

		public override int ProcessPoints(Building[,] grid, int x_coord, int y_coord)
		{
			//implement the logic to add points here
			int addedPoints = 0;
			//add 1 point for this idustry building
			addedPoints = 1;
			return addedPoints;
		}
		public override int ProcessCoins(Building[,] grid, int x_coord, int y_coord)
		{
			//implement the logic to add coins here
			int addedCoins = 0;

			bool yp1 = y_coord + 1 < 20;
			bool ym1 = y_coord - 1 >= 0;
			bool xp1 = x_coord + 1 < 20;
			bool xm1 = x_coord - 1 >= 0;
			//if adjacent to Residential, add 1 point

			if (xp1)
			{
				if (grid[y_coord, x_coord + 1] is Residential)
				{
					addedCoins++;
				}
			}

			if (xm1)
			{
				if (grid[y_coord, x_coord - 1] is Residential)
				{
					addedCoins++;
				}
			}

			if (yp1)
			{
				if (grid[y_coord + 1, x_coord] is Residential)
				{
					addedCoins++;
				}
			}

			if (ym1)
			{
				if (grid[y_coord - 1, x_coord] is Residential)
				{
					addedCoins++;
				}
			}

			return addedCoins;
		}
	}
}
