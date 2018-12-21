using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV3
{
    public class Menu
    {
        public string MainMenu(Role role)
        {
            
            switch (role)
            {
                case Role.Admin:
                    return ShowMenuAdmin();
                case Role.ViewUser:
                    return ShowMenuViewUser();
                case Role.EditUser:
                    return ShowMenuEditUser();
                case Role.DeleteUser:
                    return ShowMenuDeleteUser();

            }
            return null;
        }

        static string ShowMenuAdmin()
        {
            Console.WriteLine("1. Create new user");
            Console.WriteLine("2. View a user");
            Console.WriteLine("3. Send a message");
            Console.WriteLine("4. View messages send");
            Console.WriteLine("5. View messages received");
            Console.WriteLine("6. Update a username");
            Console.WriteLine("7. Update a password");
            Console.WriteLine("8. Show all users");
            Console.WriteLine("0. Exit");
            string input;
            do
            {
                input = Console.ReadLine();

            } while (input !="1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input !="7" && input !="8" && input != "0");
            return input;
        }

        static string ShowMenuViewUser()
        {
            Console.WriteLine("1. View all messages send");
            Console.WriteLine("2. View messages from other user");
            Console.WriteLine("3. View messages received");
            Console.WriteLine("4. Send a message");
            Console.WriteLine("0. Exit");
            string input;
            do
            {
                input = Console.ReadLine();

            } while (input != "1" && input != "2" && input != "3" && input != "4" && input !="0");
            return input;
        }

        static string ShowMenuEditUser()
        {
            Console.WriteLine("1. View all messages send");
            Console.WriteLine("2. View messages from other user");
            Console.WriteLine("3. View messages received");
            Console.WriteLine("4. Send a message");
            Console.WriteLine("5. Edit a message");
            Console.WriteLine("0. Exit");
            string input;
            do
            {
                input = Console.ReadLine();

            } while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "0");
            return input;

        }

        static string ShowMenuDeleteUser()
        {
            Console.WriteLine("1. View all messages send");
            Console.WriteLine("2. View messages from other user");
            Console.WriteLine("3. View messages received");
            Console.WriteLine("4. Send a message");
            Console.WriteLine("5. Edit a message");
            Console.WriteLine("6. Delete message");
            Console.WriteLine("0. Exit");
            string input;
            do
            {
                input = Console.ReadLine();

            } while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "0");
            return input;

        }
    }
}
