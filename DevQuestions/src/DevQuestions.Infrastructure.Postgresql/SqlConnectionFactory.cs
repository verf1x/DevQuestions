﻿using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Shared.Database;

namespace DevQuestions.Infrastructure.Postgresql;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection Create()
    {
        var connection = new NpgsqlConnection(_configuration.GetConnectionString("Database"));

        return connection;
    }
}