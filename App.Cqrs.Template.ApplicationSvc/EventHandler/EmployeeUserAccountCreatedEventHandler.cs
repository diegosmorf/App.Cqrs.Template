﻿using App.Cqrs.Core.Event;
using App.Cqrs.Template.ApplicationSvc.ReadModel;
using App.Cqrs.Template.Core.Repository;
using App.Template.Domain.Event;
using System.Linq;

namespace App.Cqrs.Template.ApplicationSvc.CommandHandler
{
    public class EmployeeUserAccountCreatedEventHandler : IEventHandler<EmployeeCreated>
    {
        private readonly IRepository<EmployeeUserAccountReadModel> employeeRepository;
        public EmployeeUserAccountCreatedEventHandler(IRepository<EmployeeUserAccountReadModel> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Handle(EmployeeCreated @event)
        {
            var count = employeeRepository.All().Count();

            var userAccount = @event.Name.Split(' ')[0].ToLower() + count.ToString();

            employeeRepository.Insert(new EmployeeUserAccountReadModel
            {
                Id = @event.Id,
                Name = @event.Name,
                UserAccount = userAccount                
            });
        }
    }
}