using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreDatabaseImplement.Models
{
    public class OrderViewModel
    {
        [DisplayName("ФИО клиента")]
        public string ClientName { get; set; }
        [DisplayName("Идентификатор")]
        public int? Id { get; set; }

        [DisplayName("Город назначения")]
        public string DestinationCity { get; set; }

        [DisplayName("Дата получения заказа")]
        public DateTime? DestinationDate { get; set; }

        [DisplayName("Отметка 1")]
        public string Track1 { get; set; }

        [DisplayName("Отметка 2")]
        public string Track2 { get; set; }

        [DisplayName("Отметка 3")]
        public string Track3 { get; set; }

        [DisplayName("Отметка 4")]
        public string Track4 { get; set; }

        [DisplayName("Отметка 5")]
        public string Track5 { get; set; }

        [DisplayName("Отметка 6")]
        public string Track6 { get; set; }

       
    }
}
