using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
	class MainClass
	{

		public static void Main(string[] args)
		{

			//UI should be an interface

			//Fix naming

			bool playOn = true;
			Console.WriteLine("Enter your user name:\n");
			string? name = Console.ReadLine();

			while (playOn)
			{
				string goal = makeGoal();

				
				Console.WriteLine("New game:\n");
				//comment out or remove next line to play real games!
				Console.WriteLine("For practice, number is: " + goal + "\n");
				string? guess = Console.ReadLine();
				
				int nGuess = 1;
				string bbcc = checkBC(goal, guess);
				Console.WriteLine(bbcc + "\n");
				while (bbcc != "BBBB,")
				{
					nGuess++;
					guess = Console.ReadLine();
					Console.WriteLine(guess + "\n");
					bbcc = checkBC(goal, guess);
					Console.WriteLine(bbcc + "\n");
				}
				StreamWriter output = new StreamWriter("result.txt", append: true);
				output.WriteLine(name + "#&#" + nGuess);
				output.Close();
				TopList topList = new TopList();
				topList.Show();
				Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
				string? answer = Console.ReadLine();
				if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
				{
					playOn = false;
				}
			}
		}
		static string makeGoal()
		{
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(10);
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(10);
					randomDigit = "" + random;
				}
				goal = goal + randomDigit;
			}
			return goal;
		}

		static string checkBC(string goal, string guess)
		{
			int cows = 0, bulls = 0;
			guess += "    ";     // if player entered less than 4 chars
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (goal[i] == guess[j])
					{
						if (i == j)
						{
							bulls++;
						}
						else
						{
							cows++;
						}
					}
				}
			}
			return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
		}
	}




	
}