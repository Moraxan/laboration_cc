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
				int numberOfGuesses = 1;
				string result = checkBullsOrCows.checkBullsOrCows(goal, guess);
				Console.WriteLine(result + "\n");
				while (result != "BBBB,")
				{
					numberOfGuesses++;
					guess = Console.ReadLine();
					Console.WriteLine(guess + "\n");
					result = checkBullsOrCows.checkBullsOrCows(goal, guess);
					Console.WriteLine(result + "\n");
				}
				StreamWriter output = new StreamWriter("result.txt", append: true);
				output.WriteLine(name + "#&#" + numberOfGuesses);
				output.Close();
				TopList topList = new TopList();
				topList.Show();
				Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
				string? answer = Console.ReadLine();
				if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
				{
					playOn = false;
				}
			}
		}

		
		

		




	
	}
}