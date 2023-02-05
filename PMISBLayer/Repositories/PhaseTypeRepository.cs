using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
   public class PhaseTypeRepository: IPhaseTypeRepository
    {
        private readonly ApplicationDbContext Context1;
        public PhaseTypeRepository(ApplicationDbContext context1)
        {
            this.Context1 = context1;
        }

        public  List<PhaseType> GetAllPhaseTypes()
        {

            return Context1.PhaseTypes.ToList();
        }
    }
}
