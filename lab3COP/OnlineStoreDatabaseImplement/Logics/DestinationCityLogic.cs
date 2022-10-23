using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreDatabaseImplement.Models;
using OnlineStoreDatabaseImplement.Storages;

namespace OnlineStoreDatabaseImplement.Logics
{
    public class DestinationCityLogic
    {
        private readonly DestinationCityStorage destinationCityStorage = new DestinationCityStorage();
        public DestinationCityLogic() { }

        public List<DestinationCityViewModel> Read(DestinationCityViewModel model)
        {
            if (model == null)
            {
                return destinationCityStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DestinationCityViewModel> { destinationCityStorage.GetElement(model) };
            }
            return null;
        }

        public void Create(DestinationCityViewModel model)
        {
            destinationCityStorage.Insert(model);
        }

        public void Update(DestinationCityViewModel model)
        {
            var element = destinationCityStorage.GetElement(model);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            destinationCityStorage.Update(model);
        }

        public void Delete(DestinationCityViewModel model)
        {
            var element = destinationCityStorage.GetElement(model);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            destinationCityStorage.Delete(model);
        }
    }
}
