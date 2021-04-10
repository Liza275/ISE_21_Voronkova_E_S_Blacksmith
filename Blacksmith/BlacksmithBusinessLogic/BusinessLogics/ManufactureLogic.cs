using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.Interfaces;
using BlacksmithBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace BlacksmithBusinessLogic.BusinessLogics
{
    public class ManufactureLogic
    {
        private readonly IManufactureStorage _manufactureStorage;

        public ManufactureLogic(IManufactureStorage manufactureStorage)
        {
            _manufactureStorage = manufactureStorage;
        }

        public List<ManufactureViewModel> Read(ManufactureBindingModel model)
        {
            if (model == null)
            {
                return _manufactureStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ManufactureViewModel> { _manufactureStorage.GetElement(model) };
            }
            return _manufactureStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ManufactureBindingModel model)
        {
            var element = _manufactureStorage.GetElement(new ManufactureBindingModel
            {
                ManufactureName = model.ManufactureName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                _manufactureStorage.Update(model);
            }
            else
            {
                _manufactureStorage.Insert(model);
            }
        }
        public void Delete(ManufactureBindingModel model)
        {
            var element = _manufactureStorage.GetElement(new ManufactureBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _manufactureStorage.Delete(model);
        }
    }
}
