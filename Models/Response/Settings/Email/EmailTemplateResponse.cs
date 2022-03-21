﻿// <copyright file="EmailTemplateResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Settings.Email;
using Models.View.Settings.Email;

namespace Models.Response.Settings.Email
{
  public class EmailTemplateResponse : ErrorResponse
  {
    /// <summary>
    /// Email template response.
    /// </summary>
    public EmailTemplateResponse()
    { }

    /// <summary>
    /// Email template response.
    /// </summary>
    /// <param name="emailTemplate">Email templates.</param>
    public EmailTemplateResponse(EmailTemplateViewModel emailTemplate)
    {
      this.EmailTemplate = emailTemplate;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set email template.
    /// </summary>
    public EmailTemplateViewModel EmailTemplate { get; set; }
  }
}
