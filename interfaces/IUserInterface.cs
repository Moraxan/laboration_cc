using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration_cc.interfaces
{
	public interface IUserInterface
	{
		string GetUserInput(string prompt);
		void DisplayMessage(string message);
	}
}
