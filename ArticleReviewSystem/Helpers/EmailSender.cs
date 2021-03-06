﻿using ArticleReviewSystem.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace ArticleReviewSystem.Helpers
{
    public class EmailSender
    {
        public async void sendMailAsync(ApplicationUserManager userManager, ApplicationUser user)
        {
            var code = await userManager.GeneratePasswordResetTokenAsync(user.Id);
            code = HttpUtility.UrlEncode(code);
            //address for deploy
            string link = "https://articlereviewsystem.azurewebsites.net\\Account\\ResetPassword?token=" + code;
            var fromAddress = new MailAddress("articleReviewerTeam@gmail.com", "Booktrade");
            var toAddress = new MailAddress(user.Email, user.Name);
            const string fromPassword = "articleReview007";
            const string subject = "Reset password - ArticleReviewSystem";
            string body = "Welcome " + user.UserName + ",</br>Do you want change the password?</ br></br>"
                + "Click the link if you want to reset your password.</br>" + "<a>" + link + "</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                message.IsBodyHtml = true;
                smtp.Send(message);
            }
        }
          
    }
}