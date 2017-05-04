using FluentValidator;

namespace DocumentDbTest.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            new ValidationContract<Email>(this)
                .IsEmail(x => x.Address);
        }

        public string Address { get; private set; }
    }
}