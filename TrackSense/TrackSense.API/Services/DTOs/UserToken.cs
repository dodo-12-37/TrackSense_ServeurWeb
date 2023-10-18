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
    [ForeignKey (nameof(UserLogin))]
    public string UserLogin { get; set; } = null!;

    public string Token { get; set; } = null!;

    public DateTime? LastUsedAt { get; set; } = null;

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
    public UserToken()
    {
        
    }
    public UserToken(Entities.UserToken p_userToken,User p_user)
    {
        this.UserLogin = p_userToken.UserLogin;
        this.Token = p_userToken.Token;
        this.CreatedAt = DateTime.Now;
        this.User = p_user;
    }
    public Entities.UserToken ToEntity()
    {
        return new Entities.UserToken()
        {
            UserLogin = this.UserLogin,
            Token = this.Token
        };

    }
}
