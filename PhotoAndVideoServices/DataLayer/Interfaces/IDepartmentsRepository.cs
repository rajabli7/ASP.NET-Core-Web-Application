using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IDepartmentsRepository
    {
        IEnumerable<Departments> GetAll();
    }
}
