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
		public abstract int processPoints(); //operator for the logic to add points 

	}
}
