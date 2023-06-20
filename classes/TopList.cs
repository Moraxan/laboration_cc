public class TopList
{
    private List<PlayerData> results;

    public TopList()
    {
        results = new List<PlayerData>();
    }

    public void Show()
    {
        StreamReader input = new StreamReader("result.txt");

        //Fix the input class. Needs a try catch. Why is there one input for name and score?
        string line;
        while ((line = input.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            PlayerData pd = new PlayerData(name, guesses);
            int pos = results.IndexOf(pd);
            if (pos < 0)
            {
                results.Add(pd);
            }
            else
            {
                results[pos].Update(guesses);
            }
        }
        results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        Console.WriteLine("Player games average");
        foreach (PlayerData p in results)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()));
        }
        input.Close();
    }
}

