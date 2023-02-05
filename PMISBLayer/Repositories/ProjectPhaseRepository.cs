using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PMISBLayer.Repositories
{
   public class ProjectPhaseRepository:IProjectPhaseRepository
    {

        private readonly ApplicationDbContext Con;
        public ProjectPhaseRepository(ApplicationDbContext context)
        {
            this.Con = context;

        }

        public List<ProjectPhase> GetAllProjectPhases()
        {

            return Con.ProjectPhases.Include(t => t.Project).Include(o => o.Phase).ToList();
        }

        public void InsertProjectPhase(ProjectPhase projectPhase)
        {
            Con.ProjectPhases.Add(projectPhase);
        }
        public void UpdateProjectPhase(ProjectPhase projectPhase)
        {
            Con.ProjectPhases.Update(projectPhase);
            Con.SaveChanges();
        }

        public ProjectPhase Find(int projectPhaseId)
        {
            return Con.ProjectPhases.Include(t => t.Project).Include(o => o.Phase).SingleOrDefault(x => x.ProjectPhaseId == projectPhaseId);
        }
        public void Delete(int projectPhaseId)
        {
            var projectPhase = Find(projectPhaseId);
            Con.ProjectPhases.Remove(projectPhase);
            Con.SaveChanges();
        }

        public void SaveData()
        {
            Con.SaveChanges();
        }

        public List<ProjectPhase> GetAllProjectPhasesForProject(int id)
        {
            return Con.ProjectPhases.Include(t=>t.Project).Include(o=>o.Phase).Where(x=>x.ProjectId==id).ToList();
        }

        public List<ProjectPhase> FindAllByCondition(Expression<Func<ProjectPhase, bool>> predicate)
        {
            return Con.ProjectPhases.Where(predicate).ToList();
        }
    }
}
