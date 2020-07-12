using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IServiceManager
    {
        IServiceTypesService ServiceTypesService { get; }
        IDepartmentsService DepartmentsService { get; }
        IOrdersService OrdersService { get; }
        IUsersService UsersService { get; }
        IServicesService ServicesService { get; }
        IAdditionsService AdditionsService { get; }
    }
}
