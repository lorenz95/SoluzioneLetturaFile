using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLetturaFile
{
    public class Persona
    {
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public readonly string DataNascita;

        public Persona(string codiceFiscale, string nome, string cognome, string dataNascita)
        {
            CodiceFiscale = codiceFiscale;
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
        }

        public override String ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Dati della Persona : \n");
            stringBuilder.Append($"CodiceFiscale: {CodiceFiscale}");
            stringBuilder.Append($"Nome: {Nome}");
            stringBuilder.Append("Cognome: " + Cognome);
            stringBuilder.Append("DataNascita: " + DataNascita);

            return stringBuilder.ToString();
        }
    }
}
