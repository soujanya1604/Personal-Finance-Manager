﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Personal_Finance_Manager.Controllers
{
    public class SummaryController : Controller
    {
        // GET: SummaryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SummaryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SummaryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SummaryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SummaryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SummaryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SummaryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SummaryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
