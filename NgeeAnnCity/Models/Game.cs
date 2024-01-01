using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity.Models
{
	internal class Game
	{
		public int Id { get; set; }
		public int Coins { get; set; }
		public int Turn { get; set; }
		public int Score { get; set; }
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
		public Game(int id, int coins, Building[,] grid,int turn,int score)
		{
			Id = id;
			Coins = coins;
			Grid = grid;
			Turn = turn;
			Score = score;
		}
		
		public void Menu()
		{
			bool turnend = true;
			while (turnend)
			{
				Console.WriteLine("Coins: " + Coins + "  Turn: " + Turn + "  Score: " + Score);
				Console.WriteLine("What would you like to do?");
				Console.WriteLine("1. Build Buildings");
				Console.WriteLine("2. Save Game (Does not end turn or exit game)");
				Console.WriteLine("3. End Turn");
				Console.WriteLine("4. Exit to Main Menu (Will not save Game)");
				string input = Console.ReadLine();

				switch (input)
				{
					case "1":
						Console.WriteLine("Displaying Available Buildings");
						buildingselection();
						break;
					case "2":
						Console.WriteLine("Saving Game...");
						turnend = false;
						break;
					case "3":
						Console.WriteLine("Ending Turn...");
						nextTurn();
						turnend = true;
						break;
					case "4":
						Console.WriteLine("Returning to Main Menu...");
						turnend = true;
						break;
					default:
						Console.WriteLine("Invalid input");
						break;
				}
			}
			

		}

		public void nextTurn()
		{
			//increment turn by 1
			Turn += 1;
		}

		public void buildingselection()
		{
			Random random = new Random();

			int numberofbuildings = 5;

			int randombuilding_first = random.Next(numberofbuildings);

			Building first_buildingchosen = GetBuildingSubclass(randombuilding_first); // To get the building info

			int randombuilding_second = random.Next(numberofbuildings);

			while (randombuilding_first == randombuilding_second) // This is so that the two buildings chosen will always be different
			{
				randombuilding_second = random.Next(numberofbuildings);
			}
			Building second_buildingchosen = GetBuildingSubclass(randombuilding_second); // To get the building info
			bool chosen = false;
			while (chosen == false)
			{
				Console.WriteLine("The buildings available for purchase are:");
				Console.WriteLine("1. " + first_buildingchosen.Name + " Cost:" + first_buildingchosen.Cost);
				Console.WriteLine("2. " + second_buildingchosen.Name + " Cost:" + second_buildingchosen.Cost);
				Console.WriteLine("3. End Turn");
				string input = Console.ReadLine();

				switch (input)
				{
					
					case "1":
						Console.WriteLine("You have chosen:" + first_buildingchosen.Name);
						buildingprompt(first_buildingchosen);
						break;
					case "2":
						Console.WriteLine("You have chosen:" + second_buildingchosen.Name);
						buildingprompt(second_buildingchosen);
						break;
					case "3":
						break;
					default:
						Console.WriteLine("Invalid input");
						break;
				}
			}
			

		}

		public void buildingprompt(Building Building)
		{
			Console.WriteLine("Where would you like to place the building?");
			Console.WriteLine("Please enter the X coordinate only");
			int x_axis = x_coordinate();
			Console.WriteLine("Please enter the Y coordinate only");
			int y_axis = Convert.ToInt32(Console.ReadLine());
			while (y_axis > 20 || y_axis < 0) 
			{
				Console.WriteLine("Please enter a valid Coordinate");
				y_axis = Convert.ToInt32(Console.ReadLine());
			}

			buildBuilding(x_axis, y_axis, Building);
		}

		static int x_coordinate()
		{
			Console.Write("Enter a letter (A to T): ");
			char userInput = Console.ReadKey().KeyChar;
			bool loopend = true; //Keep looping till we get a valid answer

			int numericValue = 0; //This is so that this variable is always valid before the loop so that there wouldn't have any errors
			while (loopend)
			{
				if (IsValidLetter(userInput))
				{
					numericValue = ConvertLetterToNumber(char.ToUpper(userInput));
					Console.WriteLine($"\nThe numeric value of {userInput} is {numericValue}.");
					loopend = false;
				}
				else
				{
					Console.WriteLine("\nInvalid input. Please enter a letter (A to T).");
					userInput = Console.ReadKey().KeyChar;

				}
			}
			// Console.WriteLine(numericValue.ToString()); This line of code is to check if the value converted is correct
			return numericValue;
		}
		static bool IsValidLetter(char letter)
		{
			return char.IsLetter(letter) && char.ToUpper(letter) >= 'A' && char.ToUpper(letter) <= 'T';
		}

		static int ConvertLetterToNumber(char letter)
		{
			// Ensure the character is an uppercase letter
			if (char.IsUpper(letter))
			{
				// Calculate the numeric value based on the ASCII value of 'A'
				return letter - 'A' + 1;
			}
			else
			{
				// Handle the case where the character is not an uppercase letter
				throw new ArgumentException("Input must be an uppercase letter.");
			}
		}

		public void letterconverter()
		{
			char startLetter = 'A';
			char endLetter = 'T';

			for (char letter = startLetter; letter <= endLetter; letter++)
			{
				int numericValue = ConvertLetterToNumber(letter);
				Console.WriteLine($"The numeric value of {letter} is {numericValue}.");
			}

			static int ConvertLetterToNumber(char letter)
			{
				// Ensure the character is an uppercase letter
				if (char.IsUpper(letter))
				{
					// Calculate the numeric value based on the ASCII value of 'A'
					return letter - 'A' + 1;
				}
				else
				{
					// Handle the case where the character is not an uppercase letter
					throw new ArgumentException("Input must be an uppercase letter.");
				}
			}
		}

		public bool buildBuilding(int x, int y, Building building)
		{

			//Notes: Check if grid is empty before building
			//implementation
			return false;
		}

		static Building GetBuildingSubclass(int index)
		{
			switch (index)
			{
				case 0:
					return new Residential();
				case 1:
					return new Industry();
				case 2:
					return new Commercial();
				case 3:
					return new Park();
				case 4:
					return new Road();
				// Add more cases if you have additional subclasses
				default:
					throw new ArgumentOutOfRangeException(nameof(index));
			}
		}



		public bool SaveGame()
		{
			//implementation
			return false;
		}
		public void DisplayGrid()
		{
			// Print the Y-axis labels
			Console.Write("   ");//spacing purposes
			for (char letter = 'A'; letter <= 'T'; letter++)
			{
				Console.Write("  " + letter + " ");
			}
			Console.WriteLine("   < x-axis");

			for (int i = 0; i < Grid.GetLength(0); i++)
			{
				// Print the top border of each cell
				Console.Write("   ");//spacing purposes
				for (int j = 0; j < Grid.GetLength(1); j++)
				{
					Console.Write("+---");
				}
				Console.WriteLine("+");

				// Print the cell content and side borders
				Console.Write("   ");//spacing purposes
				for (int j = 0; j < Grid.GetLength(1); j++)
				{
					Console.Write("| ");
					Console.Write(Grid[i, j]?.ToString() ?? " ");
					Console.Write(" ");
				}
				Console.Write("|");
				Console.WriteLine(" " + (i + 1) + " ");//spacing purposes
				for (int j = 0; j < Grid.GetLength(1); j++) ;
			}

			// Print the bottom border of the last row
			Console.Write("   ");//spacing purposes
			for (int j = 0; j < Grid.GetLength(1); j++)
			{
				Console.Write("+---");
			}
			Console.WriteLine("+ ^ y-axis");
		}
	}
}
