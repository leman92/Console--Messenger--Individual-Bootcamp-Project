using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV3
{
    public class MainMenu
    {
        public void MainMethod()
        {
            Console.WriteLine("Welcome to Messenger ");

            Console.WriteLine("Login Screen");

            User user;
            do
            {
                Console.WriteLine("Enter your username");
                string username = Console.ReadLine();
                Console.WriteLine("Enter your password");
                string password = Console.ReadLine();
                Manager login = new Manager();
                user = login.Login(username, password);
            }
            while (user == null);

            Console.Clear();
            Menu menu = new Menu();
            while(true)
            {
                Console.Clear();
                string roleinput = menu.MainMenu(user.Role);
                int input = int.Parse(roleinput);
                Role role = user.Role;

                if (role == Role.Admin && input == 1)
                {
                    Console.WriteLine("Hello Admin,you choose to create a new user");
                    bool check;
                    do
                    {
                        string username;
                        string password;
                        do
                        {
                            Console.WriteLine("Enter new username");
                            username = Console.ReadLine();

                        } while (string.IsNullOrEmpty(username));
                        Manager manager = new Manager();

                        User usercheck = manager.UserCheck(username);

                        if (usercheck != null)
                        {
                            Console.WriteLine("Username already exists");
                            Console.WriteLine("Please try again");
                            check = true;
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Enter new password");
                                password = Console.ReadLine();

                            } while (string.IsNullOrEmpty(password));
                            string role1;
                            do
                            {
                                Console.WriteLine("Assign a role to the user(1.ViewUser 2.EditUser 3.DeleteUser)");
                                role1 = Console.ReadLine();

                            } while (role1 != "1" && role1 != "2" && role1 != "3");

                            int role2 = int.Parse(role1);
                            Role role3 = manager.RoleChoose(role2);
                            manager.CreateUser(username, password, role3);
                            check = false;
                        }
                    } while (check);

                }
                else if (role == Role.Admin && input == 2)
                {
                    Console.WriteLine("Hello Admin,enter which user's data you want to view");
                    string username;
                    do
                    {
                        username = Console.ReadLine();

                    } while (string.IsNullOrEmpty(username));

                    Manager manager = new Manager();
                    User viewuser = manager.UserCheck(username);

                    if (viewuser == null)
                    {
                        Console.WriteLine("User doesnt exist");
                        Console.WriteLine("Try again");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Username: {viewuser.Username} Password:{viewuser.Password} UserRole:{viewuser.Role} UserID:{viewuser.Id}");
                        Console.ReadKey();
                    }
                }
                else if (role == Role.Admin && input == 3)
                {
                    Console.WriteLine("Write your message");
                    string message;
                    do
                    {
                        message = Console.ReadLine();
                    }
                    while (string.IsNullOrEmpty(message));
                    Console.WriteLine("Where you want to send it?");
                    string receiver;
                    do
                    {
                        receiver = Console.ReadLine();

                    } while (string.IsNullOrEmpty(receiver));

                    Manager manager = new Manager();
                    User userreceiver = manager.UserCheck(receiver);

                    if (userreceiver != null)
                    {
                        manager.SendMessage(message, user.Id, userreceiver.Id);
                        Console.WriteLine("message send");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("User doesnt exist");
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                    }

                }
                else if (role == Role.Admin && input == 4)
                {
                    Console.WriteLine("Thats all the messages you have send");
                    Manager manager = new Manager();
                    List<Message> messages = manager.MessagesSend(user.Id);

                    foreach (var item in messages)
                    {
                        Console.WriteLine(item.MessageData);
                    }
                    Console.ReadKey();

                }
                else if (role == Role.Admin && input == 5)
                {
                    Console.WriteLine($"Hello {user.Username},thats all the messages you have received");
                    Manager manager = new Manager();
                    List<Message> messages = manager.MessagesReceived(user.Id);

                    foreach (var item in messages)
                    {
                        Console.WriteLine(item.MessageData);
                    }
                    Console.ReadKey();
                }

                else if (role == Role.Admin && input == 6)
                {
                    Console.WriteLine($"Hello {user.Username},write the user's name you want to update");
                    Manager manager = new Manager();
                    Console.WriteLine("Give a username");
                    string username;
                    do
                    {
                        username = Console.ReadLine();

                    } while (string.IsNullOrEmpty(username));

                    User updater = manager.UserCheck(username);
                    Console.Clear();
                    if (updater == null)
                    {
                        Console.WriteLine("Username doesnt exists");
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Give new username");
                        string newusername;
                        do
                        {
                            newusername = Console.ReadLine();

                        } while (string.IsNullOrEmpty(newusername));
                        User samename = manager.UserCheck(newusername);
                        if (samename == null)
                        {
                            manager.UpdateUsername(updater.Id, newusername);
                        }
                        else
                        {
                            Console.WriteLine("Username already in use");
                        }
                        Console.ReadKey();
                    }
                }

                else if (role == Role.Admin && input == 7)
                {
                    Console.WriteLine($"Hello {user.Username},write the user's name you want to update the password");
                    Manager manager = new Manager();
                    Console.WriteLine("Give a username");
                    string username;
                    do
                    {
                        username = Console.ReadLine();

                    } while (string.IsNullOrEmpty(username));

                    User updater = manager.UserCheck(username);
                    Console.Clear();
                    if (updater == null)
                    {
                        Console.WriteLine("Username doesnt exist");
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Give new password");
                        string newpsw;
                        do
                        {
                            newpsw = Console.ReadLine();

                        } while (string.IsNullOrEmpty(newpsw));

                        manager.UpdatePassword(updater.Id, newpsw);
                    }
                }
                else if (role == Role.Admin && input == 8)
                {

                    Manager showallusers = new Manager();
                    List<User> users = showallusers.GetAllUsers();
                    foreach (var item in users)
                    {
                        Console.WriteLine(item.Username);
                    }

                    Console.ReadKey();
                }
                else if(role == Role.Admin && input ==0)
                {
                    Environment.Exit(0);
                }

                //VIEWUSER
                if (role == Role.ViewUser && input == 1)
                {
                    Console.WriteLine($"Hello {user.Username},thats all the messages you have send");
                    Manager manager = new Manager();
                    List<Message> messages = manager.MessagesSend(user.Id);

                    foreach (var item in messages)
                    {
                        Console.WriteLine(item.MessageData);
                    }
                    Console.ReadKey();
                }
                else if (role == Role.ViewUser && input == 2)
                {
                    Console.WriteLine($"Hello {user.Username},write the username to view the message you have send");
                    Manager manager = new Manager();
                    Console.WriteLine("Give a username");
                    string username;
                    do
                    {
                        username = Console.ReadLine();

                    } while (string.IsNullOrEmpty(username));

                    User receiver = manager.UserCheck(username);
                    Console.Clear();
                    if (receiver == null)
                    {
                        Console.WriteLine("Username doesnt exist");
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                    }
                    else
                    {
                        List<Message> messages = manager.MessagesSendByUserIdToReceiverId(user.Id, receiver.Id);

                        foreach (var item in messages)
                        {
                            Console.WriteLine($"You send {item.MessageData} to {receiver.Username}");
                        }
                    }
                    Console.ReadKey();
                }

                else if (role == Role.ViewUser && input == 3)
                {
                    Console.WriteLine($"Hello {user.Username},thats all the messages you have received");
                    Manager manager = new Manager();
                    List<Message> messages = manager.MessagesReceived(user.Id);

                    foreach (var item in messages)
                    {
                        Console.WriteLine(item.MessageData);
                    }
                    Console.ReadKey();
                }

                else if (role == Role.ViewUser && input == 4)
                {
                    Console.WriteLine("Write your message");
                    string message;
                    do
                    {
                        message = Console.ReadLine();
                    }
                    while (string.IsNullOrEmpty(message));
                    Console.WriteLine("Where you want to send it?");
                    string receiver;
                    do
                    {
                        receiver = Console.ReadLine();

                    } while (string.IsNullOrEmpty(receiver));

                    Manager manager = new Manager();
                    User userreceiver = manager.UserCheck(receiver);
                    Console.Clear();
                    if (userreceiver != null)
                    {
                        manager.SendMessage(message, user.Id, userreceiver.Id);
                        Console.WriteLine("message send");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("User doesnt exist");
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                    }
                }

                else if (role == Role.ViewUser && input == 0)
                {
                    Environment.Exit(0);
                }

                //EDITUSER
                if (role == Role.EditUser && input == 1)
                {
                    Console.WriteLine($"Hello {user.Username},thats all the messages you have send");
                    Manager manager = new Manager();
                    List<Message> messages = manager.MessagesSend(user.Id);

                    foreach (var item in messages)
                    {
                        Console.WriteLine(item.MessageData);
                    }
                    Console.ReadKey();
                }
                else if (role == Role.EditUser && input == 2)
                {
                    Console.WriteLine($"Hello {user.Username},write the username to view the message you have send");
                    Manager manager = new Manager();
                    Console.WriteLine("Give a username");
                    string username;
                    do
                    {
                        username = Console.ReadLine();

                    } while (string.IsNullOrEmpty(username));

                    User receiver = manager.UserCheck(username);
                    Console.Clear();
                    if (receiver == null)
                    {
                        Console.WriteLine("Username doesnt exist");
                        Console.WriteLine("Please try again");
                    }
                    else
                    {
                        List<Message> messages = manager.MessagesSendByUserIdToReceiverId(user.Id, receiver.Id);

                        foreach (var item in messages)
                        {
                            Console.WriteLine($"You send {item.MessageData}  to {receiver.Username}");
                        }
                    }
                    Console.ReadKey();
                }

                else if (role == Role.EditUser && input == 3)
                {
                    Console.WriteLine($"Hello {user.Username},thats all the messages you have received");
                    Manager manager = new Manager();
                    List<Message> messages = manager.MessagesReceived(user.Id);

                    foreach (var item in messages)
                    {
                        Console.WriteLine(item.MessageData);
                    }
                    Console.ReadKey();
                }

                else if (role == Role.EditUser && input == 4)
                {
                    Console.WriteLine("Write your message");
                    string message;
                    do
                    {
                        message = Console.ReadLine();
                    }
                    while (string.IsNullOrEmpty(message));
                    Console.WriteLine("Where you want to send it?");
                    string receiver;
                    do
                    {
                        receiver = Console.ReadLine();

                    } while (string.IsNullOrEmpty(receiver));

                    Manager manager = new Manager();
                    User userreceiver = manager.UserCheck(receiver);
                    Console.Clear();
                    if (userreceiver != null)
                    {
                        manager.SendMessage(message, user.Id, userreceiver.Id);
                        Console.WriteLine("message send");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("User doesnt exist");
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                    }
                }

                else if(role==Role.EditUser && input == 5)
                {
                    Console.WriteLine($"Hello {user.Username},write the user's name to view the message you want to edit");
                    Manager manager = new Manager();
                    Console.WriteLine("Give a username");
                    string username;
                    do
                    {
                        username = Console.ReadLine();

                    } while (string.IsNullOrEmpty(username));

                    User receiver = manager.UserCheck(username);
                    Console.Clear();
                    if (receiver == null)
                    {
                        Console.WriteLine("Username doesnt exists");
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                    }
                    else
                    {
                        List<Message> messages = manager.MessagesSendByUserIdToReceiverId(user.Id, receiver.Id);

                        foreach (var item in messages)
                        {
                            Console.WriteLine($"You send {item.MessageData} with ID {item.Id}  to {receiver.Username}");

                        }
                        Console.ReadKey();

                        Console.WriteLine("Write new content for the message");
                        string new_content;
                        do
                        {
                            new_content = Console.ReadLine();

                        } while (string.IsNullOrEmpty(new_content));
                        Console.WriteLine("Write messsage's ID");
                        string messageId;
                        do
                        {
                            messageId = Console.ReadLine();

                        } while (string.IsNullOrEmpty(messageId));

                        int Id = int.Parse(messageId);
                        manager.UpdateMessage(Id, new_content);
                    }
                }

                else if (role == Role.EditUser && input == 0)
                {
                    Environment.Exit(0);
                }

                //DELETEUSER
                if (role == Role.DeleteUser && input == 1)
                {
                    Console.WriteLine($"Hello {user.Username},thats all the messages you have send");
                    Manager manager = new Manager();
                    List<Message> messages = manager.MessagesSend(user.Id);

                    foreach (var item in messages)
                    {
                        Console.WriteLine(item.MessageData);
                    }
                    Console.ReadKey();
                }
                else if (role == Role.DeleteUser && input == 2)
                {
                    Console.WriteLine($"Hello {user.Username},write the username to view the message you have send");
                    Manager manager = new Manager();
                    Console.WriteLine("Give a username");
                    string username;
                    do
                    {
                        username = Console.ReadLine();

                    } while (string.IsNullOrEmpty(username));

                    User receiver = manager.UserCheck(username);
                    Console.Clear();
                    if (receiver == null)
                    {
                        Console.WriteLine("Username doesnt exist");
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                    }
                    else
                    {
                        List<Message> messages = manager.MessagesSendByUserIdToReceiverId(user.Id, receiver.Id);

                        foreach (var item in messages)
                        {
                            Console.WriteLine($"You sent {item.MessageData}  to {receiver.Username}");
                            Console.ReadKey();
                        }

                    }
                    Console.ReadKey();
                }

                else if (role == Role.DeleteUser && input == 3)
                {
                    Console.WriteLine($"Hello {user.Username},thats all the messages you have received");
                    Manager manager = new Manager();
                    List<Message> messages = manager.MessagesReceived(user.Id);

                    foreach (var item in messages)
                    {
                        Console.WriteLine(item.MessageData);
                    }
                    Console.ReadKey();
                }

                else if (role == Role.DeleteUser && input == 4)
                {
                    Console.WriteLine("Write your message");
                    string message;
                    do
                    {
                        message = Console.ReadLine();
                    }
                    while (string.IsNullOrEmpty(message));
                    Console.WriteLine("Where you want to send it?");
                    string receiver;
                    do
                    {
                        receiver = Console.ReadLine();

                    } while (string.IsNullOrEmpty(receiver));

                    Manager manager = new Manager();
                    User userreceiver = manager.UserCheck(receiver);
                    Console.Clear();
                    if (userreceiver != null)
                    {
                        manager.SendMessage(message, user.Id, userreceiver.Id);
                        Console.WriteLine("message send");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("User doesnt exist");
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                    }
                }

                else if (role == Role.DeleteUser && input == 5)
                {
                    Console.WriteLine($"Hello {user.Username},write the user's name to view the message you want to edit");
                    Manager manager = new Manager();
                    Console.WriteLine("Give a username");
                    string username;
                    do
                    {
                        username = Console.ReadLine();

                    } while (string.IsNullOrEmpty(username));

                    User receiver = manager.UserCheck(username);
                    Console.Clear();
                    if (receiver == null)
                    {
                        Console.WriteLine("Username doesnt exist");
                        Console.WriteLine("Please try again");
                        Console.ReadKey();
                    }
                    else
                    {
                        List<Message> messages = manager.MessagesSendByUserIdToReceiverId(user.Id, receiver.Id);

                        foreach (var item in messages)
                        {
                            Console.WriteLine($"You send {item.MessageData} with ID {item.Id}  to {receiver.Username}");

                            
                        }
                        Console.ReadKey();


                        Console.WriteLine("Write new content of the message");
                        string new_content;
                        do
                        {
                            new_content = Console.ReadLine();

                        } while (string.IsNullOrEmpty(new_content));
                        Console.WriteLine("Write messsage's ID");
                        string messageId;
                        do
                        {
                            messageId = Console.ReadLine();

                        } while (string.IsNullOrEmpty(messageId));

                        int Id = int.Parse(messageId);
                        manager.UpdateMessage(Id, new_content);

                    }
                }

                else if (role == Role.DeleteUser && input == 6)
                {
                    Console.WriteLine($"Hello {user.Username},write the username to view the message you want to delete");
                    Manager manager = new Manager();
                    Console.WriteLine("Give a username");
                    string username;
                    do
                    {
                        username = Console.ReadLine();

                    } while (string.IsNullOrEmpty(username));

                    User receiver = manager.UserCheck(username);
                    Console.Clear();
                    if (receiver == null)
                    {
                        Console.WriteLine("Username doesnt exist");
                        Console.WriteLine("Please try again");
                    }
                    else
                    {
                        List<Message> messages = manager.MessagesSendByUserIdToReceiverId(user.Id, receiver.Id);

                        foreach (var item in messages)
                        {
                            Console.WriteLine($"You send {item.MessageData} with ID {item.Id}  to {receiver.Username}");
                        }
                        Console.ReadKey();

                        Console.WriteLine("Write messsage's ID you want to delete");
                        string messageId;
                        do
                        {
                            messageId = Console.ReadLine();

                        } while (string.IsNullOrEmpty(messageId));

                        int Id = int.Parse(messageId);
                        manager.DeleteMessage(Id);

                    }
                }

                else if (role == Role.DeleteUser && input == 0)
                {
                    Environment.Exit(0);
                }

            }

        }
    }
}
