using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;
[Table("User")]
public class User
{
    [Key]
    public string UserLogin { get; set; } = null!;

    public int? AddressId { get; set; }

    public string? UserLastName { get; set; }

    public string? UserFirstName { get; set; }

    public string UserEmail { get; set; } = string.Empty!;

    public string? UserCodePostal { get; set; }

    public string? UserPhoneNumber { get; set; }

    [ForeignKey(nameof(AddressId))]
    public virtual Address? Address { get; set; }=null;

    public virtual Credential Credential { get; set; }= null!;
    public virtual UserStatistic? UserStatistic { get; set; }
    public virtual ICollection<UserToken>? UserTokens { get; set; } 
    public virtual ICollection<Tracksense>? Tracksenses { get; set; }
    public virtual ICollection<Contact>? Contacts { get; set; }
    public virtual ICollection<CompletedRide>? CompletedRides { get; set; }
    public virtual ICollection<PlannedRide>? PlannedRides { get; set; } 
    public virtual ICollection<InterestPoint>? InterestPoints { get; set; }

    public User()
    {
        
    }
    public User(Entities.User p_user)
    {
        this.UserLogin = p_user.UserLogin;
        this.UserEmail = p_user.UserEmail;
        this.UserFirstName = p_user.UserFirstName;
        this.UserLastName = p_user.UserLastName;
        this.Credential = new Credential( p_user.Credential,this);
        this.UserTokens = p_user.Tokens?.Select(t => new UserToken(t,this)).ToList();
    }

    public Entities.User ToEntity()
    {
        return new Entities.User()
        {
            UserLogin = this.UserLogin,
            CompletedRides = this.CompletedRides?.Select(r => r.ToEntity()).ToList(),
            PlannedRides = this.PlannedRides?.Select(r => r.ToEntity()).ToList(),
            Credential = this.Credential.ToEntities()
            
        };
    }

}