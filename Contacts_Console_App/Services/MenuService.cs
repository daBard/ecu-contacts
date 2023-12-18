namespace Contacts_Console_App.Services;

internal class MenuService(ContactService _contactService, UtilService _utilService)
{
    //Main menu
    public void DisplayMenu()
    {
        DisplayTitle();
        _contactService.DisplayContactList();
        Console.WriteLine("");
        DisplayOptions();
    }

    //Display Title
    internal void DisplayTitle(string _title = "CONTACT LIST APP")
    {
        Console.Clear();
        Console.WriteLine($"##### {_title}  #####");
    }

    //Display options
    internal void DisplayOptions()
    {
        Console.WriteLine("### OPTIONS MENU ###");
        Console.WriteLine($"{"1.",-3} Add contact");
        Console.WriteLine($"{"2.",-3} View contact info");
        Console.WriteLine($"{"3.",-3} Save contact list to file");
        Console.WriteLine($"{"0.",-3} Exit Application");
        Console.WriteLine("");

        string option = Console.ReadKey(true).KeyChar.ToString();

        switch (option)
        {
            case "1":
                DisplayTitle("ADD NEW CONTACT");
                _contactService.AddContact();
                DisplayMenu();
                break;

            case "2":
                DisplayTitle("VIEW CONTACT INFO");
                _contactService.DisplayContactList();
                Console.Write("Which contact info do you wish to see: ");
                string key = Console.ReadLine()!;
                if (int.TryParse(key, out _))
                {
                    DisplayTitle("VIEW CONTACT INFO");
                    _contactService.DisplayContactInfo(int.Parse(key));
                }
                else
                {
                    Console.WriteLine("Not a valid option.");
                    Console.ReadKey();
                }
                break;

            case "3":
                _contactService.Save();
                Console.WriteLine("Contact file saved...");
                Console.ReadKey();
                break;
            case "0":
                Console.WriteLine("Exit app");
                if (_utilService.AreYouSure())
                    Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Not a valid option.");
                Console.ReadKey();
                break;
        }
        DisplayMenu();
    }
}
