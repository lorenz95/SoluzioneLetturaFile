using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLetturaFile
{
    public class Informatico : Lavoratore
    {
        public string LinguaggioUsato;
        public Informatico(string codiceFiscale, string nome, string cognome, string dataNascita, int pagaOraria, string linguaggioUsato) : base(codiceFiscale, nome, cognome, dataNascita, pagaOraria)
        {
            LinguaggioUsato = linguaggioUsato;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Dati dell' Informatico: ");
            stringBuilder.Append(base.ToString());
            stringBuilder.AppendFormat($"LinguaggioUsato = {LinguaggioUsato}");
            return stringBuilder.ToString();
        }
    }
}
