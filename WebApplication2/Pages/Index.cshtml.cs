using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.models.Services;
using WebApplication2.models.ViewModels;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel, IEmailSender
    {
        private EmailSender _emailSender;

        public IndexModel(EmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void OnPost()
        {

        }

        public async Task EmailSubmit(EmailViewModel evm)
        {
            if (ModelState.IsValid)
            {
                EmailViewModel email = new EmailViewModel
                {
                    Email = evm.Email,
                    FirstName = evm.FirstName,
                    LastName = evm.LastName,
                    Message = evm.Message
                };
            }
            
            await _emailSender.SendEmailAsync("Percivaltanner@gmail.com", $"{evm.FirstName} {evm.LastName}", $"{evm.Message} {evm.Email}");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
