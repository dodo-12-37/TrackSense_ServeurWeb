using TrackSense.API.Entities;

namespace TrackSense.API.ViewModels
{
    public class UserContactViewModel
    {
        public int ContactId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public UserContactViewModel()
        {
            ;
        }

        public UserContactViewModel(UserContact p_userContact)
        {
            this.ContactId = p_userContact.ContactId;
            this.FullName = p_userContact.FullName;
            this.PhoneNumber = p_userContact.PhoneNumber;
        }

        public UserContact ToEntity()
        {
            return new UserContact
            {
                ContactId = this.ContactId,
                FullName = this.FullName,
                PhoneNumber = this.PhoneNumber
            };
        }
    }

}
