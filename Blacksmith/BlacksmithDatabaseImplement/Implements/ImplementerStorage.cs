﻿using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.Interfaces;
using BlacksmithBusinessLogic.ViewModels;
using BlacksmithDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlacksmithDatabaseImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        public void Delete(ImplementerBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Implementers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Исполнитель не найден");
                }
            }
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BlacksmithDatabase())
            {
                var implementer = context.Implementers
                .FirstOrDefault(rec => rec.Id == model.Id);
                return implementer != null ?
                CreateModel(implementer) : null;
            }
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BlacksmithDatabase())
            {
                return context.Implementers
                    .Where(rec =>
                    rec.ImplementerFIO.Contains(model.ImplementerFIO))
                    .Select(CreateModel).ToList();
            }
        }

        public List<ImplementerViewModel> GetFullList()
        {
            using (var context = new BlacksmithDatabase())
            {
                return context.Implementers
                .Select(CreateModel).ToList();
            }
        }

        public void Insert(ImplementerBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                context.Implementers.Add(CreateModel(model, new Implementer()));
                context.SaveChanges();
            }
        }

        public void Update(ImplementerBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                var element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Исполнитель не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.ImplementerFIO = model.ImplementerFIO;
            implementer.WorkingTime = model.WorkingTime;
            implementer.PauseTime = model.PauseTime;
            return implementer;
        }

        private ImplementerViewModel CreateModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                ImplementerFIO = implementer.ImplementerFIO,
                WorkingTime = implementer.WorkingTime,
                PauseTime = implementer.PauseTime
            };
        }
    }
}