﻿using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.Interfaces;
using BlacksmithBusinessLogic.ViewModels;
using BlacksmithDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlacksmithDatabaseImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        public List<ComponentViewModel> GetFullList()
        {
            using (var context = new BlacksmithDatabase())
            {
                return context.Components
                .Select(rec => new ComponentViewModel
                {
                    Id = rec.Id,
                    ComponentName = rec.ComponentName
                }).ToList();
            }
        }
        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BlacksmithDatabase())
            {
                return context.Components
                .Where(rec => rec.ComponentName.Contains(model.ComponentName))
               .Select(rec => new ComponentViewModel
               {
                   Id = rec.Id,
                   ComponentName = rec.ComponentName
               })
                .ToList();
            }
        }
        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BlacksmithDatabase())
            {
                var component = context.Components
                .FirstOrDefault(rec => rec.ComponentName == model.ComponentName ||
               rec.Id == model.Id);
                return component != null ?
                new ComponentViewModel
                {
                    Id = component.Id,
                    ComponentName = component.ComponentName
                } : null;
            }
        }
        public void Insert(ComponentBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                context.Components.Add(CreateModel(model, new Component()));
                context.SaveChanges();
            }
        }
        public void Update(ComponentBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                var element = context.Components.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(ComponentBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                Component element = context.Components.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Components.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Component CreateModel(ComponentBindingModel model, Component component)
        {
            component.ComponentName = model.ComponentName;
            return component;
        }
    }
}
