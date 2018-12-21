using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjectV3
{
    public class Manager
    {
        public User Login(string Username, string Password)
        {
            User user;
            using (var db = new AppContext())
            {
                user = db.Users.FirstOrDefault(x => x.Username == Username && x.Password == Password);

            }
            return user;

        }

        public User UserCheck(string Username)
        {
            User user;
            using (var db = new AppContext())
            {
                user = db.Users.FirstOrDefault(x => x.Username == Username);

            }
            return user;
        }

        public void CreateUser(string Username, string Password,Role UserRole)
        {
            using (var db = new AppContext())
            {
                var user = new User()
                {
                    Username = Username,
                    Password = Password,
                    Role= UserRole
                };
                db.Users.Add(user);
                db.SaveChanges();
                
            }
        }

        public Role RoleChoose(int input)
        {
            Role role = Role.ViewUser;
            bool ValidRole = false;
            do
            {
                if (input == 1)
                {
                    role = Role.ViewUser;
                    ValidRole = false;
                }
                else if (input == 2)
                {
                    role = Role.EditUser;
                    ValidRole = false;

                }
                else if (input == 3)
                {
                    role = Role.DeleteUser;
                    ValidRole = false;

                }
                else
                {
                    ValidRole = true;
                }
                return role;
            } while (ValidRole);
        }

        public void SendMessage(string content, int SenderId,int ReceiverId)
        {
            using (var db = new AppContext())
            {
                var user1 = db.Users.Find(SenderId);
                var user2 = db.Users.Find(ReceiverId);
                if (user1 != null && user2 !=null)
                {
                    Message message = new Message()
                    {
                        MessageData = content,
                        Date = DateTime.Now,
                        Sender = user1,
                        Receiver = user2
                    };
                    db.Messages.Add(message);
                    db.SaveChanges();
                }
            }
        }


        public List<User> GetAllUsers()
        {
            List<User> users;
            using (var db = new AppContext())
            {
                users = db.Users.ToList();
            }
            return users;

        }


        public List<Message> MessagesSend(int SenderId)
        {
            List<Message> messages;
            using (var db = new AppContext())
            {
                messages = db.Messages.Where(m => m.Sender.Id == SenderId).ToList();
            }

            return messages;
        }

        public List<Message> MessagesReceived(int ReceiverId)
        {
            List<Message> messages;
            using (var db = new AppContext())
            {
                messages = db.Messages.Where(m => m.Receiver.Id == ReceiverId).ToList();
            }
            return messages;
        }

        public List<Message> MessagesSendByUserIdToReceiverId(int SenderId,int ReceiverId)
        {
            List<Message> messages;
            using (var db = new AppContext())
            {
                messages = db.Messages.Where(m => m.Sender.Id == SenderId && m.Receiver.Id==ReceiverId).ToList();
            }

            return messages;
        }

        public void UpdateMessage(int MessageId,string new_message)
        {
            using (var db = new AppContext())
            {
                Message message = db.Messages.Find(MessageId);
                if (message != null)
                {
                    message.MessageData = new_message;
                    db.SaveChanges();
                }
            }
        }


        public void DeleteMessage(int MessageId)
        {
            using (var db = new AppContext())
            {
                Message message = db.Messages.Find(MessageId);
                if (message != null)
                {
                    db.Entry(message).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public void UpdateUsername(int UserId, string new_name)
        {
            using (var db = new AppContext())
            {
                User user = db.Users.Find(UserId);
                if (user != null)
                {
                    user.Username = new_name;
                    db.SaveChanges();
                }
            }
        }

        public void UpdatePassword(int UserId, string new_psw)
        {
            using (var db = new AppContext())
            {
                User user = db.Users.Find(UserId);
                if (user != null)
                {
                    user.Password = new_psw;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteUser(int UserId)
        {
            using (var db = new AppContext())
            {
                User user = db.Users.Find(UserId);
                if (user != null)
                {
                    db.Entry(user).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }





    }
}
