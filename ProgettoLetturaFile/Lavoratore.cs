using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLetturaFile
{
    public class Lavoratore : Persona
    {
        public int PagaOraria { get; set; }
        public Lavoratore(string codiceFiscale, string nome, string cognome, string dataNascita, int pagaOraria) : base(codiceFiscale, nome, cognome, dataNascita)
        {
            PagaOraria = pagaOraria;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Dati del Lavoratore: ");
            stringBuilder.Append(base.ToString());
            stringBuilder.AppendFormat($"PagaOraria = {PagaOraria}");
            return stringBuilder.ToString();
        }
    }
}
