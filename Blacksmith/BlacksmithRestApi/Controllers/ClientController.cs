using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.BusinessLogics;
using BlacksmithBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BlacksmithRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ClientController : ControllerBase
    {
        private readonly ClientLogic _logic;

        private readonly MailLogic _logicMail;

        private readonly int _passwordMaxLength = 50;

        private readonly int _passwordMinLength = 10;

        private readonly int mailsOnPage = 2;

        public ClientController(ClientLogic logic, MailLogic logicMail)
        {
            _logic = logic;
            _logicMail = logicMail;
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password) => _logic.Read(new ClientBindingModel { Email = login, Password = password })?[0];

        [HttpPost]
        public void Register(ClientBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpGet]
        public (List<MessageInfoViewModel>, bool) GetMessages(int clientId, int page)
        {
            var list = _logicMail.Read(new MessageInfoBindingModel { ClientId = clientId, Skip = (page - 1) * mailsOnPage, Take = mailsOnPage + 1 }).ToList();
            var hasNext = !(list.Count() <= mailsOnPage);
            return (list.Take(mailsOnPage).ToList(), hasNext);
        }

        [HttpPost]
        public void UpdateData(ClientBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }

        private void CheckData(ClientBindingModel model)
        {
            if (!Regex.IsMatch(model.Email, @"regular expression"))
            {
                throw new Exception("В качестве логина должна быть указана почта");
            }
            if (model.Password.Length > _passwordMaxLength || model.Password.Length < _passwordMinLength || !Regex.IsMatch(model.Password,
           @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
            {
                throw new Exception($"Пароль длиной от {_passwordMinLength} до {_passwordMaxLength }" +
                    $" должен состоять и из цифр, букв и небуквенных символов");
            }
        }

    }
}