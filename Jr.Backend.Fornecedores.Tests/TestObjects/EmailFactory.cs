using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Tests.TestObjects
{
    public static class EmailFactory
    {
        public static string DeveInstanciarUmEmailContato()
        {
            return "emailvalido@gmail.com";
        }

        public static string DeveInstanciarUmEmailFatura()
        {
            return "emailvalido@gmail.com";
        }

        public static IEnumerable<string> DeveInstanciarUmaListaEmailFatura(int quantidade = 1)
        {
            List<string> emails = new List<string>();
            for (int i = 0; i < quantidade; i++)
            {
                emails.Add(DeveInstanciarUmEmailFatura());
            }

            return emails;
        }

        public static IEnumerable<string> DeveInstanciarUmaListaEmailContato(int quantidade = 1)
        {
            List<string> emails = new List<string>();
            for (int i = 0; i < quantidade; i++)
            {
                emails.Add(DeveInstanciarUmEmailContato());
            }

            return emails;
        }
    }
}