﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppsBeginner2.Data;
using WebAppsBeginner2.Models;

namespace WebAppsBeginner2.Controllers
{
    public class ExpenseController : Controller
    {
            private readonly ApplicationDBContext _db;

            public ExpenseController(ApplicationDBContext db)
            {
                _db = db;
            }
            public IActionResult Index()
            {
                IEnumerable<Expense> objList = _db.Expenses;
                return View(objList);
            }

            //GET-Create
            public IActionResult Create()
            {
                return View();
            }

            //POST-Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Expense obj)
            {
                if(ModelState.IsValid)
                {
                    _db.Expenses.Add(obj);
                    _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
                
            }

        //POST-Delete
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        //POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _db.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

                _db.Expenses.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

        }

    }
}
