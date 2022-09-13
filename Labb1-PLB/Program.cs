using System.Collections.Generic;

namespace Labb1_PLB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputSträng = "29535123p48723487597645723645";
            List<long> tallSomSkallSummeras = new();


            char[] strängSomCharArray = görStringTillCharArray(inputSträng);

            // Startmetoder:
            gåGenomSträng1SiffraÅtGången(strängSomCharArray);
            SummeraTalen(tallSomSkallSummeras);

            void gåGenomSträng1SiffraÅtGången(char[] inputSträngSomCharArray)
            {
                long nummerAttAddera;
                char aktuellSiffraSOmChar;
                List<char> hållText = new();
                int[] arrayMedPositioner = { 0, 0 };
                string strängSomSkaVaraRöd;

                for (int indexPåSträng = 0; indexPåSträng < inputSträngSomCharArray.Length; indexPåSträng++)
                {
                    for (int charPosition = 0; charPosition < inputSträngSomCharArray.Length; charPosition++)
                    {
                        if ((charPosition + indexPåSträng) >= inputSträngSomCharArray.Length)
                        {
                            break;
                        }
                        else
                        {
                            hållText.Add(inputSträngSomCharArray[charPosition + indexPåSträng]);
                        }
                    }
                    // Skriv ut listan och rensa den efter varje körning
                    aktuellSiffraSOmChar = hållText[0];
                    // Här skall metoden ligga som letar efter siffrorna
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
                            nummerAttAddera = long.Parse(strängSomSkaVaraRöd);
                            tallSomSkallSummeras.Add(nummerAttAddera);
                        }
                    }
                    // Rensa hålltext för att påbörja nästa rad
                    hållText.Clear();
                }
            }
            string SökGenomListaOchReturneraGiltligSträng(List<char> data, char aktuellSiffraSOmChar)
            {
                int[] array = new int[2] { -1, -2 };
                string sifferordning;
                string fullSträng = "";
                bool isBokstav = false;
                int längdPåHanteradSträng;

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
                for (int i = 0; i < data.Count; i++)
                {
                    fullSträng += data[i];
                }
                if (!isBokstav && längdPåHanteradSträng != -1)
                {
                    sifferordning = fullSträng.Substring(array[0], längdPåHanteradSträng);
                    isBokstav = false;
                    return sifferordning;
                }
                else
                {
                    return null;
                }


            }
            char[] görStringTillCharArray(string sträng)
            {
                char[] tempArray = new char[sträng.Length];
                for (int i = 0; i < sträng.Length; i++)
                    tempArray[i] = sträng[i];

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
