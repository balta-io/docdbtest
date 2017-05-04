using FluentValidator;

namespace DocumentDbTest.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            // TODO: aplicar mais validações
            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirstName)
                .IsRequired(x => x.LastName);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}