using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreDatabaseImplement.Models
{
    public class Order
    {
        [Required]
        public string ClientName { get; set; }
        public int Id { get; set; }
        
        [Required]
        public string DestinationCity { get; set; }
        public DateTime? DestinationDate { get; set; }
        public string Track1 { get; set; }
        public string Track2 { get; set; }
        public string Track3 { get; set; }
        public string Track4 { get; set; }
        public string Track5 { get; set; }
        public string Track6 { get; set; }

        
    }
}
