using System.Collections.Generic;

namespace Labb1_PLB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Original teststräng: "29535123p48723487597645723645"
            Console.Write("Skriv ditt input: "); string inputFrånAnvändaren = Console.ReadLine();
            List<char> inputSträngSomLista = görStringTillLista(inputFrånAnvändaren);
            List<long> tallSomSkallSummeras = new();
            
            HittaTalISträngMedTecken(inputFrånAnvändaren);

            List<char> görStringTillLista(string sträng)
            {
                List<char> tempArray = new List<char>();
                for (int i = 0; i < sträng.Length; i++)
                    tempArray.Add(sträng[i]);

                return tempArray;
            }
           
            void HittaTalISträngMedTecken(string inputSträng)
            {
                long summanAvAllaTal;
                gåGenomListaEnSiffraÅtGången(inputSträngSomLista);
                summanAvAllaTal = SummeraTalen(tallSomSkallSummeras);
                Console.WriteLine($"Summan av talen är: {summanAvAllaTal}");
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
                        SkrivUtTextMedRödFärg(inputFrånAnvändaren, strängSomSkaVaraRöd, indexPåSträng);
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
            
            string SökGenomListaOchReturneraGiltligSträng(List<char> delSträngAvInput, char aktuellSiffraSOmChar)
            {
                int[] array = new int[2] { 0,0 };
                bool harViFörstaSiffran = false;
                bool harViAndraGemensammasiffran = false;
                int längdPåHanteradSträng;
                int startPosition;
                string giltligSträng;


                for (int i = 0; i < delSträngAvInput.Count; i++)
                {

                    if (delSträngAvInput[i] == aktuellSiffraSOmChar && harViFörstaSiffran == false)
                    {
                        array[0] = i;
                        harViFörstaSiffran = true;
                    }
                    else if ((delSträngAvInput[i] == aktuellSiffraSOmChar && harViAndraGemensammasiffran == false) && harViFörstaSiffran == true)
                    {
                        array[1] = i;
                        harViAndraGemensammasiffran = true;
                        break;
                    }
                    else if ((!char.IsDigit(delSträngAvInput[i])))
                    {
                        return null;
                    }
                }
                längdPåHanteradSträng = 1 + array[1] - array[0];

                startPosition = array[0];

                giltligSträng = ReturneraSifferordning(delSträngAvInput, längdPåHanteradSträng, startPosition);
                return giltligSträng;

            }
           
            string ReturneraSifferordning(List<char> delSträngAvInput, int längdPåHanteradSträng, int startPosition)
            {
                string sifferordning;
                string fullSträng = "";
                for (int i = 0; i < delSträngAvInput.Count; i++)
                {
                    fullSträng += delSträngAvInput[i];
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
            
            void SkrivUtTextMedRödFärg(string helaInputSträngen, string strängSomSkaVaraRöd, int startIndexPåRödSträng)
            {
                string temporärSträng;
                string nyKlarSträng;

                temporärSträng = helaInputSträngen.Remove(startIndexPåRödSträng, strängSomSkaVaraRöd.Length);
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

                }else if (färgVal && siffransLängd <= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;

                }else if (färgVal && siffransLängd > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                }else if (!färgVal)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            long SummeraTalen(List<long> korrektTal)
            {
                long summa = 0;
                for (int i = 0; i < korrektTal.Count; i++)
                {
                    summa += korrektTal[i];
                }
                return summa;
            }

        }

    }
}
