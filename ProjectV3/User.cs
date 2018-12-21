using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectV3
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        [InverseProperty("Sender")]
        public virtual  ICollection<Message> Messages_Send { get; set; }

        [InverseProperty("Receiver")]
        public  virtual ICollection<Message> Messages_Received { get; set; }

    }
}
