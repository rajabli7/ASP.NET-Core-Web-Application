using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IDataManager
    {
        IServiceTypesRepository ServiceTypesRepository { get; }
        IServicesRepository ServicesRepository { get; }
        IDepartmentsRepository DepartmentsRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        IUsersRepository UsersRepository { get; }
        IAdditionsRepository AdditionsRepository { get; }
    }
}
