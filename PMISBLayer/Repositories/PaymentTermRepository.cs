using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
  public  class PaymentTermRepository : IPaymentTermRepository
    {


        private readonly ApplicationDbContext Con;
            public PaymentTermRepository(ApplicationDbContext context)
            {
                this.Con = context;

            }

        public List<PaymentTerm> GetAllPaymentTerm()
            {
                return Con.PaymentTerms
                .Include(r => r.Deliverable)
                .Include(b => b.Deliverable.ProjectPhase)
                .Include(m => m.Deliverable.ProjectPhase.Project)
                .Include(h => h.Deliverable.ProjectPhase.Phase)
                .ToList();
            }

        public void InsertPaymentTerm(PaymentTerm payment)
            {
                Con.PaymentTerms.Add(payment);
                Con.SaveChanges();
            }
      
        public void UpdatePaymentTerm(PaymentTerm Payment)

            {
                Con.PaymentTerms.Update(Payment);
                Con.SaveChanges();
            }

        public PaymentTerm Find(int paymentTermId)

            {
                var res= Con.PaymentTerms
                .Include(r=>r.Deliverable)
                .Include(b=>b.Deliverable.ProjectPhase)
                .Include(m=>m.Deliverable.ProjectPhase.Project)
                .Include(h=>h.Deliverable.ProjectPhase.Phase)
                .SingleOrDefault(x => x.PaymentTermId == paymentTermId);
            return res;
            }

         public void Delete(int PaymentTermId)
            {
                var pay = Find(PaymentTermId);
                Con.PaymentTerms.Remove(pay);
                Con.SaveChanges();
            }



    }
    }

