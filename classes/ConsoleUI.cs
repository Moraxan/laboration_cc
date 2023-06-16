using laboration_cc.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration_cc.classes
{
	public class ConsoleUI : IUserInterface
	{
		public string GetUserInput(string prompt)
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
