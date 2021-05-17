using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BlacksmithBusinessLogic.ViewModels;
using BlacksmithBusinessLogic.BindingModels;
using EmployeeWarehouseApp.Models;

namespace EmployeeWarehouseApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(ApiEmployee.GetRequest<List<WarehouseViewModel>>("api/warehouse/GetWarehouseList"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (password != Program.Password)
                {
                    throw new Exception("Неверный пароль");
                }
                Program.Enter = true;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(string name, string responsible)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(responsible))
            {
                ApiEmployee.PostRequest("api/warehouse/CreateOrUpdateWarehouse", new WarehouseBindingModel
                {
                    ResponsiblePersonFCS = responsible,
                    WarehouseName = name,
                    DateCreate = DateTime.Now,
                    WarehouseComponents = new Dictionary<int, (string, int)>()
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите имя и ответственного");
        }

        [HttpGet]
        public IActionResult Update(int warehouseId)
        {
            var warehouse = ApiEmployee.GetRequest<WarehouseViewModel>($"api/warehouse/GetWarehouse?warehouseId={warehouseId}");
            ViewBag.Components = warehouse.WarehouseComponents.Values;
            ViewBag.Name = warehouse.WarehouseName;
            ViewBag.Responsible = warehouse.ResponsiblePersonFCS;
            return View();
        }

        [HttpPost]
        public void Update(int warehouseId, string name, string responsible)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(responsible))
            {
                var warehouse = ApiEmployee.GetRequest<WarehouseViewModel>($"api/warehouse/GetWarehouse?warehouseId={warehouseId}");
                if (warehouse == null)
                {
                    return;
                }
                ApiEmployee.PostRequest("api/warehouse/CreateOrUpdateWarehouse", new WarehouseBindingModel
                {
                    ResponsiblePersonFCS = responsible,
                    WarehouseName = name,
                    DateCreate = DateTime.Now,
                    WarehouseComponents = warehouse.WarehouseComponents,
                    Id = warehouse.Id
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Warehouse = ApiEmployee.GetRequest<List<WarehouseViewModel>>("api/warehouse/GetWarehouseList");
            return View();
        }

        [HttpPost]
        public void Delete(int warehouseId)
        {
            ApiEmployee.PostRequest("api/warehouse/DeleteWarehouse", new WarehouseBindingModel
            {
                Id = warehouseId
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Restoking()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Warehouse = ApiEmployee.GetRequest<List<WarehouseViewModel>>("api/warehouse/GetWarehouseList");
            ViewBag.Component = ApiEmployee.GetRequest<List<ComponentViewModel>>("api/warehouse/GetComponentList");
            return View();
        }

        [HttpPost]
        public void Restoking(int warehouseId, int componentId, int count)
        {
            ApiEmployee.PostRequest("api/warehouse/Restoking", new WarehouseReplenishmentBindingModel
            {
                WarehouseId = warehouseId,
                ComponentId = componentId,
                Count = count
            });
            Response.Redirect("Restoking");
        }
    }
}