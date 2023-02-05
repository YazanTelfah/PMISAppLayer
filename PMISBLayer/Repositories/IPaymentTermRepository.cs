using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
   public interface IPaymentTermRepository
    {
        public List<PaymentTerm> GetAllPaymentTerm();

        public void InsertPaymentTerm(PaymentTerm payment);

        public void UpdatePaymentTerm(PaymentTerm Payment);

        public PaymentTerm Find(int paymentTermId);


        public void Delete(int PaymentTermId);


    }
}
