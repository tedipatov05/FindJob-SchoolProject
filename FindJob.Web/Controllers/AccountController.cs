
using FindJob.Core.Contracts;
using FindJob.Core.Models.Account;
using FindJob.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Web.Controllers
{
   
    public class AccountController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;
        private readonly IImageService imageService;
        private readonly IProgrammerService programmerService;
        private readonly ICompanyService companyService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService, IImageService imageService, IProgrammerService programmerService, ICompanyService companyService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.imageService = imageService;
            this.programmerService = programmerService;
            this.companyService = companyService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var registerModel = new RegisterViewModel();

            return this.View(registerModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model) 
        {
            if(await userService.ExistsByPhone(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "There is already registered user with this phone number");
            }

            if(await userService.ExistsByEmail(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "There is already registered user with this email");
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }


            var user = new User()
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.PhoneNumber,
                Country = model.Country,
                City = model.City,
                Address = model.Address

            };

            var result = await userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                if(model.Abilities != null && model.GraduationSchool != null)
                {
                    await userManager.AddToRoleAsync(user, "Programmer");
                    await programmerService.Create(user.Id, model.Abilities, model.GraduationSchool);
                }
                else
                {
                    await userManager.AddToRoleAsync(user, "Company");
                    await companyService.Create(user.Id);
                }

                if(model.ProfilePicture != null)
                {
                    user.ProfilePictureUrl = await imageService.UploadImage(model.ProfilePicture, "Images Find Job", user);

                    await userManager.UpdateAsync(user);
                }

                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");

            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            var loginViewModel = new LoginViewModel();

            return View(loginViewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if(user != null)
            {
                if (user.IsActive)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }

            ModelState.AddModelError(nameof(model.Email), "Invalid login");
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
