﻿// <copyright file="VendorAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request.Pv.Storage
{
  /// <summary>
  /// Request for adding new vendor.
  /// </summary>
  public class VendorAddRequest
  {
    /// <summary>
    /// Get or set name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Get or set vendor code.
    /// </summary>
    [Required]
    public string Code { get; set; }

    /// <summary>
    /// Get or set description.
    /// </summary>
    public string Description { get; set; }
  }
}
