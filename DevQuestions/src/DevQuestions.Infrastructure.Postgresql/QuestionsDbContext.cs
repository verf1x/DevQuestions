﻿using DevQuestions.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Infrastructure.Postgresql;

public class QuestionsDbContext : DbContext
{
    public DbSet<Question> Questions { get; set; }
}