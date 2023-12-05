using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_Console_App.Services
{
    internal class UtilService // Just one "Are you sure?" method
    {
        public bool AreYouSure()
        {
            Console.Write("Are you sure? Y/N ");
            string ans = Console.ReadLine()!;
            if (ans.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
