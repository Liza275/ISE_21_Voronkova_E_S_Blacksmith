using BlacksmithBusinessLogic.Attributes;
using System.ComponentModel;

namespace BlacksmithBusinessLogic.ViewModels
{
    // Исполнитель, выполняющий заказы
    public class ImplementerViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "Имя исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }

        [Column(title: "Время на заказ", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int WorkingTime { get; set; }

        [Column(title: "Время на отдых", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int PauseTime { get; set; }
    }
}