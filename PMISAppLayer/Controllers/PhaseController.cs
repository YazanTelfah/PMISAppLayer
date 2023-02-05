using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;

namespace PMISAppLayer.Controllers
{
    public class PhaseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhaseRepository phaseRepository;
        public PhaseController(ApplicationDbContext context, IPhaseRepository phaseRepository)
        {
            _context = context;
            this.phaseRepository = phaseRepository;
        }

        // GET: Phase
        public IActionResult Index()
        {
            var phase = phaseRepository.GetAllPhases();
            return View(phase);
        }
        // GET: Phase/Create
        public IActionResult Create()
        {
            return View();
        }
        //overload => 2 same action name but differenrt parameter in smae class
        //override =>2 same action name and parameter in different class
        // POST: Phase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Phase phase)
        {
            if (ModelState.IsValid)
            {
                phaseRepository.InsertPhase(phase);
                return RedirectToAction(nameof(Index));
            }
            return View(phase);
        }

        // GET: Phase/Edit/5
        public IActionResult Edit(int id)
        {


            var phase = phaseRepository.Find(id);
            if (phase == null)
            {
                return NotFound();
            }
            return View(phase);
        }

        // POST: Phase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Phase phase)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    phaseRepository.UpdatePhase(phase);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhaseExists(phase.PhaseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(phase);
        }

        // GET: Phase/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            var phase = phaseRepository.Find(id);
            if (phase == null)
            {
                return NotFound();
            }

            return View(phase);
        }

        // POST: Phase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var phase = phaseRepository.Find(id);
            phaseRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        private bool PhaseExists(int id)
        {
            return _context.Phases.Any(e => e.PhaseId == id);
        }
    }
}
