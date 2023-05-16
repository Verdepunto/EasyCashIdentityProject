using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManeger;

        public RegisterController(UserManager<AppUser> userManeger)
        {
            _userManeger = userManeger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser() 
                {
                   UserName = appUserRegisterDto.UserName,
                   Name = appUserRegisterDto.Name,
                   Surname = appUserRegisterDto.Surname,
                   Email = appUserRegisterDto.Email
                };
                var result = await _userManeger.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirnMail");
                }
            }
            return View();
        }
    }
}
