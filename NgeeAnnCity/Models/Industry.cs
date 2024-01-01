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

		public override int processPoints(Building[,] grid, int x_coord, int y_coord)
		{
			//implement the logic to add points here
			int addedPoints = 0;
			//add 1 point for rthis idustry building
			addedPoints = 1;
			//if adjacent to Residential, add 1 point
			if (grid[x_coord, y_coord + 1] is Residential)
			{
				addedPoints++;
			}
			if (grid[x_coord, y_coord - 1] is Residential)
			{
				addedPoints++;
			}
			if (grid[x_coord + 1, y_coord] is Residential)
			{
				addedPoints++;
			}
			if (grid[x_coord - 1, y_coord] is Residential)
			{
				addedPoints++;
			}



			return 0;
		}
	}
}
