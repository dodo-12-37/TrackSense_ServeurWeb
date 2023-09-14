using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class Contact
{
    public Guid ContactId { get; set; }

    public string? UserLogin { get; set; }

    public string? Fullname { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual User? UserLoginNavigation { get; set; }
}
