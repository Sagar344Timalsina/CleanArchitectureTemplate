using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Helpers
{
    public class ErrorController:ControllerBase
    {
        public IActionResult ValidationErrorResponse(ValidationResult validationResult)
        {
            var errors = validationResult.Errors.Select(error => new
            {
                PropertyName = error.PropertyName,
                ErrorMessage = error.ErrorMessage,
                AttemptedValue = error.AttemptedValue
            });

            var errorResponse = new
            {
                StatusCode = 400,
                Message = "Validation failed for one or more fields.",
                Errors = errors
            };

            return BadRequest(errorResponse); // Returns a 400 response with detailed errors
        }
    }
}
