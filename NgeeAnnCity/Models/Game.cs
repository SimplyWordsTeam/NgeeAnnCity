using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
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
			Console.WriteLine(Grid[0, 0]?.Name.ToString() ?? "null" + "hi");
		}
		public Game(int id, int coins, Building[,] grid,int turn,int score)
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
			bool turnend = false;
			while (turnend == false)
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
						turnend = true;
						break;
					case "2":
						Console.WriteLine("Saving Game...");
						//implementation

						Console.WriteLine("Save Game function is not implemented yet");
						break;
					case "3":
						Console.WriteLine("Ending Turn...");
						nextTurn();
						turnend = true;
						break;
					case "4":
						Console.WriteLine("Returning to Main Menu...");
						return false;
					default:
						Console.WriteLine("Invalid input");
						break;
				}

			}
			return true; 

		}
		//=======================================================================
		// Turn
		public void processAllPoints()
		{
			Console.WriteLine("processAllPoints Running");
			int rows = Grid.GetLength(0);
			int columns = Grid.GetLength(1);
			for (int x = 0; x < rows; x++)
			{
				for (int y = 0; y < columns; y++)
				{

					if (Grid[x, y] != null)
					{
						Console.WriteLine("x: " + x + " y: " + y);
						int addedPoints= Grid[x, y].processPoints(Grid, x, y);
						Console.WriteLine("Added Points: " + addedPoints);
						Score +=Grid[x, y].processPoints(Grid, x, y);
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
		//=======================================================================
		// Code to place the building to the chosen area
		public void buildBuilding(int x, int y, Building building)
		{
			Grid[x,y] = building;
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
		//Save game Function (To be made, delete the bracket words after done)
		public bool SaveGame()
		{
			//implementation
			return false;
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
					{														 //than 0 as if the value we place in the grid is bigger than the grid, and error would occur
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
	}
}
