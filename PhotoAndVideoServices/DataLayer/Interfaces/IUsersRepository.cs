using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IUsersRepository
    {
        void Save(Users user);
        Users GetById(int userId);
        bool IsAdministrator(int userId);
        bool IsEmployee(int userId);
        bool IsClient(int userId);
        Users CheckUser(string login);
        int GetRoleId(int userId);
        List<Users> GetPosibleEmployees();
        IEnumerable<Orders> GetOrdersForClient(int userId);
        IEnumerable<Orders> GetOrdersForEmployee(int userId);
    }
}
