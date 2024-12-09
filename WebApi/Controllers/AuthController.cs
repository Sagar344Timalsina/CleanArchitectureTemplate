using Application.Common.DTOs.User;
using Application.Users.Commands.Create;
using Application.Users.Queries.GetUsersWithPagination;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ISender _sender, IValidator<RegisterUserRequestDTOs> _validator,IValidator<LoginUserRequestDTOs> _loginValidator) : BaseApiController
    {
        private ErrorController errorController { get; set; } = new(); 
        [HttpPost("RegisterUser")]
        [AllowAnonymous]
        public async Task<IActionResult> registerUser(RegisterUserRequestDTOs requestModel)
        {
            var validate = await _validator.ValidateAsync(requestModel);
            if (!validate.IsValid)
            {

                return errorController.ValidationErrorResponse(validate);
            }
            var command = new RegisterUserCommand(requestModel);
            var result = await _sender.Send(command);
            return Ok(result);
        }

      

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> loginUser(LoginUserRequestDTOs requestModel)
        {
            var validate = await _loginValidator.ValidateAsync(requestModel);
            if (!validate.IsValid)
            {
                return errorController.ValidationErrorResponse(validate);
            }
            var command = new LoginUserCommand(requestModel);
            var result = await _sender.Send(command);
            return Ok(result);
        }
    }
}
