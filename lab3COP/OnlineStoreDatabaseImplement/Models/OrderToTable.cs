using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreDatabaseImplement.Models
{
    public class OrderToTable
    {
        public string ClientName { get; set; }
        public int? Id { get; set; }
        public string DestinationCity { get; set; }
        public DateTime? DestinationDate { get; set; }
    }
}
