using VesperaWebApp.Models;

namespace VesperaWebApp.Services
{
    public interface IFormRegistrationService
    {
        void RegisterForm(RegistrationForm form);
        Task RegisterFormAsync(RegistrationForm form);
    }
}
