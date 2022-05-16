using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}
