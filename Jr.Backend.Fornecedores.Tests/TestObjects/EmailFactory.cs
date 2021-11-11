using Jr.Backend.Fornecedores.Domain.ValueObjects;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Tests.TestObjects
{
    public static class EmailFactory
    {
        public static EmailContato DeveInstanciarUmEmailContato()
        {
            return new EmailContato("emailvalido@gmail.com");
        }

        public static EmailFatura DeveInstanciarUmEmailFatura()
        {
            return new EmailFatura("emailvalido@gmail.com");
        }

        public static IEnumerable<EmailFatura> DeveInstanciarUmaListaEmailFatura(int quantidade = 1)
        {
            List<EmailFatura> emails = new List<EmailFatura>();
            for (int i = 0; i < quantidade; i++)
            {
                emails.Add(DeveInstanciarUmEmailFatura());
            }

            return emails;
        }

        public static IEnumerable<EmailContato> DeveInstanciarUmaListaEmailContato(int quantidade = 1)
        {
            List<EmailContato> emails = new List<EmailContato>();
            for (int i = 0; i < quantidade; i++)
            {
                emails.Add(DeveInstanciarUmEmailContato());
            }

            return emails;
        }
    }
}