using System.ComponentModel.DataAnnotations;
using System.Globalization;
using NgeeAnnCity;
using NgeeAnnCity.Models;


// See https://aka.ms/new-console-template for more information

bool isRunning = true;
Console.WriteLine("Welcome, To Ngee Ann City");
//display load game save game and exit game options and display high scores


while (isRunning)
{
	Console.WriteLine("Please select an option");
	Console.WriteLine("1. Display High Scores");
	Console.WriteLine("2. New Game");
	Console.WriteLine("3. Load Game");
	Console.WriteLine("4. Exit Game");
	string input = Console.ReadLine();
	
	switch (input)
	{
		case "1":
			Console.WriteLine("Displaying high scores");
			leaderboardList();





			break;
		case "2":
			Console.WriteLine("Starting new game...");
			bool gameplay = true;
			Game game = new Game();
			while (gameplay)
			{
				game.DisplayGrid();
				if (game.Menu(game) == false)//If Menu returns false, it means the user want to return to the main menu
				{
					gameplay = false;
				}
				else // This is so that the process points and coins will only run if the user is still playing the game
				{
					game.ProcessPoints();
				}
				
				game.nextTurn();
			}
			
			break;
		case "3":
            Console.WriteLine("Loading game...");
            Game loadedGame = new Game(); // Create an instance of the Game class
			if (loadedGame.LoadGame())
			{ // Call the LoadGame() method
				Console.WriteLine("Game loaded successfully!");
				bool loadedGameplay = true;
				while (loadedGameplay)
				{
					loadedGame.DisplayGrid();
					if (loadedGame.Menu(loadedGame) == false) //If Menu returns false, it means the user want to return to the main menu
					{
						loadedGameplay = false;
					}
					else // This is so that the process points and coins will only run if the user is still playing the game
					{
						
						loadedGame.ProcessPoints();
					}
					loadedGame.nextTurn();
				}
			}
                break;
		case "4":
			Console.WriteLine("Exiting game ...");
			isRunning = false;
			break;
		default:
			Console.WriteLine("Invalid input");
			break;
	}
}

//=======================================================================
// Print leaderboard

void leaderboardList()
{
	int i = 1;
	List <Game> scorelist = LoadAndSortLeaderboard();
	foreach (Game game in scorelist)
	{
		if (i < 11)
		{
			Console.WriteLine($"{i}. Name: {game.Name} Score: {game.Score}  Coins: {game.Coins}  Turn: {game.Turn}  Score: {game.Score}  Date: {game.Date}");
			i += 1;
		}
		else break;
		
	}
	
}






//=======================================================================
//Load and sort this runs both function at once
List<Game> LoadAndSortLeaderboard()
{
	List<Game> gamelist = LoadLeaderboard();

	// Sort the list in descending order based on Score
	gamelist = gamelist.OrderByDescending(game => game.Score).ToList();

	return gamelist;
}
//=======================================================================
//Load leaderboard
List<Game> LoadLeaderboard()
{
	List<Game> gamelist = new List<Game>();
	try
	{
		string filePath = "game_leaderboard.csv";

		if (File.Exists(filePath))
		{
			using (StreamReader reader = new StreamReader(filePath))
			{

				int lineNumber = 1; // Track the line number for error reporting

				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();

					try
					{
						string[] gameData = line.Split(',');

						string Name = gameData[0];

						// Error-checking for parsing Coins, Turn, and Score
						if (int.TryParse(gameData[2], out int Coins) &&
							int.TryParse(gameData[3], out int Turn) &&
							int.TryParse(gameData[1], out int Score))
						{
							DateTime date;
							// Try multiple date format patterns
							string[] dateFormats = { "M/d/yyyy H:mm:ss tt", "M/d/yyyy h:mm:ss tt", "M/d/yyyy H:mm tt", "M/d/yyyy h:mm tt", "M/d/yyyy H:mm", "M/d/yyyy h:mm" };

							if (DateTime.TryParseExact(gameData[4], dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
							{
								gamelist.Add(new Game(Name, Coins, Turn, Score, date));
							}
							else
							{
								Console.WriteLine($"Error parsing date on line {lineNumber}: {line}");
							}
						}
						else
						{
							Console.WriteLine($"Error parsing Coins, Turn, or Score on line {lineNumber}: {line}");
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Error processing line {lineNumber}: {ex.Message}");
						Console.WriteLine($"Problematic line content: {line}");
					}

					lineNumber++;
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

	return gamelist;
}
//=======================================================================
