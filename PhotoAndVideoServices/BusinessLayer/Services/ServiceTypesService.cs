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
    public class ServiceTypessService : IServiceTypesService
    {
        private IDataManager _dataManager;
        private IMapper _mapper;

        public ServiceTypessService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public ServiceTypeDTO GetById(int id)
        {
            return _mapper.Map<ServiceTypeDTO>(_dataManager.ServiceTypesRepository.GetById(id));
        }

        public IEnumerable<ServiceTypeDTO> GetAll()
        {
            return _mapper.Map<List<ServiceTypeDTO>>(_dataManager.ServiceTypesRepository.GetAll());
        }

        public ServiceTypeDTO GetWithServices(int id)
        {
            var serviceTypeDTO = _mapper.Map<ServiceTypeDTO>(_dataManager.ServiceTypesRepository.GetWithServices(id));

            foreach (var serviceDTO in serviceTypeDTO.Services)
            {
                serviceDTO.Additions = 
                    _mapper.Map<List<AdditionDTO>>(_dataManager.ServicesRepository.GetAdditions(serviceDTO.Id));
            }

            return serviceTypeDTO;
        }

        public IEnumerable<ServiceDTO> GetServices(int id)
        {
            return _mapper.Map<List<ServiceDTO>>(_dataManager.ServiceTypesRepository.GetServices(id));
        }
    }
}
