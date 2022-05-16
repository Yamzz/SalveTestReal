using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalveTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalveTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPatientService _patientService;
        private readonly IClinicService _clinicService;

        public HomeController(ILogger<HomeController> logger, IPatientService patientService, IClinicService clinicService)
        {
            _logger = logger;
            _patientService = patientService;
            _clinicService = clinicService;
        }

        public IActionResult Index(string sortOrder, string SelectOption)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var allPatients = _patientService.GetAll();
            var allClinics = _clinicService.GetAll();
            ViewBag.clinics = allClinics;

            // sort data
            switch (sortOrder)
            {
                case "name_desc":
                    allPatients = allPatients.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    allPatients = allPatients.OrderBy(s => s.DateOfBirth);
                    break;
                case "date_desc":
                    allPatients = allPatients.OrderByDescending(s => s.DateOfBirth);
                    break;
                default:  // Name ascending 
                    allPatients = allPatients.OrderBy(s => s.LastName);
                    break;
            }

            // filter data bu clinic ID
            allPatients = (SelectOption == null || int.Parse(SelectOption) == 0) ? allPatients : allPatients.Where(patients => patients.ClinicId == int.Parse(SelectOption));

            ViewBag.TotalPatients = allPatients.Count();

            return View(allPatients);
        }
    }
}
