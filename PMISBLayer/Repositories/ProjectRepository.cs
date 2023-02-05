using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;

using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PMISBLayer.Repositories
{
    public class ProjectRepository : IProjectRepository//Deal With The Data Base  #Single Responsepilty
    {
        private readonly ApplicationDbContext context; //securite Example:: Cannot be context=new Yazan();
        public ProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Project> GetAllProjects(string userid)
        {
            
            var item = context.Projects
                .Include(e => e.ProjectStatus)
                .Include(q => q.ProjectType)
                .Include(w => w.ProjectPhases)
                .ThenInclude(x => x.Phase)
               .Where(c => c.ProjectManagerId == userid)
                .ToList();
            return item;
        }
        public List<Project> GetManagerProjects(string userId)
        {
            return context.Projects.Where(x => x.ProjectManagerId == userId).ToList();
        }
        public List<Project> GetAAdminProjects()
        {
            var item = context.Projects
    .Include(e => e.ProjectStatus)
    .Include(q => q.ProjectType)
    .Include(w => w.ProjectPhases)
    .ThenInclude(x => x.Phase)
 
    .ToList();
            return item;
        }

        public void InsertProject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
        }
        public void UpdateProject(Project project)
        {
            context.Projects.Update(project);
            context.SaveChanges();
        }

        public Project Find(int ProjectId)
        {
            return context.Projects
                    .Include(e => e.ProjectStatus)
                    .Include(q => q.ProjectType)
                    .Include(w => w.ProjectPhases)
                .SingleOrDefault(x => x.ProjectId == ProjectId);
        }
        public void Delete(int ProjectId)
        {
            var project = Find(ProjectId);
            context.Projects.Remove(project);
            context.SaveChanges();
        }


    }
}
