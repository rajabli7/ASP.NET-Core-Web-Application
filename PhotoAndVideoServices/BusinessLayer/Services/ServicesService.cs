using AutoMapper;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class ServiceService: IServicesService
    {
        private IDataManager _dataManager;
        private IMapper _mapper;

        public ServiceService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _dataManager.ServicesRepository.Delete(id);
        }

        public IEnumerable<AdditionDTO> GetAdditions(int id)
        {
            return _mapper.Map<IEnumerable<AdditionDTO>>(_dataManager.ServicesRepository.GetAdditions(id));
        }

        public ServiceDTO GetById(int id)
        {
            return _mapper.Map<ServiceDTO>(_dataManager.ServicesRepository.GetById(id));
        }

        public void Save(ServiceDTO serviceDTO)
        {
            var service = _mapper.Map<DataLayer.Entities.Services>(serviceDTO);
            
            _dataManager.ServicesRepository.Save(service);
        }

        public void DeleteAdditions(int id)
        {
            _dataManager.ServicesRepository.DeleteAdditions(id);
        }
    }
}
