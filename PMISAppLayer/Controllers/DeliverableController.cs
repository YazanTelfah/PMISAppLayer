using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PMISAppLayer.DTO;
using PMISAppLayer.DTO.DelivrableDTO;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace PMISAppLayer.Controllers
{
    public class DeliverableController : Controller
    {
        private readonly IDeliverableRepository deliverableRepository;
        private readonly IProjectPhaseRepository projectPhaseRepository;
        private readonly IProjectRepository projectRepository;

        // project Crud C =f R = f d=f u=notF
        // identity
        //theme
        public DeliverableController(IDeliverableRepository DevRepository, IProjectPhaseRepository projectPhaseRepository, IProjectRepository projectRepository)
        {
            this.deliverableRepository = DevRepository;
            this.projectPhaseRepository = projectPhaseRepository;
            this.projectRepository = projectRepository;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Admin"))
            {
                ViewBag.Deliverable = deliverableRepository.GetAllDeliverables(); // 7 project
                return View();
            }
            ViewBag.Deliverable = deliverableRepository.GetAllDeliverablesByProjectManager(userId);// yazan =>2  // zaid =>5 //based on manid
            return View();
        }
        public IActionResult NewDeliverable( int id) // projectphase
        {
            var projectPhase = projectPhaseRepository.Find(id); 
            var projcet = projectRepository.Find(projectPhase.ProjectId);
            ViewBag.projectPhase = projectPhase;
            ViewBag.project = projcet;

            return View();
        }


        public IActionResult Create(InsertDeliverableDTO insertDeliverableDTO)
        {

            var obj = new Deliverable()
            {
                DeliverableDescription=insertDeliverableDTO.DeliverableDescription,
                EndtDate=insertDeliverableDTO.EndtDate,
                 StartDate=insertDeliverableDTO.StartDate,
                 ProjectPhaseId=insertDeliverableDTO.ProjectPhaseId
            };
            deliverableRepository.InsertDeliverable(obj);

            return RedirectToAction(nameof(Index));
        }

       public IActionResult UpdateDeliverable(int id)
        {
            var dev = deliverableRepository.Find(id);
            //var projectPhase = projectPhaseRepository.Find(dev.ProjectPhaseId);
            ViewBag.deliverable = dev;
            //ViewBag.projectPhase = projectPhase;
            return View(dev);
        }

        public IActionResult Edit(Deliverable deliverable)
        {

            deliverableRepository.UpdateDeliverable(deliverable);
            return RedirectToAction(nameof(Index));
        }
        //public IActionResult CreateNewDeliverable(UpdateDeliverableDTO deliverableDTO)
        //{

        //    var entity = new Deliverable();

        //    entity.DeliverableId = deliverableDTO.DeliverableId;
        //    entity.DeliverableDescription = deliverableDTO.DeliverableDescription;
        //    entity.StartDate = deliverableDTO.StartDate;
        //    entity.EndtDate = deliverableDTO.EndtDate;
        //    entity.ProjectPhase.Phase.PhaseName = deliverableDTO.ProjectPhase.Phase.PhaseName;
        //    if (entity.DeliverableId > 0)
        //    {
        //        deliverableRepository.UpdateDeliverable(entity);

        //        //emplemint edit
        //    }
        //    else
        //  
        //        deliverableRepository.InsertDeliverable(entity);

        //        //emplemint create
        //    }

        //    return RedirectToAction("Index");
        //}
        //public IActionResult UpdateDeliverable(int DeliverableId)
        //{
        //    var deliverable = deliverableRepository.Find(DeliverableId);
        //    var createorupdate = new UpdateDeliverableDTO
        //    {
        //        DeliverableId = deliverable.DeliverableId,
        //        DeliverableDescription = deliverable.DeliverableDescription,
        //        StartDate = deliverable.StartDate,
        //        EndtDate = deliverable.EndtDate,
        //        //ProjectPhase = deliverable.ProjectPhase.Phase.PhaseName;
        //};
        //    return View("NewDeliverable", createorupdate);
        //}
        public IActionResult DeleteDeliverable(int id)
        {
            var dev = deliverableRepository.Find(id);
            deliverableRepository.Delete(id);
            return RedirectToAction("Index");
        }





    }
}
