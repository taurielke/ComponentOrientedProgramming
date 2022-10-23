using lab3COP.Plugins;
using OnlineStoreDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3COP.Plugin
{
    public class OrderConventionElement : PluginsConventionElement
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string DestinationCity { get; set; }
        public DateTime? DestinationDate { get; set; }
    }
}
