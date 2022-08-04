﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Customers.Commands.Update;

    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
           RuleFor(v => v.Name)
                 .MaximumLength(256)
                 .NotEmpty();
           RuleFor(v => v.Description)
               .MaximumLength(1024);
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
     {
        var result = await ValidateAsync(ValidationContext<UpdateCustomerCommand>.CreateWithOptions((UpdateCustomerCommand)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
     };
    }
