using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreDatabaseImplement.Models
{
    public class DestinationCity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
