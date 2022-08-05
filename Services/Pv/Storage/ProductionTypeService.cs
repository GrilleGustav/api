﻿using Contracts;
using Entities.Models.Pv.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Services.Interfaces.Pv.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Pv.Storage
{
  /// <summary>
  /// Service to manage Pv battery production type in backend store.
  /// </summary>
  public class ProductionTypeService : IProductionTypeService
  {
    private readonly ILogger<ProductionTypeService> _logger;
    private readonly IRepositoryManager _repository;

    /// <summary>
    /// Service to manage Pv battery production type in backend store.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="repository"></param>
    public ProductionTypeService(ILogger<ProductionTypeService> logger, IRepositoryManager repository)
    {
      _logger = logger;
      _repository = repository;
    }

    /// <summary>
    /// Get all production types.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing a list of production types.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<List<ProductionType>>> GetAll()
    {
      try
      {
        return new Result<List<ProductionType>>(await _repository.ProductionType.FindAll(false).ToListAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<ProductionType>>(new Error("13", "Database connection error."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<List<ProductionType>>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Get one production type.
    /// </summary>
    /// <param name="serverId">Production type backend store id.</param>
    /// <returns>The Task that represents asynchronous operation, containing a production type.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<ProductionType>> GetOne(int id)
    {
      try
      {
        return new Result<ProductionType>(await _repository.ProductionType.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync());
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionType>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionType>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Create production type entity.
    /// </summary>
    /// <param name="data">The Task that represents asynchronous operation, containing some errors or success.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<ProductionType>> Create(Vendor data)
    {
      try
      {
        _repository.Vendor.Create(data);
        await _repository.SaveAsync();
        return new Result<ProductionType>(true);
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionType>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionType>(new Error("15", "Duplicate Key Entry."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionType>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Update production type entity.
    /// </summary>
    /// <param name="vendor">Production type entity.</param>
    /// <returns>The task that represents asynchronous operation, containing some errors or if DbUpdateExecption current database entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<ProductionType>> Update(Vendor data)
    {
      try
      {
        ProductionType productionType = await _repository.ProductionType.FindByCondition(x => x.Id == data.Id, false).SingleOrDefaultAsync();
        if (productionType.ConcurrencyStamp == data.ConcurrencyStamp)
          _repository.Vendor.Update(data);
        else
        {
          _logger.LogWarning("This record was beeing editied by another user");
          Result<ProductionType> result = new Result<ProductionType>(new Error(errorCode: "2001", errorMessage: "This record was beeing editied by another user"));
          result.AddData(productionType);
          result.IsSuccess = false;
          return result;
        }

        await _repository.SaveAsync();
        return new Result<ProductionType>(true);

      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionType>(new Error("14", "Invalid operation."));
      }
      catch (DbUpdateException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionType>(new Error("5", "Error updating entity. Data not changed."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);

        return new Result<ProductionType>(new Error("1", "Error loading data."));
      }
    }

    /// <summary>
    /// Delete production type record.
    /// </summary>
    /// <param name="id">Production type entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<Result<ProductionType>> Delete(int id)
    {
      try
      {
        ProductionType productionType = await _repository.ProductionType.FindByCondition(x => x.Id == id, false).SingleOrDefaultAsync();
        if (productionType != null)
        {
          _repository.ProductionType.Delete(productionType);
          await _repository.SaveAsync();
          return new Result<ProductionType>(true);
        }

        return new Result<ProductionType>(new Error(errorCode: "8", errorMessage: "Can´t delete server, server not found."));
      }
      catch (ArgumentNullException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionType>(new Error("13", "Database connection error."));
      }
      catch (InvalidOperationException e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionType>(new Error("14", "Invalid operation."));
      }
      catch (Exception e)
      {
        if (_logger.IsEnabled(LogLevel.Error))
          _logger.LogError(e.Message);
        return new Result<ProductionType>(new Error("1", "Error loading data."));
      }
    }
  }
}
