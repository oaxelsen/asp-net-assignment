using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Newtonsoft.Json;
using System.Text;
using Infrastructure.Factories;
using Infrastructure.Models;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, HttpClient http, IConfiguration configuration) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;

    [HttpGet]
    [Route("/register")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [Route("/register")]
    //public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        if (!await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email))
    //        {
    //            var userEntity = new UserEntity
    //            {
    //                FirstName = viewModel.FirstName,
    //                LastName = viewModel.LastName,
    //                Email = viewModel.Email,
    //                UserName = viewModel.Email
    //            };

    //            var result = await _userManager.CreateAsync(userEntity, viewModel.Password);
    //            if (result.Succeeded)
    //            {
    //                return RedirectToAction("SignIn", "Auth");
    //            }
    //            else
    //            {
    //                ViewData["StatusMessage"] = "Something went wrong, please try again";
    //            }
    //        }
    //        else
    //        {
    //            ViewData["StatusMessage"] = "A user with this email already exists";
    //        }
    //    }

    //    return View(viewModel);
    //}

    public async Task<IActionResult> SignUp(SignUpForm form)
    {
        if (ModelState.IsValid)
        {
            if ((await _userManager.CreateAsync(UserFactory.Create(form), form.Password)).Succeeded)
            {
                if ((await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false)).Succeeded)
                {
                    return RedirectToAction("Details", "Account");
                }
            }
            else
            {
                ViewData["StatusMessage"] = "User already exists";
            }
        }

        return View(form);
    }




    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl ?? "/";
        return View();
    }


    //public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var user = await _userManager.FindByEmailAsync(viewModel.Email);
    //        if (user != null)
    //        {
    //            var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);
    //            if (result.Succeeded)
    //            {
    //                return RedirectToAction("Home", "Default");
    //            }
    //        }
    //    }
    //    else
    //    {
    //        ViewData["StatusMessage"] = "Incorrect email or password";
    //    }
    //    return View(viewModel);
    //}

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInForm form)
    {
        if (ModelState.IsValid)
        {
            if ((await _signInManager.PasswordSignInAsync(form.Email, form.Password, form.IsPresistent, false)).Succeeded)
            {
                return LocalRedirect("/");
            }
        }

        ViewData["StatusMessage"] = "Incorrect e-mail och password";
        return View();
    }



    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Home", "Default");
    }

}