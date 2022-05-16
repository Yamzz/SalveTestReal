﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FileReader
{
    public interface IFileReader
    {
        IEnumerable<Clinic> GetAllClinics();
        IEnumerable<Patient> GetAllPatients();
    }
}
