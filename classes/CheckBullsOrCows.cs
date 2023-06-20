public class CheckBullsOrCows
{
	public string checkBullsOrCows (string goal, string guess)
	{
		int cows = 0, bulls = 0;
		guess += "    ";     // if player entered less than 4 chars
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (goal[i] == guess[j])
				{
					if (i == j)
					{
						bulls++;
					}
					else
					{
						cows++;
					}
				}
			}
		}
		return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
	}
}
