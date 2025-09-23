﻿using CSharpFunctionalExtensions;

namespace Shared.FullTextSearch;


public interface ISearchProvider
{
    Task<List<Guid>> SearchAsync(string query);

    Task<UnitResult<ErrorsList>> IndexQuestionAsync<TEntity>(TEntity entity, string indexName);
}