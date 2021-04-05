using System.Collections.Generic;

namespace BlacksmithBusinessLogic.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class ManufactureBindingModel
    {
        public int? Id { get; set; }
        public string ManufactureName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ManufactureComponents { get; set; }
    }
}