using System;
using System.Collections.Generic;
using System.Linq;
using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.HelperModels;
using BlacksmithBusinessLogic.Interfaces;
using BlacksmithBusinessLogic.ViewModels;
using BlacksmithBusinessLogic.Enums;

namespace BlacksmithBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IManufactureStorage _manufactureStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IWarehouseStorage _warehouseStorage;

        public ReportLogic(IManufactureStorage carStorage, IComponentStorage
       componentStorage, IOrderStorage orderStorage, IWarehouseStorage warehouseStorage)
        {
            _manufactureStorage = carStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _warehouseStorage = warehouseStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportComponentManufactureViewModel> GetComponentManufacture()
        {
            var components = _componentStorage.GetFullList();
            var manufactures = _manufactureStorage.GetFullList();
            var list = new List<ReportComponentManufactureViewModel>();
            foreach (var manufacture in manufactures)
            {
                var record = new ReportComponentManufactureViewModel
                {
                    ManufactureName = manufacture.ManufactureName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (manufacture.ManufactureComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName,
                        manufacture.ManufactureComponents[component.Id].Item2));
                        record.TotalCount += manufacture.ManufactureComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                ManufactureName = x.ManufactureName,
                Count = x.Count,
                Sum = x.Sum,
                Status = ((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString())).ToString()
            })
            .ToList();
        }

        public List<ReportOrderByDatesViewModel> GetOrdersByDates()
        {
            return _orderStorage.GetFullList()
            .GroupBy(rec => rec.DateCreate.ToShortDateString())
            .Select(group => new ReportOrderByDatesViewModel
            {
                DateCreate = group.FirstOrDefault().DateCreate,
                OrdersCount = group.Count(),
                TotalSum = group.Sum(rec => rec.Sum)
            }).ToList();
        }
        /// <summary>
        /// Сохранение изделия в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveManufacturesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Manufactures = _manufactureStorage.GetFullList()
            });
        }

        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocWarehouses(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = _warehouseStorage.GetFullList()
            });
        }

        public List<ReportWarehouseComponentViewModel> GetWarehouseComponent()
        {
            var components = _componentStorage.GetFullList();
            var warehouses = _warehouseStorage.GetFullList();
            var list = new List<ReportWarehouseComponentViewModel>();
            foreach (var warehouse in warehouses)
            {
                var record = new ReportWarehouseComponentViewModel
                {
                    WarehouseName = warehouse.WarehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (warehouse.WarehouseComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName,
                       warehouse.WarehouseComponents[component.Id].Item2));
                        record.TotalCount += warehouse.WarehouseComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        [Obsolete]
        public void SaveOrdersByDatesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocOrdersByDates(new PdfInfoOrdersByDates
            {
                FileName = model.FileName,
                Title = "Заказы по датам",
                Orders = GetOrdersByDates()
            });
        }

        public void SaveWarehouseComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Компоненты по складам",
                Warehouses = GetWarehouseComponent()
            });
        }

        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentManufactureToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                ComponentManufactures = GetComponentManufacture()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}