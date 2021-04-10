using System;
using System.Collections.Generic;
using System.Text;
using BlacksmithBusinessLogic.ViewModels;

namespace BlacksmithBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ManufactureViewModel> Manufactures { get; set; }
    }
}