using FluentValidation;
using Microsoft.Extensions.Logging;
using SampleApp.API.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.API.Application.Validations
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator(ILogger<CreateItemCommandValidator> logger)
        {
            RuleFor(command => command.ProductName).NotEmpty().WithMessage("Please enter product name"); ;
        }
            
    }
}
