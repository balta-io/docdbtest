using DocumentDbTest.Domain.ValueObjects;

namespace DocumentDbTest.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;

            // TODO: Isto é só um exemplo, OK :)
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
    }
}