using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SammysAuto.Data;

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

        public IActionResult Index()
        {
            // show the list of all the service types in db
            return View(_db.ServiceTypes.ToList());
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