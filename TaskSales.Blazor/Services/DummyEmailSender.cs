using Microsoft.AspNetCore.Identity.UI.Services;

namespace TaskSales.Blazor.Services
{
    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // 🔹 No real email sending (Demo / Dev purpose)
            Console.WriteLine($"Email to {email}");
            Console.WriteLine(subject);
            Console.WriteLine(htmlMessage);

            return Task.CompletedTask;
        }
    }
}
