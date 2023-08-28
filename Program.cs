namespace MooGame
{
    class MainClass
    {
        private readonly IUserInterface userInterface;

		//Dependency injection of interface
        public MainClass(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        public void Run()
        {
            bool playOn = true;
            userInterface.DisplayMessage("Enter your user name:\n");
            string? name = userInterface.GetUserInput("");

            while (playOn)
            {
                RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
                string goal = randomNumberGenerator.MakeGoal();

                userInterface.DisplayMessage("New game:\n");
                userInterface.DisplayMessage("For practice, number is: " + goal + "\n");

                string? guess = userInterface.GetUserInput("Enter your guess:\n");
                Result checkResult = new();
                int numberOfGuesses = 1;
                string result = checkResult.CheckResult(goal, guess);
                userInterface.DisplayMessage(result + "\n");

                while (result != "BBBB,")
                    {
                        numberOfGuesses++;
                        guess = userInterface.GetUserInput("Enter your guess:\n");
                        userInterface.DisplayMessage(guess + "\n");
                        result = checkResult.CheckResult(goal, guess); // Update the result here
                        userInterface.DisplayMessage(result + "\n");
                    }

                using (StreamWriter output = new StreamWriter("result.txt", append: true))
                {
                    output.WriteLine(name + "#&#" + numberOfGuesses);
                }

                TopList topList = new TopList();
                topList.ShowTopList();

                string? answer = userInterface.GetUserInput("Correct, it took " + numberOfGuesses + " guesses\nContinue? (yes/no)\n");
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
