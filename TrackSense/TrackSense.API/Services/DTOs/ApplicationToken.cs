using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class ApplicationToken
{
    public int ApplicationTokenId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime? LastUsedAt { get; set; }

    public DateTime CreatedAt { get; set; }
}
