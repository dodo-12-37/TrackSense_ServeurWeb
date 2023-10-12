using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;
[Table("InterestPoint")]
public class InterestPoint
{
    [Key]
    public int InterestPointId { get; set; }

    public string? UserLogin { get; set; }

    public int AddressId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    [ForeignKey(nameof(AddressId))]
    public virtual Address Address { get; set; } = null!;

    [ForeignKey(nameof(UserLogin))]
    public virtual User? User { get; set; }
}
