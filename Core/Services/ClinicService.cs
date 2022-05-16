using DataAccess.FileReader;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class ClinicService : IClinicService
    {
        public IFileReader _fileReader { get; set; }
        public ClinicService(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IEnumerable<Clinic> GetAll()
        {
            return _fileReader.GetAllClinics();
        }
    }
}
