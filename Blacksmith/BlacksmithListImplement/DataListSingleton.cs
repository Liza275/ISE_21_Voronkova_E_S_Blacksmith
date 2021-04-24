using BlacksmithListImplement.Models;
using System.Collections.Generic;


namespace BlacksmithListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Manufacture> Manufactures { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        private DataListSingleton()//общее хранилище
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Manufactures = new List<Manufacture>();
            Warehouses = new List<Warehouse>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
