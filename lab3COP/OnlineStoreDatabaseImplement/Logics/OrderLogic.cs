using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreDatabaseImplement.Models;
using OnlineStoreDatabaseImplement.Storages;

namespace OnlineStoreDatabaseImplement.Logics
{
    public class OrderLogic
    {
        private readonly OrderStorage orderStorage = new OrderStorage();
        public OrderLogic() { }

        public List<OrderViewModel> Read(OrderViewModel model)
        {
            if (model == null)
            {
                return orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { orderStorage.GetElement(model) };
            }
            return null;
        }

        public void Create(OrderViewModel model)
        {
            orderStorage.Insert(model);
        }

        public void Update(OrderViewModel model)
        {
            var element = orderStorage.GetElement(model);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            orderStorage.Update(model);
        }

        public void Delete(OrderViewModel model)
        {
            var element = orderStorage.GetElement(model);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            orderStorage.Delete(model);
        }
    }
}
