using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NgeeAnnCity.Models
{
	internal class Residential :Building
	{
		public Residential() : base()
		{
			// Set the name and abbreviation using the properties from the base class
			Name = "Residential";
			NameAbv = "R";
			Cost = 1;
		}
		public override int ProcessPoints(Building[,] grid, int x_coord, int y_coord)
		{
			
			// Implement the logic for processing points in the Commercial subclass
			// You need to provide the actual implementation based on your requirements
			// For now, returning 0 as a placeholder
			int addedPoints = 0;
			bool isBesideIndustry = false;
			bool yp1 = y_coord + 1 < 20;
			bool ym1 = y_coord - 1 >= 0;
			bool xp1 = x_coord + 1 < 20;
			bool xm1 = x_coord - 1 >= 0;

			if (xp1)
			{
				if (grid[y_coord, x_coord + 1] is Industry)
				{
					isBesideIndustry = true;
				}
			}
			if (xm1)
			{
				if (grid[y_coord, x_coord - 1] is Industry)
				{
					isBesideIndustry = true;
				}
			}
			if (yp1)
			{
				if (grid[y_coord + 1, x_coord] is Industry)
				{
					isBesideIndustry = true;
				}
			}
			if (ym1)
			{
				if (grid[y_coord - 1, x_coord] is Industry)
				{
					isBesideIndustry = true;
				}
			}
			if (isBesideIndustry)
			{
				addedPoints = 1;
			}
			else
			{
				//if adjacent to Residential or commercial, add 1 point
				if(xp1)
				{
					if (grid[y_coord, x_coord + 1] is Residential || grid[y_coord, x_coord + 1] is Commercial)
					{
						addedPoints++;
					}
				}
				if (xm1)
				{
					if (grid[y_coord, x_coord - 1] is Residential || grid[y_coord, x_coord - 1] is Commercial)
					{
						addedPoints++;
					}
				}
				if (yp1)
				{
					if (grid[y_coord + 1, x_coord] is Residential || grid[y_coord + 1, x_coord] is Commercial)
					{
						addedPoints++;
					}
				}
				if (ym1)
				{
					if (grid[y_coord - 1, x_coord] is Residential || grid[y_coord - 1, x_coord] is Commercial)
					{
						addedPoints++;
					}
				}

				//if adjacent to Park, add 2 point
				if (xp1)
				{
					if (grid[y_coord, x_coord + 1] is Park)
					{
						addedPoints += 2;
					}
				}

				if (xm1)
				{
					if (grid[y_coord, x_coord - 1] is Park)
					{
						addedPoints += 2;
					}
				}
				if (yp1)
				{
					if (grid[y_coord + 1, x_coord] is Park)
					{
						addedPoints += 2;
					}
				}

				if (ym1)
				{ 
					if (grid[y_coord - 1, x_coord] is Park)
					{
						addedPoints+=2;
					}
				}
			}

			return addedPoints;
		}
		public override int ProcessCoins(Building[,] grid, int x_coord, int y_coord)
		{
			int addedCoins = 0;
			bool yp1 = y_coord + 1 < 20;
			bool ym1 = y_coord - 1 >= 0;
			bool xp1 = x_coord + 1 < 20;
			bool xm1 = x_coord - 1 >= 0;

			//if adjacent to Industry, add 1 coin
			if (xp1)
			{
				if (grid[y_coord, x_coord + 1] is Industry|| grid[y_coord, x_coord + 1] is Commercial)
				{
					addedCoins++;
				}
			}
			if (xm1)
			{
				if (grid[y_coord, x_coord - 1] is Industry || grid[y_coord, x_coord - 1] is Commercial)
				{
					addedCoins++;
				}
			}
			if (yp1)
			{
				if (grid[y_coord + 1, x_coord] is Industry || grid[y_coord+1, x_coord ] is Commercial)
				{
					addedCoins++;
				}
			}
			if (ym1)
			{
				if (grid[y_coord - 1, x_coord] is Industry || grid[y_coord-1, x_coord] is Commercial)
				{
					addedCoins++;
				}
			}


			return addedCoins;
		}
			
	}
}
