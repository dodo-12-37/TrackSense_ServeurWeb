using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;

[Table ("Credential")]
public class Credential
{
    [Key]
    public string UserLogin { get; set; } = null!;

    public string Password { get; set; } = null!;

    [ForeignKey(nameof(UserLogin))]
    public virtual User User { get; set; } = null!;
}
