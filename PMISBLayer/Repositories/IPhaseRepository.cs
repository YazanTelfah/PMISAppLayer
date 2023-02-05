using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
   public  interface IPhaseRepository
    {
        public List<Phase> GetAllPhases();
        public void InsertPhase(Phase phase);
        public void UpdatePhase(Phase phase);
        public Phase Find(int PhaseId);
        public void Delete(int PhaseId);
    }
}
