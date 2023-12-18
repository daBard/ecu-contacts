using Contacts_Console_App.Repositories;

using Contacts_Console_App.Models;
using System.Diagnostics;

namespace Contacts_Console_App.Services
{
    internal class ContactService(ContactRepository _contactRepository)
    {
        //Add to repo
        public void AddContact()
        {
            Contact contact = new();

            Console.Write("First name: ");
            string firstName = Console.ReadLine()!;
            contact.FirstName = firstName;

            Console.Write("Last name: ");
            string lastName = Console.ReadLine()!;
            contact.LastName = lastName;

            Console.Write("Phone number: ");
            string phone = Console.ReadLine()!;
            contact.PhoneNumber = phone;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            contact.Email = email.ToLower();

            Console.Write("Street name: ");
            string street = Console.ReadLine()!;
            contact.StreetName = street;

            Console.Write("House number: ");
            string houseNr = Console.ReadLine()!;
            contact.HouseNumber = houseNr;

            Console.Write("Post code: ");
            string postCode = Console.ReadLine()!;
            contact.Postcode = postCode;

            Console.Write("City: ");
            string city = Console.ReadLine()!;
            contact.City = city;

            _contactRepository.AddContact(contact);
        }

        //Delete from repo
        private void DeleteContact(Contact _contact)
        {
            Console.Write("Confirm deletion by entering contact email: ");
            string confirm = Console.ReadLine()!;
            if (confirm == _contact.Email)
            {
                _contactRepository.DeleteContact(_contact.Id);
            }
            else
            {
                Console.WriteLine("Not a valid confirmation!");
                Console.ReadKey();
            }
        }

        //Display contact list
        public void DisplayContactList()
        {
            int i = 1;
            _contactRepository.GetAllContacts().ForEach(contact =>
            {
                Console.WriteLine($"{i}{".",-3} {contact.FirstName} {contact.LastName}");
                i++;
            });
        }


        //Display contact info and delete confirm
        public void DisplayContactInfo(int target)
        {
            int listCount = _contactRepository.GetAllContacts().Count();

            try
            {
                if (target > 0 && target <= listCount) {
                    int i = target - 1;
                    Contact contact = _contactRepository.GetContact(i);

                    Console.WriteLine("Namn:");
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");

                    Console.WriteLine("Address:");
                    Console.WriteLine($"{contact.StreetName} {contact.HouseNumber}");
                    Console.WriteLine($"{contact.Postcode} {contact.City}");

                    Console.WriteLine("Phone number:");
                    Console.WriteLine($"{contact.PhoneNumber}");

                    Console.WriteLine("Email address:");
                    Console.WriteLine($"{contact.Email}");

                    Console.WriteLine("");
                    Console.WriteLine("Press D to delete the contact");
                    Console.WriteLine("or press any other key to return...");
                    string delOption = Console.ReadKey(true).KeyChar.ToString();
                    if (delOption.ToLower() == "d")
                    {
                        DeleteContact(contact);
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }  
        }

        //Pass through save command to repo
        public void Save()
        {
            Console.Write("Saving to file... ");
            bool res = _contactRepository.ListToJsonSave();
            if (res) { Console.Write("Saved!"); }
            else { Console.Write("Failed!"); }
        }
    }
}
