using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLetturaFile
{
    public class Meccanico : Lavoratore
    {
        public string NomeOfficina { get; set; }
        public Meccanico(string codiceFiscale, string nome, string cognome, string dataNascita, int pagaOraria, string nomeOfficina) : base(codiceFiscale, nome, cognome, dataNascita, pagaOraria)
        {
            NomeOfficina = nomeOfficina;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Dati del Meccanico: ");
            stringBuilder.Append(base.ToString());
            stringBuilder.AppendFormat($"NomeOfficina = {NomeOfficina}");
            return stringBuilder.ToString();
        }
    }
}
