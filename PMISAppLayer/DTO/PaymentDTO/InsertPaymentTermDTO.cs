using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTO.PaymentDTO
{
    public class InsertPaymentTermDTO
    {

        //public int PaymentTermId { get; set; }
        public string PaymentTermTitle { get; set; }
        public double PaymentTermAmount { get; set; }

        public int DeliverableId { get; set; }
        //public Deliverable Deliverable { get; set; }// without list
        //public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }
    }
}
