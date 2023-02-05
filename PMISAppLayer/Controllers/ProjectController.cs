using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMISAppLayer.DTO;
using PMISAppLayer.DTO.ProjectDTO;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {

        private readonly IProjectRepository projectRepo;
        private readonly IProjectTypeRepository projectTypeRepos;
        private readonly IProjectStatusRepository projectStatus;
        private readonly IPhaseRepository phaseRepository;
        private readonly IPhaseTypeRepository phaseType1;
        private readonly IProjectPhaseRepository projectPhaseRepo;
        private readonly IMapper Mapper;
        //private readonly ApplicationDbContext _db;

        public ProjectController (IProjectRepository projectRepo , IProjectTypeRepository projectTypeRepo
            , IProjectStatusRepository projectStatus ,IPhaseTypeRepository phaseType,IPhaseRepository phase , IMapper mapper, IProjectPhaseRepository projectPhase)
        {
            this.projectRepo = projectRepo;
            this.projectTypeRepos = projectTypeRepo;
            this.projectStatus = projectStatus;
            this.projectPhaseRepo = projectPhase;
            this.phaseRepository = phase;
            this.phaseType1 = phaseType;
            this.Mapper = mapper;
        }

        public IActionResult Index()
        {
            // project manager
            // Admin 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.project = projectRepo.GetAllProjects();

            ViewBag.project = projectRepo.GetAllProjects(userId);
            //ViewBag.project = projectRepo.GetManagerProjects(userId).ToList();
            return View();
        }        
    
            public FileStreamResult ViewContract(int projectid)
        {
            var project = projectRepo.Find(projectid);

            Stream stream = new MemoryStream(project.ContractFile);

            return new FileStreamResult(stream, project.ContractFileType);
        }

        public IActionResult DeleteProject(int ProjectId)
        {
            projectRepo.Delete(ProjectId);


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.projectStatus = projectStatus.GetAllProjects();
            ViewBag.projectType = projectTypeRepos.GetAllProjectTypes();
            ViewBag.phase = phaseRepository.GetAllPhases();
            return View();
        }
        [HttpPost]
        public IActionResult CraeteProject(InsertProjectDTO insertProjectDTO)
        {
            var entity = Mapper.Map<Project>(insertProjectDTO);

            entity.StratDate = insertProjectDTO.StartDate;
            entity.ContractFileName = insertProjectDTO.ContractFile.FileName;
            entity.ContractFileType = insertProjectDTO.ContractFile.ContentType;
            entity.ProjectManagerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (insertProjectDTO.ContractFile.Length > 0)
            {
                // File (PDF) -> OPen a connection => "Stream" -> BackEnd (Binary "01010101")-> Array Of Byts(Binary Reader)
                Stream st = insertProjectDTO.ContractFile.OpenReadStream(); //Open A chanel between Backend and the clint side => (Browser)
                using (BinaryReader br = new BinaryReader(st))//0101010101   //using== .open(),.close()
                {
                    var byteFile = br.ReadBytes((int)st.Length);
                    entity.ContractFile = byteFile;
                    projectRepo.InsertProject(entity);
                }
            }

            foreach (var item in insertProjectDTO.PhasesIds)
            {
                var projectPhases = new ProjectPhase()
                {
                    ProjectId = entity.ProjectId,
                    PhaseId=item
                };
               projectPhaseRepo.InsertProjectPhase(projectPhases);
            }
            projectPhaseRepo.SaveData();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var project = projectRepo.Find(id);
            ViewBag.project = project;
            ViewBag.projectStatus = projectStatus.GetAllProjects();
            ViewBag.projectType = projectTypeRepos.GetAllProjectTypes();
            ViewBag.phase = phaseRepository.GetAllPhases();
            return View();
        }

        public IActionResult UpdateProject(UpdateProjectDTO updateProjectDTO)
        {
            var project = projectRepo.Find(updateProjectDTO.ProjectId);
            var projphase = projectPhaseRepo.FindAllByCondition(t => t.ProjectId == project.ProjectId);
            if (updateProjectDTO.ContractFile == null)
            {
                project.ProjectName = updateProjectDTO.ProjectName;
                project.StratDate = updateProjectDTO.StartDate;
                project.EndDate = updateProjectDTO.EndDate;
                project.ProjectStatusId = updateProjectDTO.ProjectStatusId;
                project.ProjectTypeId = updateProjectDTO.ProjectTypeId;
                project.ProjectManagerId = updateProjectDTO.ProjectManagerId;
                project.ContractAmount = updateProjectDTO.ContractAmount;

                
                foreach(var item in projphase)
                {
                    
                    projectPhaseRepo.Delete(item.ProjectPhaseId);
                }
                foreach(var item in updateProjectDTO.PhaseIds)
                {
                    var pphase = new ProjectPhase();
                    pphase.ProjectId = project.ProjectId;
                    pphase.PhaseId = item;
                    projectPhaseRepo.InsertProjectPhase(pphase);
                }

                projectPhaseRepo.SaveData();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


       
        


    }
}
