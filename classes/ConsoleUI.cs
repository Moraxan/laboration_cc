using laboration_cc.interfaces;
namespace MooGame
{

public class ConsoleUI : IUserInterface
{
    public string? GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine();
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}

}