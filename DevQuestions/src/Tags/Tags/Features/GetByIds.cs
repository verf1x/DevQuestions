﻿using Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions;
using Tags.Contracts.Dtos;
using Tags.Database;

namespace Tags.Features;

public sealed class GetByIds
{
    public record GetByIdsQuery(GetByIdsDto dto) : IQuery;

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("tags/ids", async (
                GetByIdsDto dto,
                IQueryHandler<GetByIdsQuery, IReadOnlyList<TagDto>> handler,
                CancellationToken cancellationToken = default) =>
            {
                var result = await handler.HandleAsync(new GetByIdsQuery(dto), cancellationToken);

                return Results.Ok(result);
            });
        }
    }

    public sealed class Handler : IQueryHandler<GetByIdsQuery, IReadOnlyList<TagDto>>
    {
        private readonly TagsDbContext _tagsDbContext;

        public Handler(TagsDbContext tagsDbContext)
        {
            _tagsDbContext = tagsDbContext;
        }

        public async Task<IReadOnlyList<TagDto>> HandleAsync(
            GetByIdsQuery query,
            CancellationToken cancellationToken)
        {
            var tags = await _tagsDbContext.Tags
                .Where(x => query.dto.Ids.Contains(x.Id))
                .ToListAsync(cancellationToken: cancellationToken);

            return [.. tags.Select(t => new TagDto(t.Id, t.Name))];
        }
    }
}