using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    public class ProjectPhaseController : Controller
    {
        private readonly IProjectPhaseRepository projectPhaseRepository;
        private readonly ApplicationDbContext _context;

        public ProjectPhaseController(IProjectPhaseRepository projectPhaseRepository, ApplicationDbContext context)
        {
            this.projectPhaseRepository = projectPhaseRepository;
            _context = context;
        }
        public IActionResult Index(int id )
        {
            var res = _context.ProjectPhases.Include(e => e.Project).Include(q => q.Phase).Where(e=>e.ProjectId==id).ToList();
            //var item = projectPhaseRepository.GetAllProjectPhasesForProject(id);

            var project = _context.Projects.SingleOrDefault(b=>b.ProjectId==id);
            ViewBag.project = project;

            
            return View(res);
        }
        public IActionResult NewPhase(int id)
        {
            var project = _context.Projects.SingleOrDefault(r=>r.ProjectId==id);
            ViewBag.project = project;
            var phases = _context.Phases.ToList();
            ViewBag.phases = phases;
            var res = _context.ProjectPhases.Include(e => e.Project).Include(q => q.Phase).Where(e => e.ProjectId == id).ToList();
            ViewBag.pPhase = res;
            //var pphase = _context.ProjectPhases.Where(q => q.ProjectId == project.ProjectId).ToList();
            //project.ProjectPhases = pphase;
            //foreach(var item in project.ProjectPhases)
            //{

            //}
            return View();
        }
        public IActionResult CreateProjectPhase(ProjectPhase projectPhase)
        {
            _context.ProjectPhases.Add(projectPhase);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdatePhase(int id)
        {
            var pPhase = _context.ProjectPhases.Include(v=>v.Project).Include(e=>e.Phase).SingleOrDefault(q => q.ProjectPhaseId == id);
            return View(pPhase);
        }

        public IActionResult Update(ProjectPhase projectPhase)
        {
            projectPhaseRepository.UpdateProjectPhase(projectPhase);
            projectPhaseRepository.SaveData();
            return RedirectToAction(nameof(Index),new { id= projectPhase.ProjectId});
        }
        // delete
        public IActionResult Delete(int id)
        {
            var phase = projectPhaseRepository.Find(id);
            projectPhaseRepository.Delete(id);
            return RedirectToAction("Index", new { id= phase .ProjectId});
        }
    }
}
