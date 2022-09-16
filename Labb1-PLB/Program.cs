using System.Collections.Generic;

namespace Labb1_PLB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputSträng = "29535123p48723487597645723645";
            List<char> inputSträngSomLista = görStringTillLista(inputSträng);
            List<long> tallSomSkallSummeras = new();
            long summanAvAllaTal;

            // Startmetoder:
            gåGenomListaEnSiffraÅtGången(inputSträngSomLista);
            summanAvAllaTal = SummeraTalen(tallSomSkallSummeras);
            Console.WriteLine($"Summan av talen är: {summanAvAllaTal}");

            List<char> görStringTillLista(string sträng)
            {
                List<char> tempArray = new List<char>();
                for (int i = 0; i < sträng.Length; i++)
                    tempArray.Add(sträng[i]);

                return tempArray;
            }
           
            void gåGenomListaEnSiffraÅtGången(List<char> inputSträngSomCharArray)
            {
                char aktuellSiffraSomChar;
                List<char> delSträngAvInput = new();


                for (int indexPåSträng = 0; indexPåSträng < inputSträngSomCharArray.Count; indexPåSträng++)
                {
                    for (int charPosition = 0; charPosition < inputSträngSomCharArray.Count; charPosition++)
                    {
                        if ((charPosition + indexPåSträng) >= inputSträngSomCharArray.Count)
                        {
                            break;
                        }
                        else
                        {
                            delSträngAvInput.Add(inputSträngSomCharArray[charPosition + indexPåSträng]);
                        }
                    }
                    aktuellSiffraSomChar = delSträngAvInput[0];
                    KollaOmDelsträngÄrGiltig(delSträngAvInput, aktuellSiffraSomChar, indexPåSträng);
                    delSträngAvInput.Clear();
                }
            }
           
            void KollaOmDelsträngÄrGiltig(List<char> delSträngAvInput, char aktuellSiffraSomChar, int indexPåSträng)
            {
                long nummerAttAddera;
                string strängSomSkaVaraRöd;
                if (char.IsDigit(aktuellSiffraSomChar))
                {
                    strängSomSkaVaraRöd = SökGenomListaOchReturneraGiltligSträng(delSträngAvInput, aktuellSiffraSomChar);

                    if (strängSomSkaVaraRöd != null && strängSomSkaVaraRöd.Length > 1)
                    {
                        SkrivUtTextMedRödFärg(inputSträng, strängSomSkaVaraRöd, indexPåSträng);
                        Console.WriteLine();
                        nummerAttAddera = long.Parse(strängSomSkaVaraRöd);
                        tallSomSkallSummeras.Add(nummerAttAddera);
                    }
                    else
                    {
                        // Ingen giltlig talföljd tillgänglig.
                    }
                }
            }
            
            string SökGenomListaOchReturneraGiltligSträng(List<char> data, char aktuellSiffraSOmChar)
            {
                int[] array = new int[2] { 0,0 };
                bool harViFörstaBokstaven = false;
                bool isAndraGemensammaBokstav = false;
                int längdPåHanteradSträng;
                int startPosition;
                string returSträng;


                for (int i = 0; i < data.Count; i++)
                {
                    //Hämta index på första siffran
                    if (data[i] == aktuellSiffraSOmChar && harViFörstaBokstaven == false)
                    {
                        array[0] = i;
                        harViFörstaBokstaven = true;
                    }
                    //Hämta index på andra siffran och bryt loopen då vi hittat andra indexet.
                    else if ((data[i] == aktuellSiffraSOmChar && isAndraGemensammaBokstav == false) && harViFörstaBokstaven == true)
                    {
                        array[1] = i;
                        isAndraGemensammaBokstav = true;
                        break;
                    }
                    //Denna delen skall nog vara i en övergripande metod högre i arkitekturen
                    else if ((!char.IsDigit(data[i])))
                    {
                        return null;
                    }
                }
                längdPåHanteradSträng = 1 + array[1] - array[0];

                startPosition = array[0];

                returSträng = ReturneraSifferordning(data, längdPåHanteradSträng, startPosition);
                return returSträng;

            }
           
            string ReturneraSifferordning(List<char> data, int längdPåHanteradSträng, int startPosition)
            {
                string sifferordning;
                string fullSträng = "";
                for (int i = 0; i < data.Count; i++)
                {
                    fullSträng += data[i];
                }
                if (längdPåHanteradSträng != 0)
                {
                    sifferordning = fullSträng.Substring(startPosition, längdPåHanteradSträng);
                    return sifferordning;
                }
                else
                {
                    return null;
                }
                

            }
            
            void SkrivUtTextMedRödFärg(string helaSträngen = "", string strängSomSkaVaraRöd = "", int startIndexPåRödSträng = 0)
            {
                string temporärSträng;
                string nyKlarSträng;

                temporärSträng = helaSträngen.Remove(startIndexPåRödSträng, strängSomSkaVaraRöd.Length);
                for (int i = 0; i < temporärSträng.Length; i++)
                {
                    if (i == startIndexPåRödSträng)
                    {
                        SättTillAnnanFärgBaseratPåLängd(true, strängSomSkaVaraRöd.Length);
                        for (int j = 0; j < strängSomSkaVaraRöd.Length; j++)
                        {
                            nyKlarSträng = strängSomSkaVaraRöd[j].ToString();
                            Console.Write(nyKlarSträng);
                        }
                        SättTillAnnanFärgBaseratPåLängd(false);
                    }
                    nyKlarSträng = temporärSträng[i].ToString();
                    Console.Write(nyKlarSträng);

                }
                if (startIndexPåRödSträng == temporärSträng.Length)
                {
                    SättTillAnnanFärgBaseratPåLängd(true, strängSomSkaVaraRöd.Length);
                    Console.Write(strängSomSkaVaraRöd);
                    SättTillAnnanFärgBaseratPåLängd(false);
                }
            }


            void SättTillAnnanFärgBaseratPåLängd(bool färgVal, int siffransLängd = 0)
            {
                if (färgVal && siffransLängd <= 4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                }else if (färgVal && siffransLängd <= 6)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;

                }
                else if (färgVal && siffransLängd <= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;

                }
                else if (färgVal && siffransLängd > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                }
                else if (!färgVal)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            long SummeraTalen(List<long> korrektTal)
            {
                long sum = 0;
                for (int i = 0; i < korrektTal.Count; i++)
                {
                    sum += korrektTal[i];
                }
                return sum;
            }

        }

    }
}
