﻿using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.BusinessLogics;
using BlacksmithBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlacksmithRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly warehouseLogic _warehouse;

        private readonly ComponentLogic _component;

        public WarehouseController(warehouseLogic warehouseLogic, ComponentLogic componentLogic)
        {
            _warehouse = warehouseLogic;
            _component = componentLogic;
        }

        [HttpGet]
        public List<WarehouseViewModel> GetWarehouseList() => _warehouse.Read(null)?.ToList();

        [HttpPost]
        public void CreateOrUpdateWarehouse(WarehouseBindingModel model) => _warehouse.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => _warehouse.Delete(model);

        [HttpPost]
        public void Restoking(WarehouseReplenishmentBindingModel model) => _warehouse.Replenishment(model);

        [HttpGet]
        public WarehouseViewModel GetWarehouse(int warehouseId) => _warehouse.Read(new WarehouseBindingModel { Id = warehouseId })?[0];

        [HttpGet]
        public List<ComponentViewModel> GetComponentList() => _component.Read(null);
    }
}