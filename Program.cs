namespace MooGame
{
    class MainClass
    {
        private readonly IUserInterface _userInterface;

		//Dependency injection of interface
        public MainClass(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public void Run()
        {
            bool playOn = true;
            _userInterface.DisplayMessage("Enter your user name:\n");
            string? name = _userInterface.GetUserInput("");

            while (playOn)
            {
                RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
                string goal = randomNumberGenerator.MakeGoal();

                _userInterface.DisplayMessage("New game:\n");
                _userInterface.DisplayMessage("For practice, number is: " + goal + "\n");

                string? guess = _userInterface.GetUserInput("Enter your guess:\n");
                Result checkResult = new Result();
                int numberOfGuesses = 1;
                string result = checkResult.CheckResult(goal, guess);
                _userInterface.DisplayMessage(result + "\n");

                while (result != "BBBB,")
                    {
                        numberOfGuesses++;
                        guess = _userInterface.GetUserInput("Enter your guess:\n");
                        _userInterface.DisplayMessage(guess + "\n");
                        result = checkResult.CheckResult(goal, guess); // Update the result here
                        _userInterface.DisplayMessage(result + "\n");
                    }

                using (StreamWriter output = new StreamWriter("result.txt", append: true))
                {
                    output.WriteLine(name + "#&#" + numberOfGuesses);
                }

                TopList topList = new TopList();
                topList.Show();

                string answer = _userInterface.GetUserInput("Correct, it took " + numberOfGuesses + " guesses\nContinue? (yes/no)\n");
                if (answer.ToLower() != "yes")
                {
                    playOn = false;
                }
            }
        }

        public static void Main(string[] args)
        {
            IUserInterface consoleInterface = new ConsoleUI();
            MainClass game = new MainClass(consoleInterface);
            game.Run();
        }
    }
}
