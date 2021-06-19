using BlacksmithBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BlacksmithBusinessLogic.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [Column(title: "Название", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string WarehouseName { get; set; }

        [Column(title: "ФИО ответсвенного", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ResponsiblePersonFCS { get; set; }

        [Column(title: "Дата создания", width: 100, format: "D")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
