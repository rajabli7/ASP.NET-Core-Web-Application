using AutoMapper;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class DepartmentsService: IDepartmentsService
    {
        private IDataManager _dataManager;
        private IMapper _mapper;

        public DepartmentsService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public IEnumerable<DepartmentDTO> GetAll()
        {
            return _mapper.Map<List<DepartmentDTO>>(_dataManager.DepartmentsRepository.GetAll());
        }

    }
}
