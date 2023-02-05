
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTO
{
    public class CreateMessageDTO
    {
        public int MessageId { get; set; }

        public string MessageName { get; set; }

        public string MessageContact { get; set; }
        
        public string MessageDescription { get; set; }
    }
}
