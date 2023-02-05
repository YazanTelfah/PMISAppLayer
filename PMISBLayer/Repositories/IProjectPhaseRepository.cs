using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PMISBLayer.Repositories
{
    public interface IProjectPhaseRepository
    {
        public List<ProjectPhase> GetAllProjectPhases();
        public List<ProjectPhase> GetAllProjectPhasesForProject(int id);

        public void InsertProjectPhase(ProjectPhase projectPhase);
        public List<ProjectPhase> FindAllByCondition(Expression<Func<ProjectPhase, bool>> predicate);
        public void UpdateProjectPhase(ProjectPhase projectPhase);
        public ProjectPhase Find(int projectPhaseId);
        public void SaveData();
        public void Delete(int projectPhaseId);
     


    }
}
