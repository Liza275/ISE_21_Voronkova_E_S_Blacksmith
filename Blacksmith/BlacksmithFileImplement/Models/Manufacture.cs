﻿using System.Collections.Generic;

namespace BlacksmithFileImplement.Models
{
	public class Manufacture
	{
		public int Id { get; set; }
		public string ManufactureName { get; set; }
		public decimal Price { get; set; }
		public Dictionary<int, int> ManufactureComponents { get; set; }
	}
}