using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTO.ProjectDTO
{
    public class InsertProjectDTO
    {
        [Required]
        public string ProjectName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public int ProjectTypeId { get; set; }
        public int ProjectStatusId { get; set; }
        public List<int> PhasesIds { get; set; }
        [Required]
        public decimal ContractAmount { get; set; }
        public IFormFile ContractFile { get; set; }
    }
}
