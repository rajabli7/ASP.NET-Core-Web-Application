using AutoMapper;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UsersService: IUsersService
    {
        private IDataManager _dataManager;
        private IMapper _mapper;

        public UsersService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public void Save(UserDTO userDTO)
        {
            var user = _mapper.Map<Users>(userDTO);
            _dataManager.UsersRepository.Save(user);
            userDTO.Id = user.Id;
        }

        public UserDTO GetById(int userId)
        {
            return _mapper.Map<UserDTO>(_dataManager.UsersRepository.GetById(userId));
        }

        public bool IsAdministrator(int userId)
        {
            return _dataManager.UsersRepository.IsAdministrator(userId);
        }

        public bool IsEmployee(int userId)
        {
            return _dataManager.UsersRepository.IsEmployee(userId);
        }

        public bool IsClient(int userId)
        {
            return _dataManager.UsersRepository.IsClient(userId);
        }

        public UserDTO CheckUser(string login)
        {
            return _mapper.Map<UserDTO>(_dataManager.UsersRepository.CheckUser(login));
        }

        public int GetRoleId(int userId)
        {
            return _dataManager.UsersRepository.GetRoleId(userId);
        }

        public List<UserDTO> GetPosibleEmployes()
        {
            return _mapper.Map<List<UserDTO>>(_dataManager.UsersRepository.GetPosibleEmployees());
        }

        public IEnumerable<OrderDTO> GetOrdersForClient(int userId)
        {
            return _mapper.Map<List<OrderDTO>>(_dataManager.UsersRepository.GetOrdersForClient(userId));
        }

        public IEnumerable<OrderDTO> GetOrdersForEmployee(int userId)
        {
            return _mapper.Map<List<OrderDTO>>(_dataManager.UsersRepository.GetOrdersForEmployee(userId));
        }
    }
}
