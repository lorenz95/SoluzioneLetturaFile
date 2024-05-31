using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProgettoLetturaFile
{
    internal class Program
    {
        private static readonly string NAME_KEYWORD = "Nome: ";
        private static readonly string SURNAME_KEYWORD = "Cognome: ";
        private static readonly string CF_KEYWORD = "CF: ";
        private static readonly string TIPO_LAVORO_KEYWORD = "TipoLavoro: ";

        private static readonly string PATH_KEYWORD = "Dati.dat";

        private static void addInfoToFile(StreamWriter streamWriter, int i)
        {
            streamWriter.WriteLine(NAME_KEYWORD + $"Nome{i} " + SURNAME_KEYWORD + $"Cognome{i} " + CF_KEYWORD + $"CF{i} ");
        }
        private static void addInfoToFile(StreamWriter streamWriter, int i, string tipoLavoro)
        {
            streamWriter.WriteLine(NAME_KEYWORD + $"Nome{i} " + SURNAME_KEYWORD + $"Cognome{i} " + CF_KEYWORD + $"CF{i} " + TIPO_LAVORO_KEYWORD + tipoLavoro);
        }

        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + PATH_KEYWORD;
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter streamWriter = new StreamWriter(path))
                    {
                        int i, j;

                        /*
                         * aggiunta di 15 lavoratori: 3 Informatici; 10 - 3, cioè 7 Operai e 15 - 10, cioè 5 Meccanici
                         */
                        for (i = 0; i < 3; i++) // alla fine del ciclo i vale 3
                        {
                            addInfoToFile(streamWriter, i, "Informatico");
                        }
                        for (; i < 10; i++)
                        {
                            addInfoToFile(streamWriter, i, "Operaio");
                        }
                        for (; i < 15; i++)
                        {
                            addInfoToFile(streamWriter, i, "Meccanico");
                        }

                        // aggiunta di 5 disoccupati (j vale 15 all'inizio di questo ciclo)
                        for (j = i; j < 20; j++)
                        {
                            addInfoToFile(streamWriter, j);
                        }

                        streamWriter.Close();
                    }

                    List<Persona> list = new List<Persona>();
                    using (StreamReader streamReader = new StreamReader(path))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string line = streamReader.ReadLine();

                            int indName = line.IndexOf(NAME_KEYWORD);
                            int indSurname = line.IndexOf(SURNAME_KEYWORD);
                            int indCF = line.IndexOf(CF_KEYWORD);
                            int indTipoLavoro = line.IndexOf(TIPO_LAVORO_KEYWORD);

                            if (indName < 0 || indSurname < 0 || indCF < 0) // il nome, il cognome e il codice fiscale non possono mancare
                            {
                                continue;
                            }

                            if (indTipoLavoro < 0) // se la persona non è un lavoratore
                            {
                                indTipoLavoro = line.Length - 1; // si prende l'ultimo carattere della stringa da leggere
                            }

                            indName += NAME_KEYWORD.Length; // si fa camminare l'indice del nome fino alla fine della parola chiave
                            string name = line.Substring(indName, indSurname - indName);// il nome è compreso tra l'ultimo carattere della parola chiave nome e il primo carattere della parola chiave cognome

                            indSurname += SURNAME_KEYWORD.Length;
                            string surname = line.Substring(indSurname, indCF - indSurname); // il cognome è compreso tra l'ultimo carattere della parola chiave cognome e il primo carattere della parola chiave codice fiscale

                            indCF += CF_KEYWORD.Length;
                            string cf = line.Substring(indCF, indTipoLavoro - indCF); // il cognome è compreso tra l'ultimo carattere della parola chiave cognome e il primo carattere della parola chiave codice fiscale

                            string dataNascita = "07/10/1978";

                            if (indTipoLavoro < (line.Length - 1)) // se non si è arrivati a fine stringa...
                            {
                                // significa che la persona lavora
                                indTipoLavoro += TIPO_LAVORO_KEYWORD.Length;
                                string tipoLavoro = line.Substring(indTipoLavoro, line.Length - indTipoLavoro);

                                switch (tipoLavoro)
                                {
                                    case "Informatico":
                                        list.Add(new Informatico(cf, name, surname, dataNascita, 1600, "python"));
                                        break;

                                    case "Operaio":
                                        list.Add(new Operaio(cf, name, surname, dataNascita, 1200, "Azienda"));
                                        break;

                                    case "Meccanico":
                                        list.Add(new Meccanico(cf, name, surname, dataNascita, 1400, "Officina"));
                                        break;
                                }
                            }
                            else
                            {
                                list.Add(new Persona(name, surname, cf, dataNascita));
                            }
                        }
                        streamReader.Close();
                    }

                    Console.WriteLine("Stampa della lista delle persone ");
                    foreach (Persona persona in list)
                    {
                        if (persona is Lavoratore)
                        {
                            Console.WriteLine("\n La persona lavora!");
                            Lavoratore lavoratore = (Lavoratore)persona;

                            if (lavoratore is Operaio)
                            {
                                Console.WriteLine("\n Il lavoratore è un operaio");
                                Console.WriteLine(((Operaio)lavoratore).ToString());
                            }
                            else if (lavoratore is Meccanico)
                            {
                                Console.WriteLine("\n Il lavoratore è un meccanico");
                                Console.WriteLine(((Meccanico)lavoratore).ToString());
                            }
                            else if (lavoratore is Informatico)
                            {
                                Console.WriteLine("\n Il lavoratore è un informatico");
                                Console.WriteLine(((Informatico)lavoratore).ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n La persona è disoccupata");
                            Console.WriteLine(persona.ToString());
                        }
                    }
                }

                File.Delete(path);
            } catch (Exception ex)
            {
                Console.WriteLine("L'operazione ha dato errore: " + ex.Message);
                Console.WriteLine("Tipo d'errore: " + ex.GetType());
            }
        }
    }
}
