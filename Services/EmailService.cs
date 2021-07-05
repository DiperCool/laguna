
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Models;

namespace Services
{
    public class EmailService : IEmailService
    {
        IConfiguration _configuration;
        IProductService _productService;

        public EmailService(IConfiguration configuration, IProductService productService)
        {
            _configuration = configuration;
            _productService = productService;
        }

        public async Task Send(string content, int id)
        {
            var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("Lagun backend",_configuration["MailKit:email"]));
            emailMessage.To.Add(new MailboxAddress("", "lagunareceiver@gmail.com"));
            emailMessage.Subject = $"Новый заказ №{id}";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = content
            };
             
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_configuration["MailKit:smtp"], int.Parse(_configuration["MailKit:port"]),  MailKit.Security.SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(_configuration["MailKit:email"], _configuration["MailKit:password"]);
                await client.SendAsync(emailMessage);
 
                await client.DisconnectAsync(true);
            }
        }

        
    }


}