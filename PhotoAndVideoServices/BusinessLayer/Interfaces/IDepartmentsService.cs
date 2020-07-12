using BusinessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IDepartmentsService
    {
        IEnumerable<DepartmentDTO> GetAll();
    }
}
