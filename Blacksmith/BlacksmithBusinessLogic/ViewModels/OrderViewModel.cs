using BlacksmithBusinessLogic.Attributes;
using BlacksmithBusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace BlacksmithBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        [Column(title: "Номер", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int ManufactureId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }

        [DataMember]
        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Исполнитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }

        [DataMember]
        [Column(title: "Изделие", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ManufactureName { get; set; }

        [DataMember]
        [Column(title: "Количество", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int Count { get; set; }

        [DataMember]
        [Column(title: "Сумма", gridViewAutoSize: GridViewAutoSize.Fill)]
        public decimal Sum { get; set; }

        [DataMember]
        [Column(title: "Статус", gridViewAutoSize: GridViewAutoSize.Fill)]
        public OrderStatus Status { get; set; }

        [DataMember]
        [Column(title: "Дата создания", gridViewAutoSize: GridViewAutoSize.Fill, format: "D")]
        public DateTime DateCreate { get; set; }

        [DataMember]
        [Column(title: "Дата выполнения", gridViewAutoSize: GridViewAutoSize.Fill, format: "D")]
        public DateTime? DateImplement { get; set; }
    }
}