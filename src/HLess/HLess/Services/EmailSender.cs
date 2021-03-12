// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HLess.Config.Options.EmailOptions;

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace HLess.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<SendGridOptions> sendGridOptionsAccessor, IOptions<EmailaddressesOptions> emailaddressesOptionsAccessor)
        {
            Options = sendGridOptionsAccessor.Value;
            EmailAddresses = emailaddressesOptionsAccessor.Value;
        }

        public SendGridOptions Options { get; } //set only via Secret Manager
        public EmailaddressesOptions EmailAddresses { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.ApiKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(EmailAddresses.AdminContact, Options.User),
                ReplyTo = new EmailAddress(EmailAddresses.NoReplyContact),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);
        }
    }
}
