using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
    public class Project
    {

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        //  public string ProjectDescription { get; set; }
        public int ProjectTypeId { get; set; } //Forign key from Project Type
        public ProjectType ProjectType { get; set; } //Forign key from Project Type

        public DateTime StratDate { get; set; } //the day start Of project
        public DateTime EndDate { get; set; } //THe day End of project

        public int ProjectStatusId { get; set; }//Note:::Maybe Eror Must Be chek Name in Class //ForignKey From Projectstatus
        public ProjectStatus ProjectStatus { get; set; }//ForignKey From Projectstatus

        public List<ProjectPhase> ProjectPhases { get; set; }

        public double ContractAmount { get; set; }

        public string ContractFileName { get; set; }
        public string ContractFileType { get; set; }
        public byte[] ContractFile { get; set; }

        public string ProjectManagerId { get; set; }
        public ProjectManager ProjectManager { get; set; }

    }
}
