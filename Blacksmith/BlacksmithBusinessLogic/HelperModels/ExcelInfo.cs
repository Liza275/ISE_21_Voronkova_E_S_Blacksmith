using System;
using System.Collections.Generic;
using System.Text;
using BlacksmithBusinessLogic.ViewModels;

namespace BlacksmithBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportComponentManufactureViewModel> ComponentManufactures { get; set; }
    }
}