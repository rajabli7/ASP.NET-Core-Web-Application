using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class DataManager : IDataManager
    {
        public IServiceTypesRepository ServiceTypesRepository { get; }
        public IServicesRepository ServicesRepository { get; }
        public IDepartmentsRepository DepartmentsRepository { get; }
        public IOrdersRepository OrdersRepository { get; }
        public IUsersRepository UsersRepository { get; }
        public IAdditionsRepository AdditionsRepository { get; }

        public DataManager(IServiceTypesRepository serviceTypesRepository, IServicesRepository servicesRepository, IDepartmentsRepository departmentsRepository,
            IOrdersRepository ordersRepository, IUsersRepository usersRepository, IAdditionsRepository additionsRepository)
        {
            ServicesRepository = servicesRepository;
            ServiceTypesRepository = serviceTypesRepository;
            DepartmentsRepository = departmentsRepository;
            OrdersRepository = ordersRepository;
            UsersRepository = usersRepository;
            AdditionsRepository = additionsRepository;
        }
    }
}
