using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectV3
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string MessageData { get; set; }

        public DateTime Date { get; set; }

   
        public virtual User Sender { get; set; }

        public virtual User Receiver { get; set; }

    }
}
