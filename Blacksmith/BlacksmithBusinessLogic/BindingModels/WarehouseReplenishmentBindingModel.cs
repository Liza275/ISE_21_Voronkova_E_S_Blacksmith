﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithBusinessLogic.BindingModels
{
   public class WarehouseReplenishmentBindingModel
    {
        public int ComponentId { get; set; }

        public int WarehouseId { get; set; }

        public int Count { get; set; }
    }
}