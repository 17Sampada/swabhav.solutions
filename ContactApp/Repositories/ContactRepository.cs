using ContactApp.Models;

namespace ContactApp.Repositories
{


    internal class ContactRepository
    {

        private List<Contact> _contacts = new List<Contact>();


        public ContactRepository() { }



        public Contact GetContactById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(u => u.ContactId == contactId);
            return contact;
        }

        public List<Contact> GetAllContacts()
        {
            var contact = _contacts.Where(x => x.IsActive).ToList();
            return contact;
        }


        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }



        public void UpdateContact(Contact contact)
        {
            var existingContact = GetContactById(contact.ContactId);
            if (existingContact != null)
            {
                existingContact.FName = contact.FName;
                existingContact.LName = contact.LName;
                existingContact.IsActive = contact.IsActive;
            }
        }


        public void DeleteContact(int contactId)
        {
            var contact = GetContactById(contactId);
            if (contact != null)
            {
                contact.IsActive = false;
            }
        }




    }
}
