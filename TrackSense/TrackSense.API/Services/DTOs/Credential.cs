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
    [Required]
    public string HashedPassword { get; set; } = string.Empty!;
 
    [ForeignKey(nameof(UserLogin))]
    public virtual User User { get; set; } = null!;
    public Credential()
    {
        
    }
    public Credential(Entities.Credential p_credential,User p_user)
    {
        this.UserLogin = p_credential.UserLogin;
        this.HashedPassword = p_credential.HashedPassword;
        this.User = p_user;
    }
    public Entities.Credential ToEntities()
    {
        return new Entities.Credential()
        {

            UserLogin = this.UserLogin,
            HashedPassword = this.HashedPassword,
        };
    }
}
