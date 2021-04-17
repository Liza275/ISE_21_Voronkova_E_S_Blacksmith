using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.Interfaces;
using BlacksmithBusinessLogic.ViewModels;
using BlacksmithDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BlacksmithDatabaseImplement.Implements
{
    public class ManufactureStorage : IManufactureStorage
    {
        public List<ManufactureViewModel> GetFullList()
        {
            using (var context = new BlacksmithDatabase())
            {
                return context.Manufactures
                .Include(rec => rec.ManufactureComponents)
               .ThenInclude(rec => rec.Component)
               .ToList()
               .Select(rec => new ManufactureViewModel
               {
                   Id = rec.Id,
                   ManufactureName = rec.ManufactureName,
                   Price = rec.Price,
                   ManufactureComponents = rec.ManufactureComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
        public List<ManufactureViewModel> GetFilteredList(ManufactureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BlacksmithDatabase())
            {
                return context.Manufactures
                .Include(rec => rec.ManufactureComponents)
               .ThenInclude(rec => rec.Component)
               .Where(rec => rec.ManufactureName.Contains(model.ManufactureName))
               .ToList()
               .Select(rec => new ManufactureViewModel
               {
                   Id = rec.Id,
                   ManufactureName = rec.ManufactureName,
                   Price = rec.Price,
                   ManufactureComponents = rec.ManufactureComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
               }).ToList();
            }
        }
        public ManufactureViewModel GetElement(ManufactureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BlacksmithDatabase())
            {
                var manufacture = context.Manufactures
                .Include(rec => rec.ManufactureComponents)
               .ThenInclude(rec => rec.Component)
               .FirstOrDefault(rec => rec.ManufactureName == model.ManufactureName || rec.Id == model.Id);
                return manufacture != null ?
                new ManufactureViewModel
                {
                    Id = manufacture.Id,
                    ManufactureName = manufacture.ManufactureName,
                    Price = manufacture.Price,
                    ManufactureComponents = manufacture.ManufactureComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
                } : null;
            }
        }
        public void Insert(ManufactureBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var manufacture = CreateModel(model, new Manufacture());
                        context.Manufactures.Add(manufacture);
                        context.SaveChanges();
                        manufacture = CreateModel(model, manufacture, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(ManufactureBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Manufactures.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(ManufactureBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                Manufacture element = context.Manufactures.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Manufactures.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Manufacture CreateModel(ManufactureBindingModel model, Manufacture car)
        {
            car.ManufactureName = model.ManufactureName;
            car.Price = model.Price;
            return car;
        }

        private Manufacture CreateModel(ManufactureBindingModel model, Manufacture manufacture,
       BlacksmithDatabase context)
        {
            manufacture.ManufactureName = model.ManufactureName;
            manufacture.Price = model.Price;
            if (model.Id.HasValue)
            {
                var manufactureComponents = context.ManufactureComponents.Where(rec =>
               rec.ManufactureId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.ManufactureComponents.RemoveRange(manufactureComponents.Where(rec =>
               !model.ManufactureComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in manufactureComponents)
                {
                    updateComponent.Count =
                   model.ManufactureComponents[updateComponent.ComponentId].Item2;
                    model.ManufactureComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.ManufactureComponents)
            {
                context.ManufactureComponents.Add(new ManufactureComponent
                {
                    ManufactureId = manufacture.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return manufacture;
        }
    }
}
