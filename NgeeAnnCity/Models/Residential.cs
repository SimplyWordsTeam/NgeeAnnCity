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
		public override int processPoints(Building[,] grid, int x_coord, int y_coord)
		{
			// Implement the logic for processing points in the Commercial subclass
			// You need to provide the actual implementation based on your requirements
			// For now, returning 0 as a placeholder
			int addedPoints = 0;
			bool isBesideIndustry = false;
			

			if (grid[x_coord, y_coord+1] is Industry)
			{
				isBesideIndustry = true;
			}
			else if (grid[x_coord, y_coord - 1] is Industry)
			{
				isBesideIndustry = true;
			}
			else if (grid[x_coord+1, y_coord] is Industry)
			{
				isBesideIndustry = true;
			}
			else if (grid[x_coord-1, y_coord] is Industry)
			{
				isBesideIndustry = true;
			}

			if (isBesideIndustry)
			{
				addedPoints = 1;
			}

			
			if (!isBesideIndustry)
			{
				//if adjacent to Residential, add 1 point
				if(y_coord + 1<20)
				{
					if (grid[x_coord, y_coord + 1] is Residential || grid[x_coord, y_coord + 1] is Commercial)
					{
						addedPoints++;
					}
				}
				if (y_coord - 1 >= 0)
				{
					if (grid[x_coord, y_coord - 1] is Residential || grid[x_coord, y_coord - 1] is Commercial)
					{
						addedPoints++;
					}
				}
				if (x_coord + 1 < 20)
				{
					if (grid[x_coord + 1, y_coord] is Residential || grid[x_coord + 1, y_coord] is Commercial)
					{
						addedPoints++;
					}
				}
				if (x_coord - 1 >= 0)
				{
					if (grid[x_coord - 1, y_coord] is Residential || grid[x_coord - 1, y_coord] is Commercial)
					{
						addedPoints++;
					}
				}


				//if adjacent to Park, add 2 point
				if (grid[x_coord, y_coord + 1] is Park)
				{
					addedPoints+=2;
				}
				if (grid[x_coord, y_coord - 1] is Park)
				{
					addedPoints+=2;
				}
				if (grid[x_coord + 1, y_coord] is Park)
				{
					addedPoints+=2;
				}
				if (grid[x_coord - 1, y_coord] is Park)
				{
					addedPoints+=2;
				}
			}

			return addedPoints;
		}
	}
}
