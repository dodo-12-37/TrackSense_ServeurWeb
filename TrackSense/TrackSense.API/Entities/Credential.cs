using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrackSense.API.Entities
{
    public class Credential
    {
        public string UserLogin { get; set; } = null!;
        public string HashedPassword { get; set; } = string.Empty!;
        public virtual User User { get; set; } = null!;
    }
}
