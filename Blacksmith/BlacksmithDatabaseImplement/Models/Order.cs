﻿using BlacksmithBusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlacksmithDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ManufactureId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        public virtual Manufacture Manufacture { get; set; }//

        public DateTime? DateImplement { get; set; }
    }
}
