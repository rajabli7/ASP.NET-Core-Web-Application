using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IAdditionsRepository
    {
        void Save(Additions addition);
        Additions GetById(int id);
        IEnumerable<Additions> GetAll();
    }
}
