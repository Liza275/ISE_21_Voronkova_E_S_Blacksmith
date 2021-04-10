using System.ComponentModel;
using System.Runtime.Serialization;

namespace BlacksmithBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Полное имя")]
        public string ClientFIO { get; set; }

        [DataMember]
        [DisplayName("Почта")]
        public string Email { get; set; }

        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}