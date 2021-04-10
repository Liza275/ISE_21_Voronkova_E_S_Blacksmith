﻿using BlacksmithBusinessLogic.BusinessLogics;
using BlacksmithBusinessLogic.Interfaces;
using BlacksmithListImplement.Implements;
using System;
using System.Windows.Forms;
using Unity.Lifetime;
using Unity;

namespace BlacksmithView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()//настройка контейнера
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IManufactureStorage, ManufactureStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ComponentLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ManufactureLogic>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}