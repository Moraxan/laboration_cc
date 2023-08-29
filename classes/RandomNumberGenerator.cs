
public class RandomNumberGenerator
{
    private Random randomNumberGenerator = new Random();

    public string MakeGoal()
    {
        string goal = "";
        
        for (int i = 0; i < 4; i++)
        {
            int randomNumber = randomNumberGenerator.Next(10);
            string randomDigit = randomNumber.ToString();
            goal += randomDigit;
        }
        
        return goal;
    }
}