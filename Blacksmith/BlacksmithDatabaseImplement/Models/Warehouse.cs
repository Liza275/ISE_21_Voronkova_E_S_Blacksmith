﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlacksmithDatabaseImplement.Models
{
    public class Warehouse
    {
        public int Id { get; set; }

        [Required]
        public string WarehouseName { get; set; }

        [Required]
        public string ResponsiblePersonFCS { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("WarehouseId")]
        public virtual List<WarehouseComponent> WarehouseComponents { get; set; }
    }
}