public class RandomNumberGenerator
{
	public string makeGoal()
	{
		Random randomNumberGenerator = new Random();
		string goal = "";
		for (int i = 0; i < 4; i++)
		{
			int randomNumber = randomNumberGenerator.Next(10);
			string randomDigit = "" + randomNumber;
			{
				randomNumber = randomNumberGenerator.Next(10);
				randomDigit = "" + randomNumber;
			}
			goal = goal + randomDigit;
		}
		return goal;
	}
}
