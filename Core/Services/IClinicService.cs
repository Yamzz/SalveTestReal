using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IClinicService
    {
        IEnumerable<Clinic> GetAll();
    }
}
