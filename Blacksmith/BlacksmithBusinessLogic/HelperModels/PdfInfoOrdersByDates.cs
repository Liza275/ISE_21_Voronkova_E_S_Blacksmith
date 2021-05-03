using BlacksmithBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BlacksmithBusinessLogic.HelperModels
{
    public class PdfInfoOrdersByDates
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportOrderByDatesViewModel> Orders { get; set; }
    }
}
