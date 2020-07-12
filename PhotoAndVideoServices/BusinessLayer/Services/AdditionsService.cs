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
    public class AdditionsService : IAdditionsService
    {
        private IDataManager _dataManager;
        private IMapper _mapper;
        public AdditionsService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }
        public IEnumerable<AdditionDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<AdditionDTO>>(_dataManager.AdditionsRepository.GetAll());
        }

        public AdditionDTO GetById(int id)
        {
            return _mapper.Map<AdditionDTO>(_dataManager.AdditionsRepository.GetById(id));
        }

        public void Save(AdditionDTO additionDTO)
        {
            var addition = _mapper.Map<Additions>(additionDTO);
            _dataManager.AdditionsRepository.Save(addition);
        }
    }
}
