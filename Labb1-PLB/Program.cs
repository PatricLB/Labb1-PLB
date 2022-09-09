using System.Collections.Generic;

namespace Labb1_PLB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string exempelInput = "77788777888777887";
            List<long> tallSomSkallSummeras = new();


            char[] myCharArray = görStringTillCharArray(exempelInput);

            // Startmetoder:
            gåGenomSträng1SiffraÅtGången(myCharArray);
            SummeraTalen(tallSomSkallSummeras);


            void gåGenomSträng1SiffraÅtGången(char[] exempelInputSomCharArray)
            {
                char aktuellSiffra;
                List<char> hållText = new();
                int[] arrayMedPositioner = { 0, 0 };
                string talFöljd;

                for (int indexPåSträng = 0; indexPåSträng < exempelInputSomCharArray.Length; indexPåSträng++)
                {
                    for (int charPos = 0; charPos < exempelInputSomCharArray.Length; charPos++)
                    {
                        if ((charPos + indexPåSträng) >= exempelInputSomCharArray.Length)
                        {
                            break;
                        }
                        else
                        {
                            hållText.Add(exempelInputSomCharArray[charPos + indexPåSträng]);
                        }
                    }
                    // Skriv ut listan och rensa den efter varje körning
                    aktuellSiffra = hållText[0];
                    // Här skall metoden ligga som letar efter siffrorna
                    if (char.IsDigit(aktuellSiffra))
                    {
                        talFöljd = SökGenomListaOchReturneraGiltligSträng(hållText, aktuellSiffra);

                        if (talFöljd == null)
                        {
                            // Ingen talföljd tillgänglig.
                        }
                        else
                        {
                            SättIhopSträngarMedFärg(exempelInput, talFöljd);
                            Console.WriteLine();
                        }
                    }
                    // Rensa hålltext för att påbörja nästa rad
                    hållText.Clear();
                }
            }
            string SökGenomListaOchReturneraGiltligSträng(List<char> data, char sökOrd)
            {
                int[] array = new int[2] { -1, -2 };
                string sifferordning;
                string fullSträng = "";
                bool isBokstav = false;
                int längdPåHanteradSträng;

                for (int i = 0; i < data.Count; i++)
                {
                    //Hämta index på första siffran
                    if ((data[i] == sökOrd && array[0].Equals(-1)))
                    {
                        array[0] = i;
                    }
                    //Hämta index på andra siffran och bryt loopen då vi hittat andra indexet.
                    else if ((data[i] == sökOrd && array[1] == -2) && array[0] != -1)
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
            void SättIhopSträngarMedFärg(string helaSträngen = "", string strängSomSkaVaraRöd = "")
            {
                long siffra = 0;
                string temporärSträng = "";
                int indexDärSubSträngStartar;
                string nyKlarSträng = "";

                // Följande kod är ett problem. Den tar bort en del av originalsträngen baserat på unika tecken. Detta fungerar inte ifall man bara skriver in tex 1111,222222,3333333 etc.
                // Måste antagligen göra om hela logiken för detta i så fall
                // Index positioner kanske är the way to go ändå.

                indexDärSubSträngStartar = helaSträngen.IndexOf(strängSomSkaVaraRöd);
                temporärSträng = helaSträngen.Replace(strängSomSkaVaraRöd, "");
                //Console.WriteLine("helaSträngen: " + helaSträngen);
                //Console.WriteLine("Strängen som skall tas bort: " + strängSomSkaVaraRöd);
                //Console.WriteLine("temporärSträng: " + temporärSträng);

                //Console.WriteLine("indexDärSubSträngStartar: " + indexDärSubSträngStartar);
                for (int i = 0; i < temporärSträng.Length; i++)
                {
                    if (i == indexDärSubSträngStartar)
                    {
                        SättFärg("röd");
                        for (int j = 0; j < strängSomSkaVaraRöd.Length; j++)
                        {
                            nyKlarSträng = strängSomSkaVaraRöd[j].ToString();
                            Console.Write(nyKlarSträng);
                        }
                        SättFärg("grå");
                    }
                    nyKlarSträng = temporärSträng[i].ToString();
                    Console.Write(nyKlarSträng);

                }
                if (indexDärSubSträngStartar == temporärSträng.Length)
                {
                    SättFärg("röd");
                    Console.Write(strängSomSkaVaraRöd);
                    SättFärg("grå");
                }
                siffra = long.Parse(strängSomSkaVaraRöd);
                tallSomSkallSummeras.Add(siffra);

            }
            void SättFärg(string färgVal)
            {
                if (färgVal.Equals("röd"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                }
                else if (färgVal.Equals("grå"))
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
        }

    }
}
