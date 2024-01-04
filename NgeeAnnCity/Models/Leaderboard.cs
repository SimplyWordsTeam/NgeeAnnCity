using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NgeeAnnCity.Models.Game;
using static System.Formats.Asn1.AsnWriter;

namespace NgeeAnnCity.Models
{
	internal class Leaderboard
	{
		private List<Game> Top10Games { get; set; }

		public Leaderboard ()
		{
			Top10Games=new List<Game> ();
		}

		public void saveleaderboard()
		{
			string filePath = "game_leaderboard.csv";
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				// Write header for CSV file
				writer.WriteLine("Name,Score,Coins,Turn,Date,id");

				foreach (Game game in Top10Games)
				{
					writer.WriteLine($"{game.Name},{game.Score},{game.Coins},{game.Turn},{game.Date}");
				}
				// Write game data to the CSV file
				

			}

		}
		public void loadleaderboard()
		{
			Top10Games = new List<Game>();
			try
			{
				string filePath = "game_leaderboard.csv";

				if (File.Exists(filePath))
				{
					using (StreamReader reader = new StreamReader(filePath))
					{
						string line;
						line = reader.ReadLine();

						while ((line = reader.ReadLine()) != null)
						{
							reader.ReadLine();
							string[] gameData = reader.ReadLine()?.Split(',');
							string Name = gameData[0];
							int Coins = int.Parse(gameData[1]);
							int Turn = int.Parse(gameData[2]);
							int Score = int.Parse(gameData[3]);
							DateTime date = DateTime.Parse(gameData[4]);
							Top10Games.Add(new Game(Name,Coins,Turn,Score,date));
						}
					}
				}
				else
				{
					Console.WriteLine("No game data file found.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error loading game data: {ex.Message}");
			}
		}
		public void leaderboardranking()
		{
			int rank = 0;
			Top10Games = Top10Games.OrderByDescending(game => game.Score).ToList();
			foreach (Game game in Top10Games)
			{
				rank += 1;
				Console.WriteLine(rank + ". Name:" +  game.Name + "  Score:" + game.Score +"  Coins:"+ game.Coins + "  Turn:" + game.Turn + "  Score:" + game.Score + "  Date" + game.Date);
			}

		}

		public void leaderboard_replacementcheck(Game game)
		{
			foreach(Game leaderboard_game in Top10Games)
			{
				if (leaderboard_game.Score >= game.Score)
				{
					Top10Games.RemoveAt(Top10Games.Count - 1);
					game.Date = DateTime.Now;
					Top10Games.Add(game);

				}
			}
			saveleaderboard();
		}
	}
}

