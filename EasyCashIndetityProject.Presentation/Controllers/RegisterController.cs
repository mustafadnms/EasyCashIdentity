﻿using EasyCashIndetityProject.Dto.Dtos.AppUserDtos;
using EasyCashIndetityProject.Entity.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashIndetityProject.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);

				AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "aaa",
                    District = "bbb",
                    ImageUrl = "ccc",
                    ConfirmCode = code
                };

                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "gamereadytv1@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User",appUser.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz:" + code;
                    mimeMessage.Body=bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Easy Cash Onay Kodu";


                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com",587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("donmusmustafa@gmail.com", "uwpepoqlnwlhkcpz");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    TempData["Mail"] = appUserRegisterDto.Email; 

                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View();


        }


    }
}
