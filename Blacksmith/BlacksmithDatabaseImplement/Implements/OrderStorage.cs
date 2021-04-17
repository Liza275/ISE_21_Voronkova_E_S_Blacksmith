﻿using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.Interfaces;
using BlacksmithBusinessLogic.ViewModels;
using BlacksmithDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlacksmithDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public void Delete(OrderBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BlacksmithDatabase())
            {
                var order = context.Orders.Include(rec => rec.Manufacture)
                .FirstOrDefault(rec => rec.Id == model.Id || rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    ManufactureId = order.ManufactureId,
                    ManufactureName = order.Manufacture?.ManufactureName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order?.DateImplement
                } : null;
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new BlacksmithDatabase())
            {
                return context.Orders.Include(rec => rec.Manufacture)
                .Where(rec => rec.Id == model.Id)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ManufactureId = rec.ManufactureId,
                    ManufactureName = rec.Manufacture.ManufactureName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }

        public List<OrderViewModel> GetFullList()
        {
            using (var context = new BlacksmithDatabase())
            {
                return context.Orders.Include(rec=>rec.Manufacture)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ManufactureId = rec.ManufactureId,
                    ManufactureName = rec.Manufacture.ManufactureName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new BlacksmithDatabase())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ManufactureId = model.ManufactureId;
            order.Count = model.Count;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
