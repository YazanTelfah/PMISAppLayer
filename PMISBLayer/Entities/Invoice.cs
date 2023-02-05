using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
   public class Invoice
    {
        public int InvoiceId { get; set; }

        public string InvoiceName { get; set; }

        public DateTime InvoiceDate { get; set; }

        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }

    }
}
