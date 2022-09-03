﻿// <copyright file="CellTypeViewModel.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;

namespace PvSystemPlugin.Models.View.Pv.Storage
{
  /// <summary>
  /// Cell type view model.
  /// </summary>
  public class CellTypeViewModel
  {
    /// <summary>
    /// Get or set Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get or set celltype name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Get or set code.
    /// </summary>
    public char Code { get; set; }

    /// <summary>
    /// Get or set description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// A DateTime value that should change whenever a role is persisted to the store.
    /// </summary>
    public DateTime ConcurrencyStamp { get; set; }

    /// <summary>
    /// A DateTime value that shows when record changed.
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// A DateTime value that shows when record was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    CellTypeViewModel()
    { }
  }
}