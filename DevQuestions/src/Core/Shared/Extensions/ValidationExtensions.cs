﻿using FluentValidation.Results;

namespace Shared.Extensions;

public static class ValidationExtensions
{
    public static ErrorsList ToErrors(this ValidationResult validationResult)
        => validationResult.Errors
            .Select(e => Error.Validation(e.ErrorCode, e.ErrorMessage, e.PropertyName))
            .ToArray();
}