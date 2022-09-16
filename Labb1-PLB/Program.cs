namespace Labb1_PLB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputSträng = "29535123p48723487597645723645";
            List<char> strängSomCharArray = görOmStringTillLista(inputSträng);

            List<long> tallSomSkallSummeras = new();
            long summanAvAllaTal;

            // Startmetoder:
            gåGenomSträng1SiffraÅtGången(strängSomCharArray);

            summanAvAllaTal = SummeraTalen(tallSomSkallSummeras);
            Console.WriteLine($"Summan av alla tal är: {summanAvAllaTal}");


            List<char> görOmStringTillLista(string sträng)
            {
                List<char> tempArray = new List<char>();
                for (int i = 0; i < sträng.Length; i++)
                    tempArray.Add(sträng[i]);

                return tempArray;
            }
            void gåGenomSträng1SiffraÅtGången(List<char> inputSträngSomCharArray)
            {
                char aktuellSiffraSomChar;
                List<char> hållText = new();
                //int[] arrayMedPositioner = { 0, 0 };

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
                    aktuellSiffraSomChar = hållText[0];
                    FinnsDetEnSifferRad(hållText, aktuellSiffraSomChar, indexPåSträng);
                    hållText.Clear();
                }
            }
            void FinnsDetEnSifferRad(List<char> hållText, char aktuellSiffraSOmChar, int indexPåSträng)
            {
                ulong nummerAttAddera;
                string strängSomSkaVaraRöd;
                try
                {
                    if (char.IsDigit(aktuellSiffraSOmChar))
                    {
                        strängSomSkaVaraRöd = SökGenomListaOchReturneraGiltligSträng(hållText, aktuellSiffraSOmChar);

                        SkrivUtTextMedRödFärg(inputSträng, strängSomSkaVaraRöd, indexPåSträng);
                        Console.WriteLine();
                        nummerAttAddera = ulong.Parse(strängSomSkaVaraRöd);
                        tallSomSkallSummeras.Add((long)nummerAttAddera);
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
            string SökGenomListaOchReturneraGiltligSträng(List<char> data, char aktuellSiffraSOmChar)
            {
                int[] arrayMedSifferPositioner = new int[2] { 0, 0 };
                bool harViFörstaSiffran = false;
                bool harViAndraGemensammaSiffran = false;
                int längdPåHanteradSträng;
                int startPosition;
                string returSträng;
                try
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        //Hämta index på första siffran
                        if (data[i] == aktuellSiffraSOmChar && harViFörstaSiffran == false)
                        {
                            arrayMedSifferPositioner[0] = i;
                            harViFörstaSiffran = true;
                        }
                        //Hämta index på andra siffran och bryt loopen då vi hittat andra indexet.
                        else if ((data[i] == aktuellSiffraSOmChar && harViAndraGemensammaSiffran == false) && harViFörstaSiffran == true)
                        {
                            arrayMedSifferPositioner[1] = i;
                            harViAndraGemensammaSiffran = true;
                        }
                        else if ((!char.IsDigit(data[i])))
                        {
                            return null;
                        }
                    }
                    längdPåHanteradSträng = 1 + arrayMedSifferPositioner[1] - arrayMedSifferPositioner[0];
                    startPosition = arrayMedSifferPositioner[0];

                    returSträng = ReturneraSifferordning(data, längdPåHanteradSträng, startPosition);

                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }

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
                sifferordning = fullSträng.Substring(startPosition, längdPåHanteradSträng);

                return sifferordning;

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
                return sum;
            }

        }

    }
}
