using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
   public class ProjectPhase
    {//ManyToMany Between Entity of project and Entity of Phase
        /* Must Be Unique 
         project id |  phase id
             1            1
             1            2
             2            1
             2            2
             2            1 Eror
             1            1 Eror
         */
        public int ProjectPhaseId { get; set; } //PrimaryKey 

        public int ProjectId { get; set; } //Unique

        public Project Project { get; set; }

        public int PhaseId { get; set; } //Unique

        public Phase Phase { get; set; }

        public DateTime StratDate { get; set; } //MUst be not less before the start date of Project &&
                                                //NOt larger than End Date Of Project
        public DateTime EndDate { get; set; } //THe day End of Phase

    }
}
