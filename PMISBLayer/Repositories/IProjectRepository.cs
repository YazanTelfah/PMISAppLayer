using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMISBLayer.Repositories
{
    public interface IProjectRepository
    {
        public List<Project> GetAllProjects(string userid);

        public List<Project> GetManagerProjects(string userId);
        public List<Project> GetAAdminProjects();

        //public /*async Task */int InsertProject(InsertProjectDTO insertProjectDTO);
        public void InsertProject(Project project);
        public void UpdateProject(Project project);
        public void Delete(int ProjectId);
        public Project Find(int ProjectId);



    }

}
