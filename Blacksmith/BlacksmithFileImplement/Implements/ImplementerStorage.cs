﻿using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.Interfaces;
using BlacksmithBusinessLogic.ViewModels;
using BlacksmithFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlacksmithFileImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        private readonly FileDataListSingleton source;

        public ImplementerStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void Delete(ImplementerBindingModel model)
        {
            Implementer element = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Implementers.Remove(element);
            }
            else
            {
                throw new Exception("Исполнитель не найден");
            }
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var implementer = source.Implementers
            .FirstOrDefault(rec => rec.Id == model.Id);
            return implementer != null ?
            CreateModel(implementer) : null;

        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return source.Implementers
                .Where(rec =>
                rec.ImplementerFIO.Contains(model.ImplementerFIO))
                .Select(CreateModel).ToList();

        }

        public List<ImplementerViewModel> GetFullList()
        {
            return source.Implementers
            .Select(CreateModel).ToList();
        }

        public void Insert(ImplementerBindingModel model)
        {
            source.Implementers.Add(CreateModel(model, new Implementer()));
        }

        public void Update(ImplementerBindingModel model)
        {
            var element = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Исполнитель не найден");
            }
            CreateModel(model, element);
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