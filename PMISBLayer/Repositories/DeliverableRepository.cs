using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
   public class DeliverableRepository : IDeliverableRepository
    {
        private readonly ApplicationDbContext Con;
        public DeliverableRepository(ApplicationDbContext context)
        {
            this.Con = context;

        }

        public List<Deliverable> GetAllDeliverables()
        {
          
            return Con.Deliverables
                .Include(e => e.ProjectPhase)
                .Include(t => t.ProjectPhase.Phase)
                .Include(q => q.ProjectPhase.Project)
                .ToList();
        }

        public void InsertDeliverable(Deliverable deliverable)
        {
            Con.Deliverables.Add(deliverable);
            Con.SaveChanges();
        }
        public void UpdateDeliverable(Deliverable deliverable)
        {
            Con.Deliverables.Update(deliverable);
            Con.SaveChanges();
        }

        public Deliverable Find(int DeliverableId)
        {
            //
            return Con.Deliverables
                .Include(e=>e.ProjectPhase)
                .Include(t=>t.ProjectPhase.Phase)
                .Include(q=>q.ProjectPhase.Project)
                .SingleOrDefault(x => x.DeliverableId == DeliverableId);
        }
        public void Delete(int id)
        {
            var dev = Find(id);
            Con.Deliverables.Remove(dev);
            Con.SaveChanges();
        }

        public List<Deliverable> GetAllDeliverablesByProjectManager(string id)
        {
            return Con.Deliverables
                .Include(e => e.ProjectPhase)
                .Include(t => t.ProjectPhase.Phase)
                .Include(q => q.ProjectPhase.Project)
                .Where(q => q.ProjectPhase.Project.ProjectManagerId == id)
                .ToList();
        }
    }
}
