using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio_Fatnis.Data;
using Portfolio_Fatnis.Interfaces.Services;
using Portfolio_Fatnis.Models;
using Portfolio_Fatnis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Controllers
{
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;
        private readonly IProjectService _projectService;
        private readonly IOperationSystemService _operationSystemService;
        private readonly IMapper _mapper;


        public ProjectController(PortfolioContext context, IMapper mapper, IProjectService projectService, IOperationSystemService operationSystemService)
        {
            _context = context;
            _mapper = mapper;
            _projectService = projectService;
            _operationSystemService = operationSystemService;
        }
        public async Task<IActionResult> Index()
        {
            List<Project> project = await _projectService.FindAll();
            return View(project);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> selectListItems = await _operationSystemService.SelectListItems();
            ViewBag.OperSys = selectListItems;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel model1)
        {
            if (ModelState.IsValid)
            {
                var result = await _projectService.Create(model1);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model1);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            List<SelectListItem> selectListItems = await _operationSystemService.SelectListItems();
            ViewBag.OperSys = selectListItems;

            Project project = await _projectService.FindById(Id);

            if (project != null)
            {
                ProjectViewModel model = _mapper.Map<ProjectViewModel>(project);
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectViewModel model1)
        {
            if (ModelState.IsValid)
            {
                var result = await _projectService.Update(model1);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model1);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            Project product = await _projectService.FindById(Id);
            if (product != null)
            {
               
                return View(product);
            }
            else
            {
                return NotFound();
            }

        }

        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _projectService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
