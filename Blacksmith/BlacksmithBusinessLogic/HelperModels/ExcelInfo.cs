using System.Collections.Generic;
using BlacksmithBusinessLogic.ViewModels;

namespace BlacksmithBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportComponentManufactureViewModel> ComponentManufactures { get; set; }

        public List<ReportWarehouseComponentViewModel> Warehouses { get; set; }
    }
}