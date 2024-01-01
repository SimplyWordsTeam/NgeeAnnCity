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

			break;
		case "2":
			Console.WriteLine("Starting new game...");
			bool gameplay = true;
			Game game = new Game();
			while (gameplay)
			{
				game.DisplayGrid();
				game.Menu();
			}
			
			break;
		case "3":
			Console.WriteLine("Loading game...");
			isRunning = false;
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

