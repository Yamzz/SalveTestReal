using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
    }
}
