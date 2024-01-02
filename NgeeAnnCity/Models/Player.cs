﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity.Models
{
	internal class Player
	{
		public string Name { get; set; }
		public int Score { get; set; }

		public Player(string name, int score)
		{
			Name = name;
			Score = score;
		}
		
	}
}
