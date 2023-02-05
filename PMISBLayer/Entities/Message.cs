using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
   public class Message
    {
        public int MessageId { get; set; } //لازم يكون ايدنتيت 

        public string MessageName{ get; set; }

        public string MessageContact { get; set; }

        public string MessageDescription { get; set; }


    }
}
