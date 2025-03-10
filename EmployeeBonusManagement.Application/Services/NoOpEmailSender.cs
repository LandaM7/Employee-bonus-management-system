using System.Threading.Tasks;
using EmployeeBonusManagement.Application.Interfaces;


namespace EmployeeBonusManagement.Application.Services
{
	public class NoOpEmailSender : IEmailSender
	{
		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			// Do nothing here (no email is sent)
			return Task.CompletedTask;
		}
	}
}