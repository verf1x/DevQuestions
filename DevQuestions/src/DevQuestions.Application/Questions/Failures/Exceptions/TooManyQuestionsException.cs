﻿using DevQuestions.Application.Exceptions;
using Shared;

namespace DevQuestions.Application.Questions.Failures.Exceptions;

public class TooManyQuestionsException : BadRequestException
{
    public TooManyQuestionsException()
        : base([Errors.Questions.TooManyQuestions()])
    {
    }
}