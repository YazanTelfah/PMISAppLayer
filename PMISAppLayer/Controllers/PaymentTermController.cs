using Microsoft.AspNetCore.Mvc;
using PMISAppLayer.DTO;
using PMISAppLayer.DTO.PaymentDTO;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    public class PaymentTermController : Controller
    {

        private readonly IPaymentTermRepository Pay1Repo;
        private readonly IDeliverableRepository deliverableRepository;


        public PaymentTermController(IPaymentTermRepository PayRepository, IDeliverableRepository deliverableRepository)
        {
            this.Pay1Repo = PayRepository;
            this.deliverableRepository = deliverableRepository;
        }
        public IActionResult Index()
        {
            ViewBag.PaymentTerm = Pay1Repo.GetAllPaymentTerm();

            return View();
        }
        public IActionResult NewPaymentTerm(int id)
        {
            var deliv = deliverableRepository.Find(id);
            ViewBag.del = deliv;
            return View();
        }
        public IActionResult CreatePaymentTerm(InsertPaymentTermDTO insertPaymentTermDTO)
        {
            var pays = new PaymentTerm()
            {
                DeliverableId=insertPaymentTermDTO.DeliverableId,
                PaymentTermAmount=insertPaymentTermDTO.PaymentTermAmount,
                PaymentTermTitle=insertPaymentTermDTO.PaymentTermTitle
            };
            Pay1Repo.InsertPaymentTerm(pays);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var pay = Pay1Repo.Find(id);
            ViewBag.pay = pay;
            return View();
        }
        public IActionResult Edit(UpdatePaymentTermDTO updatePaymentTermDTO)
        {
            var pay = Pay1Repo.Find(updatePaymentTermDTO.PaymentTermId);
            pay.PaymentTermAmount = updatePaymentTermDTO.PaymentTermAmount;
            pay.PaymentTermTitle = updatePaymentTermDTO.PaymentTermTitle;
            Pay1Repo.UpdatePaymentTerm(pay);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePaymentTerm(int PaymentTermId)
        {
            Pay1Repo.Delete(PaymentTermId);
            return RedirectToAction("Index");
        }

    }
}
