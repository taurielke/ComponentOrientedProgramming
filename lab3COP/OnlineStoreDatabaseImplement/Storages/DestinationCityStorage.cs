using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreDatabaseImplement.Models;

namespace OnlineStoreDatabaseImplement.Storages
{
    public class DestinationCityStorage
    {
        public List<DestinationCityViewModel> GetFullList()
        {
            using (var context = new OnlineStoreDatabase())
            {
                return context.DestinationCities.Select(CreateModel).ToList();
            }
            
        }
        public DestinationCityViewModel GetElement(DestinationCityViewModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new OnlineStoreDatabase()) 
            { 
            var elem = context.DestinationCities.FirstOrDefault(rec => rec.Id == model.Id);
            return elem != null ? CreateModel(elem) : null;
            }   
        }

        public void Insert(DestinationCityViewModel model)
        {
            using (var context = new OnlineStoreDatabase())
            {
                context.DestinationCities.Add(CreateModel(model, new DestinationCity()));
                context.SaveChanges();
            }
            
        }

        public void Update(DestinationCityViewModel model)
        {
            using (var context = new OnlineStoreDatabase())
            {
                DestinationCity destinationCity = context.DestinationCities.FirstOrDefault(rec => rec.Id == model.Id);
                if (destinationCity == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, destinationCity);
                context.SaveChanges();
            }
            
        }

        public void Delete(DestinationCityViewModel model)
        {
            using (var context = new OnlineStoreDatabase())
            {
                DestinationCity destinationCity = context.DestinationCities.FirstOrDefault(rec => rec.Id == model.Id);
                if (destinationCity != null)
                {
                    context.DestinationCities.Remove(destinationCity);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            
        }
        private DestinationCityViewModel CreateModel(DestinationCity dc)
        {
            return new DestinationCityViewModel
            {
                Id = dc.Id,
                Name = dc.Name
            };
        }
        private DestinationCity CreateModel(DestinationCityViewModel model, DestinationCity dc)
        {
            dc.Name = model.Name;
            return dc;
        }
    }
}
