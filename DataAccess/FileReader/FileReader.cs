using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataAccess.FileReader
{
    public class FileReader : IFileReader
    {
        public const string ClinicsFileName = "clinics";
        public const string PatientsOneFileName = "patients-1";
        public const string PatientsTwoFileName = "patients-2";
        public const char CommarDelimiter = ',';

        public FileReader()
        {
        }

        public IEnumerable<Clinic> GetAllClinics()
        {
            List<Clinic> clinics = new List<Clinic>();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"Data\{ClinicsFileName}.csv");
            var lines = File.ReadAllLines(path).ToList();

            foreach (string line in lines.Skip(1))
            {
                string[] clinicData = line.Split(CommarDelimiter);

                clinics.Add(new Clinic
                {
                     Id = int.Parse(clinicData[0]),
                     Name = clinicData[1]
                });
            }

            return clinics;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            List<string> patientFiles = new List<string>
            {
                 PatientsOneFileName, PatientsTwoFileName
            };

            foreach (var patientFileName in patientFiles)
            {
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"Data\{patientFileName}.csv");
                var lines = File.ReadAllLines(path).ToList();

                foreach (string line in lines.Skip(1))
                {
                    string[] patientData = line.Split(CommarDelimiter);

                    patients.Add(new Patient
                    {
                        Id = int.Parse(patientData[0]),
                        ClinicId = int.Parse(patientData[1]),
                        FirstName = patientData[2],
                        LastName = patientData[3],
                        DateOfBirth = patientData[4]
                    });
                }
            }

            return patients;
        }
    }
}
