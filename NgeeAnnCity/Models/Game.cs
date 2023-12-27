using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity.Models
{
	internal class Game
	{
		public int Id { get; set; }
		public int Coins { get; set; }
		public int Turn { get; set; }

		public Building[,] Grid { get; set; }

		public Game()
		{
			Random rnd = new Random();
			int randomNumber=rnd.Next(1000, 9999);
			Coins = 16;
			Grid = new Building[20, 20];
			Id = randomNumber;
			Turn = 1;
		}
		public Game(int id, int coins, Building[,] grid,int turn)
		{
			Id = id;
			Coins = coins;
			Grid = grid;
			Turn = turn;
		}
		

		public void nextTurn()
		{
			//increment turn by 1
			Turn += 1;
		}
		public bool buildBuilding(int x, int y, Building building)
		{
			//Notes: Check if grid is empty before building
			//implementation
			return false;
		}
		public bool SaveGame()
		{
			//implementation
			return false;
		}
	}
}
