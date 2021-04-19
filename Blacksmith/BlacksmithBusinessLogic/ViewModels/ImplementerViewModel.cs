using System.ComponentModel;

namespace BlacksmithBusinessLogic.ViewModels
{
    public class ImplementerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Имя исполнителя")]
        public string ImplementerFIO { get; set; }

        [DisplayName("Время на заказ")]
        public int WorkingTime { get; set; }

        [DisplayName("Время на отдых")]
        public int PauseTime { get; set; }
    }
}