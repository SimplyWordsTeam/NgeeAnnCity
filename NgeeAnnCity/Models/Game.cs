using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static NgeeAnnCity.Models.Game;

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
			int randomNumber = rnd.Next(1000, 9999);
			Coins = 16;
			Grid = new Building[20, 20];
			Id = randomNumber;
			Turn = 1;
			Console.WriteLine(Grid[0, 0]?.Name.ToString() ?? "null" + "hi");
		}
		public Game(int id, int coins, Building[,] grid, int turn, int score)
		{
			Id = id;
			Coins = coins;
			Grid = grid;
			Turn = turn;
			Score = score;
		}
		//=======================================================================
		//Menu
		public bool Menu()
		{
			if (Coins == 0)
			{

				Console.WriteLine("========================================");
				Console.WriteLine("The game has ended Thanks for playing!");
                static void Main(string[] args)
                {
                    // Create an instance of the check_leaderboard_score class
                    check_leaderboard_score leaderboard = new check_leaderboard_score();

                    // Prompt the user to enter the player name
                    Console.Write("Enter the player name: ");
                    string playerName = Console.ReadLine();

                    // Prompt the user to enter the player score
                    Console.Write("Enter the player score: ");
                    int playerScore = Convert.ToInt32(Console.ReadLine());

                    // Add the new player to the leaderboard
                    leaderboard.AddPlayer(playerName, playerScore);
                }

                Console.WriteLine("Saving score to leaderboard....");
				Console.WriteLine("Game Saved!");
				Console.WriteLine("========================================");
				Console.WriteLine("Returning to Main Menu");
                
				

                return false;
			}
			else if (Turn <= 400)
			{
				bool turnend = false;
				while (turnend == false)
				{
					Console.WriteLine("Coins: " + Coins + "  Turn: " + Turn + "  Score: " + Score);
					Console.WriteLine("What would you like to do?");
					Console.WriteLine("1. Build Buildings");
					Console.WriteLine("2. Save Game (Does not end turn or exit game)");
					Console.WriteLine("3. Exit to Main Menu (Will not save Game)");
					string input = Console.ReadLine();

					switch (input)
					{
						case "1":
							Console.WriteLine("Displaying Available Buildings");
							buildingselection();
							turnend = true;
							break;
						case "2":
							Console.WriteLine("Saving Game...");
							SaveGame();
							break;
						case "3":
							Console.WriteLine("Returning to Main Menu...");
							return false;
						default:
							Console.WriteLine("Invalid input");
							break;
					}
				}
				return true;
			}
			else
			{
                Console.WriteLine("========================================");
                Console.WriteLine("The game has ended Thanks for playing!");
                static void Main(string[] args)
                {
                    // Create an instance of the check_leaderboard_score class
                    check_leaderboard_score leaderboard = new check_leaderboard_score();

                    // Prompt the user to enter the player name
                    Console.Write("Enter the player name: ");
                    string playerName = Console.ReadLine();

                    // Prompt the user to enter the player score
                    Console.Write("Enter the player score: ");
                    int playerScore = Convert.ToInt32(Console.ReadLine());

                    // Add the new player to the leaderboard
                    leaderboard.AddPlayer(playerName, playerScore);
                }
                Console.WriteLine("Saving score to leaderboard....");
                Console.WriteLine("Game Saved!");
                Console.WriteLine("========================================");
                Console.WriteLine("Returning to Main Menu");
            


                return false;
			}


		}
		//=======================================================================
		// Turn
		public void ProcessAllPoints()
		{
			Console.WriteLine("Points Calculation...");
			int rows = Grid.GetLength(0);
			int columns = Grid.GetLength(1);
			for (int y = 0; y < rows; y++)
			{
				for (int x = 0; x < columns; x++)
				{
					
					if (Grid[y, x] != null)
					{
						char xLetter = ConvertNumberToLetter(x + 1);
						Console.Write("x: " + xLetter + " y: " + (y+1));
						int addedPoints= Grid[y, x].ProcessPoints(Grid, y, x);
						Console.WriteLine(" || Added Points: " + addedPoints);
						Score += Grid[y, x].ProcessPoints(Grid, y, x);
					}
				}
			}
		}
		public void nextTurn()
		{
			//increment turn by 1
			Turn += 1;
		}
		//=======================================================================
		//Building codes
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
			while (chosen == false) //Prompt for a choice after each round
			{
				Console.WriteLine();
				Console.WriteLine("The buildings available for purchase are:");
				Console.WriteLine("1. " + first_buildingchosen.Name + " Cost:" + first_buildingchosen.Cost);
				Console.WriteLine("2. " + second_buildingchosen.Name + " Cost:" + second_buildingchosen.Cost);
				Console.WriteLine("3. End Turn");
				string input = Console.ReadLine();

				try
				{
					switch (input)// different selections choices 
					{
						case "1":
							Console.WriteLine();
							Console.WriteLine("You have chosen:" + first_buildingchosen.Name);
							buildingprompt(first_buildingchosen);
							chosen = true;
							break;
						case "2":
							Console.WriteLine();
							Console.WriteLine("You have chosen:" + second_buildingchosen.Name);
							buildingprompt(second_buildingchosen);
							chosen = true;

							break;
						case "3":
							break;
						default:
							Console.WriteLine("Invalid input");
							break;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Please enter a valid answer");
				}

			}


		}
		//=======================================================================
		//Ask for building location
		public void buildingprompt(Building Building)
		{
			while (true)
			{
				Console.WriteLine("Where would you like to place the building?");
				Console.WriteLine("Please enter the X coordinate");
				int x_axis = x_coordinate();
				Console.WriteLine(); //This is to make the menu smoother/look nicer
				int y_axis = y_cooridnate();
				y_axis -= 1;
				x_axis -= 1; //Since the number starts from 0 instaed of 1, -1 is needed
				if (check_building_connection(y_axis, x_axis) == true)
				{
					buildBuilding(y_axis, x_axis, Building);
					Coins -= 1;
					break;
				}
				else
				{
					Console.WriteLine();
					Console.WriteLine("There are no adjacent Buildings in this area, you are unable to build a building here.");
					Console.WriteLine("Please choose a new area.");
				}
			}
		}
		//=======================================================================
		// y_coordinate

		private int y_cooridnate()
		{
			Console.WriteLine("Please enter the Y coordinate");
			while (true)
			{
				try
				{
					int y_axis = Convert.ToInt32(Console.ReadLine());
					while (y_axis > 20 || y_axis < 0)
					{
						Console.WriteLine("Please enter a valid Coordinate");
						y_axis = Convert.ToInt32(Console.ReadLine());
					}

					return y_axis;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Please enter a valid coordinate");
				}
			}
		}
		//=======================================================================
		//Translate letter to number to be able to plot for Grid[x,y]
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
		//=======================================================================
		//Check if the letter input is within range
		static bool IsValidLetter(char letter)
		{
			return char.IsLetter(letter) && char.ToUpper(letter) >= 'A' && char.ToUpper(letter) <= 'T';
		}
		//=======================================================================
		//Convert letter to number
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
		static char ConvertNumberToLetter(int number)
		{
			// Ensure the number is within the valid range for letters (1 to 26)
			if (number >= 1 && number <= 26)
			{
				// Calculate the ASCII value of 'A' plus the offset
				return (char)('A' + number - 1);
			}
			else
			{
				// Handle the case where the number is outside the valid range
				throw new ArgumentException("Input must be between 1 and 26.");
			}
		}
		//=======================================================================
		// Code to place the building to the chosen area
		public void buildBuilding(int x, int y, Building building)
		{
			Grid[x, y] = building;
		}
		//=======================================================================
		//Used for the random number generator to pick a building to be chosen to be built
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
		
		//=======================================================================
		//Function to display the playing field
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
					Console.Write(Grid[i, j]?.NameAbv.ToString() ?? " ");
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
		//=======================================================================
		//Function to check if there are adjacent buildings so that we can check if the player is able to build the building at the area
		public bool check_building_connection(int x, int y) // This function is to check if the buildings are connect to be built
		{
			if (Grid[x, y] == null)
			{
				if (Turn == 1)
				{
					return true;
				}
				else
				{
					int check_x_add = x + 1;

					int check_x_minus = x - 1;

					int check_y_add = y + 1;

					int check_y_minus = y - 1;

					if ((check_x_add) <= 20 && Grid[check_x_add, y] != null) //This is to check if the x value is bigger than 20 or smaller
					{                                                        //than 0 as if the value we place in the grid is bigger than the grid, and error would occur
						return true;
					}
					else if ((check_x_minus) >= 0 && Grid[check_x_minus, y] != null)
					{
						return true;
					}
					else if ((check_y_add) <= 20 && Grid[x, check_y_add] != null)
					{
						return true;
					}
					else if ((check_y_minus) >= 0 && Grid[x, check_y_minus] != null)
					{
						return true;
					}
					else //If all 4 sides does not have a building return false
					{ return false; }
				}
			}
			else
			{
				Console.WriteLine("There is already a building in the selected section");
				return false;
			}
		}
		//=======================================================================
		//Load Game Function from saved file

        public bool LoadGame()
        {
            try
            {
                string filePath = "game_data.csv";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Skip header line if exists
                        reader.ReadLine();

                        // Read game data (Id, Coins, Turn, Score)
                        string[] gameData = reader.ReadLine()?.Split(',');
                        if (gameData != null && gameData.Length >= 4)
                        {
                            Id = int.Parse(gameData[0]);
                            Coins = int.Parse(gameData[1]);
                            Turn = int.Parse(gameData[2]);
                            Score = int.Parse(gameData[3]);
                        }

                        // Read and populate the Grid data (assuming the format x,y,BuildingName or Empty)
                        while (!reader.EndOfStream)
                        {
                            string[] gridData = reader.ReadLine()?.Split(',');
                            if (gridData != null && gridData.Length >= 3)
                            {
                                int x = int.Parse(gridData[0]);
                                int y = int.Parse(gridData[1]);
                                string buildingName = gridData[2];

                                if (buildingName != "Empty")
                                {
                                    Building building = GetBuildingByName(buildingName);
                                    if (building != null)
                                    {
                                        // Assign the retrieved Building object to the Grid
                                        Grid[x, y] = building;
                                    }
                                    else
                                    {
                                        // Handle the case where the building type is not recognized
                                        // or could not be instantiated
                                        Console.WriteLine($"Unknown building type or error creating building at position ({x}, {y})");
                                    }
                                }
                                // else: Skip assigning to Grid for "Empty" entries
                            }
                        }

                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("No game data file found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading game data: {ex.Message}");
                return false;
            }
        }
		//This code is to aid loadgame()
		// Other methods and members...

		// Example method to retrieve Building object based on its abbreviated name
		private Building GetBuildingByName(string buildingName)
        {
            switch (buildingName)
            {
                case "Park":
                    return new Park();
                case "Residential":
                    return new Residential();
                case "Industry":
                    return new Industry();
                case "Commercial":
                    return new Commercial();
                case "Road":
                    return new Road();
                default:
                    return null; // Handle unrecognized building names as needed
            }
        }
		//=======================================================================
		//Save game Function which creates a file locally to be saved
		public bool SaveGame()
		{
            try
            {
                string filePath = "game_data.csv";

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write header for CSV file
                    writer.WriteLine("Id,Coins,Turn,Score");

                    // Write game data to the CSV file
                    writer.WriteLine($"{Id},{Coins},{Turn},{Score}");

                    // Additional code to save Grid data into CSV
                    // Modify the loop according to your Grid structure
                    for (int i = 0; i < Grid.GetLength(0); i++)
                    {
                        for (int j = 0; j < Grid.GetLength(1); j++)
                        {
                            // Assuming each element in the Grid is a Building object
                            string buildingName = Grid[i, j]?.Name ?? "Empty";
                            writer.WriteLine($"{i},{j},{buildingName}");
                        }
                    }
                }

                Console.WriteLine("Game Saved!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving game data: {ex.Message}");
                return false;
            }
        }
		//=======================================================================
	}
}
