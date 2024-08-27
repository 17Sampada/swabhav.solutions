using ContactApp.Models;

namespace ContactApp.Repositories
{


    internal class ContactDetailsRepository
    {
        private List<ContactDetails> _contactDetails = new List<ContactDetails>();



        public ContactDetailsRepository() { }


        public ContactDetails GetContactDetailsById(int contactDetailsId)
        {
            var contactDetails = _contactDetails.FirstOrDefault(x => x.Contact_DetailsId == contactDetailsId);
            return contactDetails;
        }

        public List<ContactDetails> GetAllContactDetails()
        {
            var contactDetails = _contactDetails.Where(x => x.IsActive).ToList();
            return contactDetails;
        }


        public void AddContactDetails(ContactDetails contactDetails)
        {
            _contactDetails.Add(contactDetails);
        }


        public void UpdateContactDetails(ContactDetails contactDetails)
        {
            var existingDetails = GetContactDetailsById(contactDetails.Contact_DetailsId);
            if (existingDetails != null)
            {
                existingDetails.Type = contactDetails.Type;
                existingDetails.Value = contactDetails.Value;
            }
        }



        public void DeleteContactDetails(int contactDetailsId)
        {
            var contactDetails = GetContactDetailsById(contactDetailsId);
            if (contactDetails != null)
            {
                _contactDetails.Remove(contactDetails);
            }
        }



    }
}
