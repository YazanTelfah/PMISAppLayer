using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTO
{
    public class CreateorUpdatePhaseDTO
    {
        public int PhaseId { get; set; }
        public string PhaseName { get; set; }
        public List<ProjectPhase> ProjectPhases { get; set; }

    }
}
