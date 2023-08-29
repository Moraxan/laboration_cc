    public class ConsoleUI : IUserInterface
    {
        public string? GetUserInput(string prompt)
        {
            while (true) // Keep looping until valid input is provided
            {
                Console.WriteLine(prompt);
                try
                {
                    string? input = Console.ReadLine();

                    if (!string.IsNullOrEmpty(input)) // Check for non-null and non-empty input
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("Input cannot be empty. Please try again.");
                    }
                }
                catch (NullReferenceException)
                {
                    // Handle the case where the user input is null (Enter pressed)
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }