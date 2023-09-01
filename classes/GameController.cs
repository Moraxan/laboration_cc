namespace laboration_cc.classes
{
	public class GameController : IGameController
	{
		private readonly IUserInterface userInterface;
		private readonly IGameLogic gameLogic;

		public GameController(IUserInterface userInterface, IGameLogic gameLogic)
		{
			this.userInterface = userInterface;
			this.gameLogic = gameLogic;
		}

		public void RunGame()
		{
			bool playOn = true;

			while (playOn)
			{
				string name = GetUserName();
				int numberOfGuesses = PlaySingleGame(name);

				WriteResultToFile(name, numberOfGuesses);
				ShowTopPlayers();

				playOn = ShouldContinue();
			}
		}

		private string GetUserName()
		{
			userInterface.DisplayMessage("Enter your user name:\n");
			return userInterface.GetUserInput("");
		}

		private int PlaySingleGame(string playerName)
		{
			GameLogic logic = new(userInterface);
			return logic.PlayGame(playerName);
		}

		private static void WriteResultToFile(string playerName, int numberOfGuesses)
		{
			using StreamWriter output = new("result.txt", append: true);
			output.WriteLine($"{playerName}#&#{numberOfGuesses}");
		}

		private static void ShowTopPlayers()
		{
			HighScore topList = new();
			topList.ShowTopList();
		}

		private bool ShouldContinue()
		{
			string answer = userInterface.GetUserInput($"Continue? (yes/no)\n");
			return answer.ToLower() == "yes";
		}

	}
}