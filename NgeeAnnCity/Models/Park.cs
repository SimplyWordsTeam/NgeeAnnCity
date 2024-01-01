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

		public override int processPoints(Building[,] grid,int x_coord,int y_coord)
		{
			//implement the logic to add points for park here
			int addedPoints = 0;
			if (grid[x_coord, y_coord + 1] is Park)
			{
				addedPoints++;
			}
			if (grid[x_coord, y_coord - 1] is Park)
			{
				addedPoints++;
			}
			if (grid[x_coord + 1, y_coord] is Park)
			{
				addedPoints++;
			}
			if (grid[x_coord - 1, y_coord] is Park)
			{
				addedPoints++;
			}
			
			return addedPoints;
		}
	}
}
