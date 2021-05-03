using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BlacksmithBusinessLogic.Interfaces
{
    public interface IWarehouseStorage
    {
        List<WarehouseViewModel> GetFullList();

        List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model);

        WarehouseViewModel GetElement(WarehouseBindingModel model);

        void Insert(WarehouseBindingModel model);

        void Update(WarehouseBindingModel model);

        void Delete(WarehouseBindingModel model);

        bool CheckComponentsCount(int count, Dictionary<int, (string, int)> components);
    }
}
