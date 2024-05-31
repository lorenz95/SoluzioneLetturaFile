using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLetturaFile
{
    public class Operaio : Lavoratore
    {
        public string NomeAzienda { get; set; }
        public Operaio(string codiceFiscale, string nome, string cognome, string dataNascita, int pagaOraria, string nomeAzienda) : base(codiceFiscale, nome, cognome, dataNascita, pagaOraria)
        {
            NomeAzienda = nomeAzienda;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Dati dell'Operaio: ");
            stringBuilder.Append(base.ToString());
            stringBuilder.AppendFormat($"NomeAzienda = {NomeAzienda}");
            return stringBuilder.ToString();
        }
    }
}
