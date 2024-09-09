﻿using System;
namespace EasyPeasy.Api.Domain;

public class Category : EntityBase
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}

