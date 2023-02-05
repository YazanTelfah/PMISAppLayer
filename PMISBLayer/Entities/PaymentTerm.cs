using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
    public class PaymentTerm
    {
        public int PaymentTermId { get; set; }
        public string PaymentTermTitle { get; set; }
        public double PaymentTermAmount { get; set; }

        public int DeliverableId { get; set; }
        public Deliverable Deliverable { get; set; }// without list


        
        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }

       
    



    }
}
