using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
   public  class PhaseRepository : IPhaseRepository
    {
        private readonly ApplicationDbContext Con1;
        public PhaseRepository(ApplicationDbContext context)
        {
            this.Con1 = context;

        }

        public List<Phase>  GetAllPhases()
        {
            return Con1.Phases.ToList();
        }

        public void InsertPhase(Phase phase)
        {
            Con1.Phases.Add(phase);
            Con1.SaveChanges();
        }
        public void UpdatePhase(Phase phase)
        {
            Con1.Phases.Update(phase);
            Con1.SaveChanges();
        }

        public Phase Find(int PhaseId)
        {
            return Con1.Phases.SingleOrDefault(x => x.PhaseId == PhaseId);
        }
        public void Delete(int PhaseId)
        {
            var phase = Find(PhaseId);
            Con1.Phases.Remove(phase);
            Con1.SaveChanges();
        }


    }
}
