using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.models.Services;
using WebApplication2.models.ViewModels;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private IEmailSender _emailSender;

        public IndexModel(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [Required]
        [BindProperty]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(15)]
        [MaxLength(2048)]
        [Required]
        public string Message { get; set; }

        public async Task OnPost(EmailViewModel evm)
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
                await _emailSender.SendEmailAsync("Percival20@gmail.com", $"{email.FirstName} {email.LastName}", $" <p>  Sent from: { email.Email}</p></br> <p> { email.Message} </p>");
            }
            
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
