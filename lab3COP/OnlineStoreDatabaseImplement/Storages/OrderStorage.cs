using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreDatabaseImplement.Models;

namespace OnlineStoreDatabaseImplement.Storages
{
    public class OrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new OnlineStoreDatabase())
            {
                return context.Orders.Select(CreateModel).ToList();
            }
            
        }

        public OrderViewModel GetElement(OrderViewModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new OnlineStoreDatabase())
            {
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ? CreateModel(order) : null;
            }
            
        }

        public void Insert(OrderViewModel model)
        {
            using (var context = new OnlineStoreDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
            
        }

        public void Update(OrderViewModel model)
        {
            using (var context = new OnlineStoreDatabase())
            {
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, order);
                context.SaveChanges();
            }
            
        }

        public void Delete(OrderViewModel model)
        {
            using (var context = new OnlineStoreDatabase()) { 
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ClientName = order.ClientName,
                Track1 = order.Track1,
                Track2 = order.Track2,
                Track3 = order.Track3,
                Track4 = order.Track4,
                Track5 = order.Track5,
                Track6 = order.Track6,
                DestinationCity = order.DestinationCity,
                DestinationDate = order.DestinationDate
            };
        }

        private Order CreateModel(OrderViewModel model, Order order)
        {
            order.ClientName = model.ClientName;
            order.Track1 = model.Track1;
            order.Track2 = model.Track2;
            order.Track3 = model.Track3;
            order.Track4 = model.Track4;
            order.Track5 = model.Track5;
            order.Track6 = model.Track6;
            order.DestinationCity = model.DestinationCity;
            order.DestinationDate = model.DestinationDate;
            return order;
        }
    }
}
