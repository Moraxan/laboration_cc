﻿using System;
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

			//Separate UI and logic

			while (playOn)
			{
				
				RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
				string goal = randomNumberGenerator.makeGoal();

				Console.WriteLine("New game:\n");
				//comment out or remove next line to play real games!
				Console.WriteLine("For practice, number is: " + goal + "\n");
				string? guess = Console.ReadLine();
				CheckBullsOrCows checkBullsOrCows = new CheckBullsOrCows();
				int nGuess = 1;
				string bbcc = checkBullsOrCows.checkBullsOrCows(goal, guess);
				Console.WriteLine(bbcc + "\n");
				while (bbcc != "BBBB,")
				{
					nGuess++;
					guess = Console.ReadLine();
					Console.WriteLine(guess + "\n");
					bbcc = checkBullsOrCows.checkBullsOrCows(goal, guess);
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

		
		

		




	
	}
}