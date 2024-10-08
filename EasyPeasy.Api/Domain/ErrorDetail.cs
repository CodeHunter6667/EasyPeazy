﻿using Newtonsoft.Json;

namespace EasyPeasy.Api.Domain;

public class ErrorDetail
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Trace { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
