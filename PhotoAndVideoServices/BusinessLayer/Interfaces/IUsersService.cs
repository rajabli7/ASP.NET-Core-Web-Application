using BusinessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUsersService
    {
        void Save(UserDTO user);
        UserDTO GetById(int userId);
        bool IsAdministrator(int userId);
        bool IsEmployee(int userId);
        bool IsClient(int userId);
        UserDTO CheckUser(string login);
        int GetRoleId(int userId);
        List<UserDTO> GetPosibleEmployes();
        IEnumerable<OrderDTO> GetOrdersForClient(int userId);
        IEnumerable<OrderDTO> GetOrdersForEmployee(int userId);
    }
}
