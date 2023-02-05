using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTO.ProjectDTO
{
    public class UpdateProjectDTO
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
        //  public string ProjectDescription { get; set; }
        public int ProjectTypeId { get; set; } //Forign key from Project Type
        public string ProjectManagerId { get; set; } //Forign key from Project Type
        
        public DateTime StartDate { get; set; } //the day start Of project
        public DateTime EndDate { get; set; } //THe day End of project
        public List<int> PhaseIds { get; set; }
        public int ProjectStatusId { get; set; }//Note:::Maybe Eror Must Be chek Name in Class //ForignKey From Projectstatus

        public double ContractAmount { get; set; }
        public IFormFile ContractFile { get; set; }
        // Data Annotation Custome Validation 

    }
}
