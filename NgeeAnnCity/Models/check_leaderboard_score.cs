using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NgeeAnnCity.Models.Game;

namespace NgeeAnnCity.Models
{
	internal class check_leaderboard_score
	{
		private List<Player> players;
		private const string filePath = "leaderboard.txt";

		public check_leaderboard_score()
		{
			players = new List<Player>();
		}

		public void AddPlayer(string name, int score)
		{
			players.Add(new Player(name, score));
			SaveLeaderboard();
		}

		public List<Player> GetTopTenPlayers()
		{
			return players.OrderByDescending(player => player.Score).Take(10).ToList();
		}

		public void LoadLeaderboard()
		{
			if (File.Exists(filePath))
			{
				using (StreamReader reader = new StreamReader(filePath))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						string[] data = line.Split(',');
						players.Add(new Player(data[0], int.Parse(data[1])));
					}
				}
			}
		}

		private void SaveLeaderboard()
		{
			using (StreamWriter writer = new StreamWriter(filePath, false))
			{
				foreach (Player player in players)
				{
					writer.WriteLine($"{player.Name},{player.Score}");
				}
			}
		}
	}
}
