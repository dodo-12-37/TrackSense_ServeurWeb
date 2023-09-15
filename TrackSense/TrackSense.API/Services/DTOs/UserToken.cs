using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrackSense.API.Services.DTOs;
[Table("UserToken")]
public class UserToken
{
    [Key]
    public int UserTokenId { get; set; }

    public string UserLogin { get; set; } = null!;

    public string Token { get; set; } = null!;

    public DateTime? LastUsedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User UserLoginNavigation { get; set; } = null!;
}
