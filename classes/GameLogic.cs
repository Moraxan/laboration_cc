namespace laboration_cc.classes
{
	public class GameLogic : IGameLogic
	{
		private readonly IUserInterface userInterface;

		public GameLogic(IUserInterface userInterface)
		{
			this.userInterface = userInterface;
		}

		public int PlayGame(string playerName)
		{
			RandomNumberGenerator? randomNumberGenerator = new();
			string? goal = randomNumberGenerator.MakeGoal();

			//This could be one line. Doesn't hurt readability to have like this though.    
			userInterface.DisplayMessage("New game:\n");
			userInterface.DisplayMessage("For practice, number is: " + goal + "\n");

			int numberOfGuesses = 0;

			while (true)
			{
				numberOfGuesses++;
				string? guess = userInterface.GetUserInput("Enter your guess:\n");

				string? result = Result.CheckResult(goal, guess);
				userInterface.DisplayMessage(result + "\n");

				if (result == "BBBB,")
				{
					break;
				}
			}

			return numberOfGuesses;
		}
	}
}