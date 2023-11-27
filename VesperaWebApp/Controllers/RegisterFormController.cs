using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VesperaWebApp.Constants;
using VesperaWebApp.Models;
using VesperaWebApp.Models.DtoModels;
using VesperaWebApp.Services;

namespace VesperaWebApp.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class RegisterFormController : ControllerBase
    {
        private readonly ILogger<RegisterFormController> _logger;
        private readonly IFormRegistrationService _formRegistrationService;

        public RegisterFormController(ILogger<RegisterFormController> logger,
            IFormRegistrationService formRegistrationService)
        {
            _logger = logger;
            _formRegistrationService = formRegistrationService;
        }

        [HttpGet]
        public IActionResult GetRegistrationForm() 
        {
            return Ok(new RegistrationFormDto { FormBody = "Hello" });
        }

        [HttpPost]  
        public IActionResult SubmitRegistrationForm([FromBody] RegistrationFormDto registrationForm) 
        {
            // We should add Automapper and map from RegistrationFormDto to RegistrationForm automatically. 
            // The code below is jsut temporary.
            var formRegistrationModel = new RegistrationForm()
            {
                FormText = registrationForm.FormBody
            };

            try
            {
                // There should be something similar to the code below inside the try clause. 
                // The FormRegistrationService is not implemented yet, but this will serve as an abstraction for now.
                _formRegistrationService.RegisterForm(formRegistrationModel);

                // Also, an email service should be implemented so that the registered form can be sent to employees/ designers.
                /* _emailService.SendFormAsEmail(formRegistrationModel); */
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(AppConstants.CouldNotRegisterForm);
            }

            return Ok();
        }
    }
}
