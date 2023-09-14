using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class UserToken
{
    public int UserTokenId { get; set; }

    public string UserLogin { get; set; } = null!;

    public string Token { get; set; } = null!;

    public DateTime? LastUsedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User UserLoginNavigation { get; set; } = null!;
}
