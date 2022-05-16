using DataAccess.FileReader;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class PatientService : IPatientService
    {
        public IFileReader _fileReader { get; set; }
        public PatientService(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IEnumerable<Patient> GetAll()
        {
           return _fileReader.GetAllPatients();
        }
    }
}
