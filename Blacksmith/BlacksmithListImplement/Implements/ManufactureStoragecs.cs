using BlacksmithBusinessLogic.Interfaces;
using BlacksmithBusinessLogic.ViewModels;
using BlacksmithListImplement.Models;
using System;
using System.Collections.Generic;
using BlacksmithBusinessLogic.BindingModels;
using System.Linq;

namespace BlacksmithListImplement.Implements
{
    public class ManufactureStorage : IManufactureStorage
    {
        private readonly DataListSingleton source;
        public ManufactureStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ManufactureViewModel> GetFullList()
        {
            List<ManufactureViewModel> result = new List<ManufactureViewModel>();
            foreach (var component in source.Manufactures)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<ManufactureViewModel> GetFilteredList(ManufactureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<ManufactureViewModel> result = new List<ManufactureViewModel>();
            foreach (var manufacture in source.Manufactures)
            {
                if (manufacture.ManufactureName.Contains(model.ManufactureName))
                {
                    result.Add(CreateModel(manufacture));
                }
            }
            return result;
        }
        public ManufactureViewModel GetElement(ManufactureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var manufacture in source.Manufactures)
            {
                if (manufacture.Id == model.Id || manufacture.ManufactureName ==
                model.ManufactureName)
                {
                    return CreateModel(manufacture);
                }
            }
            return null;
        }
        public void Insert(ManufactureBindingModel model)
        {
            Manufacture tempManufacture = new Manufacture
            {
                Id = 1,
                ManufactureComponents = new
            Dictionary<int, int>()
            };
            foreach (var manufacture in source.Manufactures)
            {
                if (manufacture.Id >= tempManufacture.Id)
                {
                    tempManufacture.Id = manufacture.Id + 1;
                }
            }
            source.Manufactures.Add(CreateModel(model, tempManufacture));
        }
        public void Update(ManufactureBindingModel model)
        {
            Manufacture tempManufacture = null;
            foreach (var manufacture in source.Manufactures)
            {
                if (manufacture.Id == model.Id)
                {
                    tempManufacture = manufacture;
                }
            }
            if (tempManufacture == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempManufacture);
        }
        public void Delete(ManufactureBindingModel model)
        {
            for (int i = 0; i < source.Manufactures.Count; ++i)
            {
                if (source.Manufactures[i].Id == model.Id)
                {
                    source.Manufactures.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Manufacture CreateModel(ManufactureBindingModel model, Manufacture manufacture)
        {
            manufacture.ManufactureName = model.ManufactureName;
            manufacture.Price = model.Price;
            // удаляем убранные
            foreach (var key in manufacture.ManufactureComponents.Keys.ToList())
            {
                if (!model.ManufactureComponents.ContainsKey(key))
                {
                    manufacture.ManufactureComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.ManufactureComponents)
            {
                if (manufacture.ManufactureComponents.ContainsKey(component.Key))
                {
                    manufacture.ManufactureComponents[component.Key] =
                    model.ManufactureComponents[component.Key].Item2;
                }
                else
                {
                    manufacture.ManufactureComponents.Add(component.Key,
                    model.ManufactureComponents[component.Key].Item2);
                }
            }
            return manufacture;
        }
        private ManufactureViewModel CreateModel(Manufacture manufacture)
        {
            // требуется дополнительно получить список компонентов для изделия с
            
        Dictionary<int, (string, int)> manufactureComponents = new
        Dictionary<int, (string, int)>();
            foreach (var pc in manufacture.ManufactureComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                manufactureComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new ManufactureViewModel
            {
                Id = manufacture.Id,
                ManufactureName = manufacture.ManufactureName,
                Price = manufacture.Price,
                ManufactureComponents = manufactureComponents
            };
        }
    }
}