using BlacksmithListImplement.Models;
using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.Interfaces;
using BlacksmithBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace BlacksmithListImplement
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;//использование

        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    return CreateModel(order);
                }
            }
            return null;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (order.DateCreate.Equals(model.DateCreate))
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }

        public List<OrderViewModel> GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                result.Add(CreateModel(order));
            }
            return result;
        }

        public void Insert(OrderBindingModel model)
        {
            Order tempOrder = new Order
            {
                Id = 1,
            };
            foreach (var order in source.Orders)
            {
                if (order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
            }
            source.Orders.Add(CreateModel(model, tempOrder));
        }

        public void Update(OrderBindingModel model)
        {
            Order tempOrder = null;
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (tempOrder == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempOrder);
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ManufactureId = model.ManufactureId;
            order.ClientId = (int)model.ClientId;
            order.Count = model.Count;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            var fio = "";
            foreach (var client in source.Clients)
            {
                if (client.Id == order.ClientId)
                {
                    fio = client.ClientFIO;
                    break;
                }
            }
            var mName = "";
            foreach (var man in source.Manufactures)
            {
                if (man.Id == order.ManufactureId)
                {
                    mName = man.ManufactureName;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                ClientFIO = fio,
                ManufactureId = order.ManufactureId,
                ManufactureName = mName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
