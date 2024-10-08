﻿using CustomersManagement.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace CustomersManagement.Infrastructure.Logging;

//TODO
//is this wrapper neccessary
public class LoggerAdapter<T> : IAppLogger<T>
{
    private readonly ILogger<T> _logger;

    public LoggerAdapter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }

    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }

    public void LogError(Exception? exception, string message, params object[] args)
    {
        _logger.LogError(exception, message, args);
    }

    public void LogError(string message, params object[] args)
    {
        _logger.LogError(message, args);
    }
}

