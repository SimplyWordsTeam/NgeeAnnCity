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
            static void Main(string[] args, Leaderboard check_leaderboard_score)
            {
                check_leaderboard_score.DisplayLeaderboard();
            }

            break;
		case "2":
			Console.WriteLine("Starting new game...");
			bool gameplay = true;
			Game game = new Game();
			while (gameplay)
			{
				game.DisplayGrid();
				if (game.Menu() == false)//If Menu returns false, it means the user want to return to the main menu
				{
					gameplay = false;
				}
				else // This is so that the process points and coins will only run if the user is still playing the game
				{
					game.ProcessPointsAndCoins();
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
					if (loadedGame.Menu() == false) //If Menu returns false, it means the user want to return to the main menu
					{
						loadedGameplay = false;
					}
					else // This is so that the process points and coins will only run if the user is still playing the game
					{
						loadedGame.ProcessPointsAndCoins();
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

