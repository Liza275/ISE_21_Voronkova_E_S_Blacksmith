using System.ComponentModel.DataAnnotations;

namespace BlacksmithDatabaseImplement.Models
{
    public class ManufactureComponent
    {
        public int Id { get; set; }
        public int ManufactureId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Manufacture Manufacture { get; set; }
    }
}
