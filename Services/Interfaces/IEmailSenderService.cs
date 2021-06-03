﻿// <copyright file="IEmailSenderSettingsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using Models.Response;
using Models.Response.Settings.Sender;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IEmailSenderService
  {
    /// <summary>
    /// Get all email sender.
    /// </summary>
    /// <returns>List of email sender. If fails error code and or error message</returns>
    Task<EmailSenderSettingsResponse> GetAll();

    /// <summary>
    /// Get one email sender.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>Email sender entity. If fails return error code and or error message.</returns>
    Task<EmailSenderSettingResponse> GetOne(int id);

    /// <summary>
    /// Create email sender.
    /// </summary>
    /// <param name="data">New email sender entity.</param>
    /// <returns>New email sender data base object.</returns>
    Task<EmailSenderSettingResponse> Create(EmailSender data);

    /// <summary>
    /// Remove one email sender from database.
    /// </summary>
    /// <param name="id">Email sender entity id to remove.</param>
    /// <returns>If fails return erro code and message.</returns>
    Task<ErrorResponse> Delete(int id);
  }
}