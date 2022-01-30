using Microsoft.AspNetCore.Mvc;
using Portfolio_Fatnis.Interfaces.Services;
using Portfolio_Fatnis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Controllers
{
    public class OperationSystemController : Controller
    {
        private readonly IOperationSystemService _operationSystemService;

        public OperationSystemController(IOperationSystemService operationSystemService)
        {
            _operationSystemService = operationSystemService;
        }
        public IActionResult Index()
        {
            List<OperationSystem> os = _operationSystemService.FindAll().ToList();
            return View(os);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OperationSystem model)
        {
            if (ModelState.IsValid)
            {
                await _operationSystemService.Create(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            OperationSystem os = _operationSystemService.FindById(Id);
            if (os != null)
            {
                return View(os);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(OperationSystem model)
        {
            if (ModelState.IsValid)
            {
                await _operationSystemService.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult> Delete(int Id)
        {
            bool result = await _operationSystemService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
