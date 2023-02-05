using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IDeliverableRepository
    {
        public List<Deliverable> GetAllDeliverables();
        public List<Deliverable> GetAllDeliverablesByProjectManager(string id);

        public void InsertDeliverable(Deliverable deliverable);

        public void UpdateDeliverable(Deliverable deliverable);

        public Deliverable Find(int DeliverableId);

        public void Delete(int id);


    }
}
