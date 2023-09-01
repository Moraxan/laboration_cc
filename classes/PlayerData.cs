namespace laboration_cc.classes
{


	class PlayerData
	{
		public string Name { get; private set; }
		public int NumberOfGames { get; private set; }
		int totalGuess;


		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			NumberOfGames = 1;
			totalGuess = guesses;
		}

		public void Update(int guesses)
		{
			totalGuess += guesses;
			NumberOfGames++;
		}

		public double Average()
		{
			return (double)totalGuess / NumberOfGames;
		}
	}
}