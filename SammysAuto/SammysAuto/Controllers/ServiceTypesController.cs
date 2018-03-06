using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SammysAuto.Data;
using SammysAuto.Models;

namespace SammysAuto.Controllers
{
    public class ServiceTypesController : Controller
    {
        // 1. db object 
        private readonly ApplicationDbContext _db;

        // 2. constructor 
        public ServiceTypesController(ApplicationDbContext db)
        {
            this._db = db; 
        }

        // GET: ServiceTypes
        public IActionResult Index()
        {
            // show the list of all the service types in db
            return View(_db.ServiceTypes.ToList());
        }

        // GET: ServiceTypes/Create
        // show the Create view 
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        // POST: Services/Create
        // Creates the actual service type; used in the Create view 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            Console.Write("hit");
            // if any of the data you submitted('formData') does not fit the type of properties or their annotations of the given model type
            // in this case, if the Name is null the modelstate will not be valid
            if (ModelState.IsValid)
            {
                _db.Add(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); 
            }
            // if modelstate is not valid return back to the view with origianl service type
            // and will also display error message
            return View(serviceType); 
        }

        // 3. dispose _db 
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _db.Dispose(); 
            }
        }
    }
}