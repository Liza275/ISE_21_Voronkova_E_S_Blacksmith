using System.Collections.Generic;
using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.ViewModels;

namespace BlacksmithBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
    }
}