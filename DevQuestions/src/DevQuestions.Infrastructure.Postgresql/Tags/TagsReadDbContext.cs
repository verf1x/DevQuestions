﻿using DevQuestions.Application.Tags;
using DevQuestions.Domain.Tags;
using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Infrastructure.Postgresql.Tags;

public class TagsReadDbContext : DbContext, ITagsReadDbContext
{
    public DbSet<Tag> Tags { get; set; }

    public IQueryable<Tag> ReadTags => Tags.AsNoTracking().AsQueryable();
}