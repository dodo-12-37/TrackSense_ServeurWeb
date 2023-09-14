using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class InterestPoint
{
    public int InterestPointId { get; set; }

    public string? UserLogin { get; set; }

    public Guid AddressId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual User? UserLoginNavigation { get; set; }
}
