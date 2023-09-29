using FindJob.Core.Contracts;
using FindJob.Core.Models.JobOffer;
using Microsoft.AspNetCore.Mvc;
using static FindJob.Common.NotificationConstants;

namespace FindJob.Web.Controllers
{
    public class JobOfferController : BaseController
    {
        private readonly ICompanyService companyService;
        private readonly IJobOfferService jobOfferService;

        public JobOfferController(ICompanyService companyService, IJobOfferService jobOfferService)
        {
            this.companyService = companyService;
            this.jobOfferService = jobOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isCompany = await companyService.IsCompanyExist(GetUserId());
            if(!isCompany)
            {
                TempData[ErrorMessage] = "You should be registered as a company to add job offer";

                return RedirectToAction("Index", "Home");
            }

            return View(new JobOfferFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(JobOfferFormModel model)
        {
            string userId = GetUserId();
            bool isCompany = await companyService.IsCompanyExist(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "You should be registered as a company to add job offer";

                return RedirectToAction("Index", "Home");
            }

            string companyId = await companyService.GetCompanyId(userId);

            if(!ModelState.IsValid)
            {
                return View(model);

            }

            await jobOfferService.AddJobOffer(companyId, model);

            TempData[SuccessMessage] = $"Successfully added job offer {model.TypeOfJob}";

            // TODO: Change redirection
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AllOffers()
        {
            return View();
        }

    }
}
