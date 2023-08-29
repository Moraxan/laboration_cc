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
            GameLogic logic = new GameLogic(userInterface);
            return logic.PlayGame(playerName);
        }

        private void WriteResultToFile(string playerName, int numberOfGuesses)
        {
            using (StreamWriter output = new StreamWriter("result.txt", append: true))
            {
                output.WriteLine($"{playerName}#&#{numberOfGuesses}");
            }
        }

        private void ShowTopPlayers()
        {
            TopList topList = new TopList();
            topList.ShowTopList();
        }

        private bool ShouldContinue()
        {
            string answer = userInterface.GetUserInput($"Continue? (yes/no)\n");
            return answer.ToLower() == "yes";
        }

    }
