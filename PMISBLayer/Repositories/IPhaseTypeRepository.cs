using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
   public interface IPhaseTypeRepository
    {
        public List<PhaseType> GetAllPhaseTypes();
    }
}
