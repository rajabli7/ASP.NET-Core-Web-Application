using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class ServiceManager : IServiceManager
    {
        public IServiceTypesService ServiceTypesService { get; }
        public IDepartmentsService DepartmentsService { get; }
        public IOrdersService OrdersService { get; }
        public IUsersService UsersService { get; }
        public IServicesService ServicesService { get; }
        public IAdditionsService AdditionsService { get; }

        public ServiceManager(IServiceTypesService serviceTypesService, IDepartmentsService departmentsService, 
            IOrdersService ordersService, IUsersService usersService, IServicesService servicesService, IAdditionsService additionsService)
        {
            ServicesService = servicesService;
            DepartmentsService = departmentsService;
            OrdersService = ordersService;
            UsersService = usersService;
            ServiceTypesService = serviceTypesService;
            AdditionsService = additionsService;
        }
    }
}
