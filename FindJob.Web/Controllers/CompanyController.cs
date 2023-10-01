using FindJob.Core.Contracts;
using FindJob.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using static FindJob.Common.NotificationConstants;

namespace FindJob.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IJobOfferService jobOfferService;
        private readonly IProgrammerService programmerService;

        public CompanyController(ICompanyService companyService, IJobOfferService jobOfferService, IProgrammerService programmerService)
        {
            this.companyService = companyService;
            this.jobOfferService = jobOfferService;
            this.programmerService = programmerService;
        }

        public async Task<IActionResult> Candidate(string offerId)
        {
            string userId = User.GetId();

            var isProgrammer = await programmerService.IsExists(userId);
            if(!isProgrammer)
            {
                TempData[ErrorMessage] = "You should be a programmer to candidate";
                return RedirectToAction("AllOffers", "JobOffer");
            }

            var isJobOfferExists = await jobOfferService.IsJobOfferExists(offerId);
            if(!isJobOfferExists)
            {
                TempData[ErrorMessage] = "This job offer does not exists";
                return RedirectToAction("AllOffers", "JobOffer");
            }

            var isAlreadyCandidate = await programmerService.IsCandidateToOffer(userId, offerId);
            if(isAlreadyCandidate) 
            {
                TempData[WarningMessage] = "You are already candidate to offer";

                return RedirectToAction("AllOffers", "JobOffer");
            }

            try
            {
                await programmerService.Candidate(userId, offerId);

                TempData[SuccessMessage] = "Successfully candidate to job offer";

                return RedirectToAction("AllOffers", "JobOffer");

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("AllOffers", "JobOffer");
            }



        }

        [HttpGet]
        public async Task<IActionResult> Candidates(string offerId)
        {
            var userId = User.GetId();

            var isCompany = await companyService.IsCompanyExist(userId);
            if(! isCompany)
            {
                TempData[ErrorMessage] = "You should be a company to see candidates";

                return RedirectToAction("AllOffers", "JobOffer");
            }

            var isOfferExists = await jobOfferService.IsJobOfferExists(offerId);
            if(!isOfferExists) 
            {
                TempData[ErrorMessage] = "This job offer does not exists";

                return RedirectToAction("CopanyOffers", "JobOffer", new {id = userId});
            }


            try
            {
                var candidates = await companyService.GetCandidatesToOffer(offerId);

                return View(candidates);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

        }
        public async Task<IActionResult> Accept(string id, string offerId)
        {
            var userId = User.GetId();

            var isCompany = await companyService.IsCompanyExist(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "You should be a company to see candidates";

                return RedirectToAction("AllOffers", "JobOffer");
            }

            var isOfferExists = await jobOfferService.IsJobOfferExists(offerId);
            if (!isOfferExists)
            {
                TempData[ErrorMessage] = "This job offer does not exists";

                return RedirectToAction("CompanyOffers", "JobOffer", new { id = userId });
            }
            var companyId = await companyService.GetCompanyId(userId);

            try
            {
                await companyService.AcceptProgrammer(id, offerId, companyId);

                TempData[SuccessMessage] = "Successfully accepted programmer";

                return RedirectToAction("Candidates", new { offerId });
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }
        public async Task<IActionResult> Reject(string id, string offerId)
        {
            var userId = User.GetId();

            var isCompany = await companyService.IsCompanyExist(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "You should be a company to see candidates";

                return RedirectToAction("AllOffers", "JobOffer");
            }

            var isOfferExists = await jobOfferService.IsJobOfferExists(offerId);
            if (!isOfferExists)
            {
                TempData[ErrorMessage] = "This job offer does not exists";

                return RedirectToAction("CompanyOffers", "JobOffer", new { id = userId });
            }
            var companyId = await companyService.GetCompanyId(userId);

            try
            {
                await companyService.RejectProgrammer(id, offerId);

                TempData[SuccessMessage] = "Successfully rejected programmer";

                return RedirectToAction("Candidates", new { offerId });
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }
        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return this.RedirectToAction("Index", "Home");
        }

    }
}
