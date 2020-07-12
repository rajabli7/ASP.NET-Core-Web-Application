using BusinessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IAdditionsService
    {
        void Save(AdditionDTO addition);
        AdditionDTO GetById(int id);
        IEnumerable<AdditionDTO> GetAll();
    }
}
