namespace laboration_cc.classes
{
	public class Result
	{
		public static string CheckResult(string goal, string guess)
		{
			int cows = 0, bulls = 0;

			guess += new string(' ', Math.Max(0, 4 - guess.Length));    //  Ensures length is 4. There is a risk this doesn't handle inputs longer tha 4 chars well, 
																		// but should atleast make it cut it after 4 chars.

			for (int i = 0; i < 4; i++)
			{
				if (goal[i] == guess[i])
				{
					bulls++;
				}
				else if (goal.Contains(guess[i]))
				{
					cows++;
				}
			}

			return new string('B', bulls) + "," + new string('C', cows);
		}
	}
}