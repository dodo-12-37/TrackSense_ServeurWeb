using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class Credential
{
    public string UserLogin { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual User UserLoginNavigation { get; set; } = null!;
}
