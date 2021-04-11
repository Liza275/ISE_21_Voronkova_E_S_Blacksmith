using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace BlacksmithBusinessLogic.Interfaces
{
    public interface IManufactureStorage
    {
        List<ManufactureViewModel> GetFullList();
        List<ManufactureViewModel> GetFilteredList(ManufactureBindingModel model);
        ManufactureViewModel GetElement(ManufactureBindingModel model);
        void Insert(ManufactureBindingModel model);
        void Update(ManufactureBindingModel model);
        void Delete(ManufactureBindingModel model);
    }
}