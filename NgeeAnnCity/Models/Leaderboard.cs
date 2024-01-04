using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NgeeAnnCity.Models.Game;
using static System.Formats.Asn1.AsnWriter;

namespace NgeeAnnCity.Models
{
    public class Leaderboard
    {
        private List<Player> scores;
        private const string filePath = "leaderboard.txt";

        public Leaderboard()
        {
            scores = new List<Player>();
        }

        public void AddPlayer(string name, int score)
        {
            Player newPlayer = new Player(name, score);
            scores.Add(newPlayer);
            scores = scores.OrderByDescending(player => player.Score).ToList();
            SaveLeaderboard();
        }

        public void LoadLeaderboard()
        {
            if (scores == null || !scores.Any())
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] data = line.Split(',');
                            scores.Add(new Player(data[0], int.Parse(data[1])));
                        }
                    }
                }
            }
        }

        private void SaveLeaderboard()
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (Player player in scores)
                {
                    writer.WriteLine($"{player.Name},{player.Score}");
                }
            }
        }

      

            // Method to display the leaderboard
            public void DisplayLeaderboard()
            {
                Console.WriteLine("\nLeaderboard:");
                Console.WriteLine("Rank | Name\t| Score");
                Console.WriteLine("-------------------------");

                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine($"{i + 1}\t| {scores[i].Name}\t| {scores[i].Score}");
                }
            }
        }
    }

