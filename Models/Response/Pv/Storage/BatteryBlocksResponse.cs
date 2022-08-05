﻿// <copyright file="BatteryBlocksResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using System.Collections.Generic;

namespace Models.Response.Pv.Storage
{
  /// <summary>
  /// Battery blocks response.
  /// </summary>
  public class BatteryBlocksResponse : ErrorResponse
  {
    /// <summary>
    /// Battery blocks response.
    /// </summary>
    public BatteryBlocksResponse()
    { }

    /// <summary>
    /// Battery blocks response.
    /// </summary>
    /// <param name="batteryBlocks">List of battery bocks.</param>
    public BatteryBlocksResponse(IList<BatteryBlock> batteryBlocks)
    {
      this.BatteryBlocks = batteryBlocks;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set battery blocks.
    /// </summary>
    public IList<BatteryBlock> BatteryBlocks { get; set; }
  }
}