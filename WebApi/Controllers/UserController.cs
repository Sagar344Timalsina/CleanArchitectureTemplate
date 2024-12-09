
using Application.Common.DTOs.User;
using Application.Users.Commands.Create;
using Application.Users.Queries.GetUsersWithPagination;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController(ISender _sender, IValidator<RegisterUserRequestDTOs> _validator) : BaseApiController
    {
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser(int PageNumber = 1, string sortColumn = null, string sortDirection = "asc", string filters = null)
        {
            var result = await _sender.Send(new GetAllUsersWithPagination(PageNumber, sortColumn, sortDirection, filters));
            return Ok(result);
        }


        [HttpPost("UserById")]
        public async Task<IActionResult> getUserById(int Id)
        {
            //var response = await _authenticationService.GetIndividualUser(requestModel);
            return Ok();
        }
    }
}
