using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity.Models
{
	internal abstract class Building
	{
		private string name;
		private string nameAbv;
		private int cost;
		
		//Getter and Setters
		public string Name
		{
			get { return name; }
			protected set { name = value; }
		}
		public string NameAbv
		{
			get { return nameAbv; }
			protected set { nameAbv = value; }
		}
		public int Cost
		{
			get { return cost; }
			protected set { cost = value; }
		}
		public abstract int processPoints(Building[,] grid, int x_coord, int y_coord); //operator for the logic to add points 

	}
}
