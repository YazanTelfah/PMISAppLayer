using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
     public  class ProjectTypeRepository:IProjectTypeRepository
    {
        private readonly ApplicationDbContext Context1;
        public ProjectTypeRepository (ApplicationDbContext context1)
        {
            this.Context1 = context1;
        }
        public List<ProjectType> GetAllProjectTypes()
        {
            return Context1.ProjectType.ToList();
        }

    }
}
