using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithBusinessLogic.ViewModels
{
    public class ReportComponentManufactureViewModel
    {
        public string ManufactureName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Components { get; set; }
    }
}