class MainClass
    {
        public static void Main(string[] args)
        {
            IUserInterface consoleInterface = new ConsoleUI();
            IGameLogic gameLogic = new GameLogic(consoleInterface); 
            IGameController gameController = new GameController(consoleInterface, gameLogic);
            gameController.RunGame();
        }
    }