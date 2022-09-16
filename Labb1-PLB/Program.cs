using System.Collections.Generic;

namespace Labb1_PLB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputSträng = "29535123p48723487597645723645";
            List<long> tallSomSkallSummeras = new();

            List<char> strängSomCharArray = görStringTillCharArray(inputSträng);

            // Startmetoder:
            gåGenomSträng1SiffraÅtGången(strängSomCharArray);
            SummeraTalen(tallSomSkallSummeras);

            void gåGenomSträng1SiffraÅtGången(List<char> inputSträngSomCharArray)
            {
                ulong nummerAttAddera;
                char aktuellSiffraSomChar;
                List<char> hållText = new();
                int[] arrayMedPositioner = { 0, 0 };
                string strängSomSkaVaraRöd;

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
                            hållText.Add(inputSträngSomCharArray[charPosition + indexPåSträng]);
                        }
                    }
                    // Skriv ut listan och rensa den efter varje körning
                    aktuellSiffraSomChar = hållText[0];
                    // Här skall metoden ligga som letar efter siffrorna
                    // FinnsDetEnSifferRad
                    FinnsDetEnSifferRad(hållText, aktuellSiffraSomChar, indexPåSträng);
                    //if (char.IsDigit(aktuellSiffraSomChar))
                    //{
                    //    strängSomSkaVaraRöd = SökGenomListaOchReturneraGiltligSträng(hållText, aktuellSiffraSomChar);

                    //    if (strängSomSkaVaraRöd == null)
                    //    {
                    //        // Ingen talföljd tillgänglig.
                    //    }
                    //    else
                    //    {
                    //        SkrivUtTextMedRödFärg(inputSträng, strängSomSkaVaraRöd, indexPåSträng);
                    //        Console.WriteLine();
                    //        nummerAttAddera = ulong.Parse(strängSomSkaVaraRöd);
                    //        tallSomSkallSummeras.Add((long)nummerAttAddera);
                    //    }
                    //}
                    // Rensa hålltext för att påbörja nästa rad
                    hållText.Clear();
                }
            }
            void FinnsDetEnSifferRad(List<char> hållText, char aktuellSiffraSOmChar, int indexPåSträng)
            {
                ulong nummerAttAddera;
                string strängSomSkaVaraRöd;
                if (char.IsDigit(aktuellSiffraSOmChar))
                {
                    strängSomSkaVaraRöd = SökGenomListaOchReturneraGiltligSträng(hållText, aktuellSiffraSOmChar);

                    if (strängSomSkaVaraRöd == null)
                    {
                        // Ingen talföljd tillgänglig.
                    }
                    else
                    {
                        SkrivUtTextMedRödFärg(inputSträng, strängSomSkaVaraRöd, indexPåSträng);
                        Console.WriteLine();
                        nummerAttAddera = ulong.Parse(strängSomSkaVaraRöd);
                        tallSomSkallSummeras.Add((long)nummerAttAddera);
                    }
                }
            }
            string SökGenomListaOchReturneraGiltligSträng(List<char> data, char aktuellSiffraSOmChar)
            {
                int[] array = new int[2] { -1, -2 };
                bool isBokstav = false;
                int längdPåHanteradSträng;
                int startPosition;
                string returSträng;


                for (int i = 0; i < data.Count; i++)
                {
                    //Hämta index på första siffran
                    if ((data[i] == aktuellSiffraSOmChar && array[0].Equals(-1)))
                    {
                        array[0] = i;
                    }
                    //Hämta index på andra siffran och bryt loopen då vi hittat andra indexet.
                    else if ((data[i] == aktuellSiffraSOmChar && array[1] == -2) && array[0] != -1)
                    {
                        array[1] = i;
                        break;
                    }
                    //Denna delen skall nog vara i en övergripande metod högre i arkitekturen
                    else if ((!char.IsDigit(data[i])) && array[0] != -1)
                    {
                        isBokstav = true;
                        break;
                    }
                }
                längdPåHanteradSträng = 1 + array[1] - array[0];

                // Nedan del bör kunna vara i en egen metod istället.
                startPosition = array[0];
                returSträng = ReturneraSifferordning(data, längdPåHanteradSträng, startPosition, isBokstav);

                return returSträng;


            }
            string ReturneraSifferordning(List<char> data, int längdPåHanteradSträng, int startPosition, bool isBokstav = false)
            {
                string sifferordning;
                string fullSträng = "";
                for (int i = 0; i < data.Count; i++)
                {
                    fullSträng += data[i];
                }
                if (!isBokstav && längdPåHanteradSträng != -1)
                {
                    sifferordning = fullSträng.Substring(startPosition, längdPåHanteradSträng);
                    isBokstav = false;
                    return sifferordning;
                }
                else
                {
                    return null;
                }
                

            }
            List<char> görStringTillCharArray(string sträng){
                List<char> tempArray = new List<char>();
                for (int i = 0; i < sträng.Length; i++)
                    tempArray.Add(sträng[i]);

                return tempArray;
            }

            void SättFärgTillRöd(bool färgVal)
            {
                if (färgVal)
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

                Console.WriteLine("Summan av talen är: " + sum);
                return sum;
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
                        SättFärgTillRöd(true);
                        for (int j = 0; j < strängSomSkaVaraRöd.Length; j++)
                        {
                            nyKlarSträng = strängSomSkaVaraRöd[j].ToString();
                            Console.Write(nyKlarSträng);
                        }
                        SättFärgTillRöd(false);
                    }
                    nyKlarSträng = temporärSträng[i].ToString();
                    Console.Write(nyKlarSträng);

                }
                if (startIndexPåRödSträng == temporärSträng.Length)
                {
                    SättFärgTillRöd(true);
                    Console.Write(strängSomSkaVaraRöd);
                    SättFärgTillRöd(false);
                }
            }

        }

    }
}
