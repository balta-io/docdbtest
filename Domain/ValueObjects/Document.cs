using FluentValidator;

namespace DocumentDbTest.Domain.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string number)
        {
            Number = number;

            // TODO: Implementar validação de CPF
            new ValidationContract<Document>(this)
                .IsRequired(x => x.Number);
        }

        public string Number { get; private set; }
    }
}