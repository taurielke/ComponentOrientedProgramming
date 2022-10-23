using OnlineStoreView.Plugins;
using OnlineStoreDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreView.Plugin
{
    public class OrderConventionElement : PluginsConventionElement
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string DestinationCity { get; set; }
        public DateTime? DestinationDate { get; set; }
    }
}
