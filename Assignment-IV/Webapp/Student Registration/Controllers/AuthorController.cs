using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StudentRegistration.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly StudentRegistrationDb _db;

        public AuthorController(ILogger<AuthorController> logger, StudentRegistrationDb db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            
            var author = _db.Authors.ToList();
            return View(author);

        }
           public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
           public IActionResult Add(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

         public IActionResult Delete(int Id)
        {
            var authorToUpdate = _db.Authors.FirstOrDefault(author => author.Id == Id);

            if(authorToUpdate == null){
                return NotFound();
            }

            return View(authorToUpdate);

        }

        [HttpPost]
        public IActionResult Delete(Author author)
        {
            _db.Authors.Remove(author);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public IActionResult Edit(int Id)
        {
            var authorToUpdate = _db.Authors.FirstOrDefault(author => author.Id == Id);

            if(authorToUpdate == null){
                return NotFound();
            }

            return View(authorToUpdate);

        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            _db.Authors.Update(author);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}