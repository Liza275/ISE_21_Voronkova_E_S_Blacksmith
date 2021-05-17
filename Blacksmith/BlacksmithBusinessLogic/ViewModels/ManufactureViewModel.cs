using BlacksmithBusinessLogic.Attributes;
using System.Collections.Generic;
using System.ComponentModel;
namespace BlacksmithBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class ManufactureViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ManufactureName { get; set; }
        [Column(title: "Стоимость", width: 100)]
        public decimal Price { get; set; }
        [Column(visible: false)]
        public Dictionary<int, (string, int)> ManufactureComponents { get; set; }
    }
}