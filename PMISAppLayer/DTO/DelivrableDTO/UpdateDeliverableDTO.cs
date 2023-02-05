using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTO
{
    public class UpdateDeliverableDTO
    {
        public int DeliverableId { get; set; }
        public string DeliverableDescription { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndtDate { get; set; }
        public int ProjectPhaseId { get; set; } //PrimaryKey from Project Phase
        public ProjectPhase ProjectPhase { get; set; }

    }
}
