using FindJob.Core.Contracts;
using FindJob.Core.Models.JobOffer;
using FindJob.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
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
            bool isCompany = await companyService.IsCompanyExist(User.GetId());
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
            string userId = User.GetId();
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllOffers([FromQuery]JobOfferQueryModel model)
        {
            var userId = GetUserId();

            var isCompany = await companyService.IsCompanyExist(userId);
            if(isCompany) 
            {
                TempData[ErrorMessage] = "You cannot see other companies job offers";

                return RedirectToAction("Index", "Home");
            }

            try
            {
                var offers = await jobOfferService.GetAllJobOffersFilteredAndPaged(model);

                model.JobOffers = offers.JobOffers;
                model.TotalOffers = offers.TotalJobOffers;
                model.TypeOfJobs = await jobOfferService.GetAllTypeOfJobs();

                return View("All", model);

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;

                return RedirectToAction("Index", "Home");
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> CompanyOffers(string id, [FromQuery] JobOfferQueryModel model)
        {
            
            var isCompany = await companyService.IsCompanyExist(id);
            var companyId = await companyService.GetCompanyId(id);

            if (!isCompany)
            {
                TempData[ErrorMessage] = "You cannot see other companies job offers";

                return RedirectToAction("Index", "Home");
            }

            try
            {
                var offers = await jobOfferService.GetCompanyJobOffersFilteredAndPaged(model, companyId);

                model.JobOffers = offers.JobOffers;
                model.TotalOffers = offers.TotalJobOffers;
                model.TypeOfJobs = await jobOfferService.GetAllTypeOfJobs();

                return View("All", model);

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;

                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string jobOfferId)
        {
            string userId = User.GetId();
            

            var isCompany = await companyService.IsCompanyExist(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "You should be a company to edit this offer";

                return RedirectToAction("CompanyOffers", new {id = userId});
            }

            var isExists = await jobOfferService.IsJobOfferExists(jobOfferId);

            if(!isExists)
            {
                TempData[ErrorMessage] = "This job offer does not exists";

                return RedirectToAction("CompanyOffer", new {id = userId});
            }
            var companyId = await companyService.GetCompanyId(userId);

            var isOwner = await jobOfferService.IsCompanyOwnerToOffer(companyId, jobOfferId);

            if (!isOwner)
            {
                TempData[ErrorMessage] = "You should be a owner to this offer";

                return RedirectToAction("CompanyOffers", new {id = userId});
            }

            try
            {
                 var jobOffer = await jobOfferService.GetJobOfferById(jobOfferId);

                return View(jobOffer);

            }
            catch(Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;

                return RedirectToAction("AllOffers");
            }


        }
        [HttpPost]
        public async Task<IActionResult> Edit(string jobOfferId, JobOfferFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.GetId();


            var isCompany = await companyService.IsCompanyExist(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "You should be a company to edit this offer";

                return RedirectToAction("CompanyOffers", new { id = userId });
            }

            var isExists = await jobOfferService.IsJobOfferExists(jobOfferId);

            if (!isExists)
            {
                TempData[ErrorMessage] = "This job offer does not exists";

                return RedirectToAction("CompanyOffer", new { id = userId });
            }
            var companyId = await companyService.GetCompanyId(userId);

            var isOwner = await jobOfferService.IsCompanyOwnerToOffer(companyId, jobOfferId);

            if (!isOwner)
            {
                TempData[ErrorMessage] = "You should be a owner to this offer";

                return RedirectToAction("CompanyOffers", new { id = userId });
            }

            try
            {
                await jobOfferService.EditJobOffer(jobOfferId, model);

            }
            catch (Exception ex)
            {
                return this.GeneralError();
            }

            TempData[SuccessMessage] = "Successfully edited job offer";
            return RedirectToAction("CompanyOffers", new { id = userId });
        }

        
        public async Task<IActionResult> Delete(string jobOfferId)
        {
            
            string userId = User.GetId();

            var isCompany = await companyService.IsCompanyExist(userId);
            if (!isCompany)
            {
                TempData[ErrorMessage] = "You should be a company to delete this offer";

                return RedirectToAction("CompanyOffers", new { id = userId });
            }

            var isExists = await jobOfferService.IsJobOfferExists(jobOfferId);

            if (!isExists)
            {
                TempData[ErrorMessage] = "This job offer does not exists";

                return RedirectToAction("CompanyOffer", new { id = userId });
            }
            var companyId = await companyService.GetCompanyId(userId);

            var isOwner = await jobOfferService.IsCompanyOwnerToOffer(companyId, jobOfferId);

            if (!isOwner)
            {
                TempData[ErrorMessage] = "You should be a owner to this offer";

                return RedirectToAction("CompanyOffers", new { id = userId });
            }

            try
            {
                await jobOfferService.DeleteJobOffer(jobOfferId);

                TempData[SuccessMessage] = "Successfully deleted job offer";
                return RedirectToAction("CompanyOffers", new { id = userId });
            }
            catch (Exception ex)
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
