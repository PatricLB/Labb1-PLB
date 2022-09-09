namespace Labb1_PLB
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Nästa steg. Gör en sök som kollar efter aktuell siffra med binary search. Sätt sedan den "rangen" som röd. 

            // Jag vill ha en metod som söker igenom en sträng efter 2 sökord i följd. När den hittat första "ordet" så sätter metoden indexet på första ordet i en array, samma sak med andra. - KLAR
            // Efter det så tar en annan metod in samma söksträng och sätter en highlight på orden emellan dem indexen. 
            // Sökmetodens parametrar är "söksträngen" och aktuell "siffra" den skall kolla efter.
            // Ifall metoden ser en icke siffra, så skall den hoppa över den och söka i resten av strängen istället. Den gör detta igenom att ta bort siffrorna innan och påbörja på siffran efter tecknet

            // Tanke: Om man kör sökmetoden via en array istället så kan man ta alla positioner, sätt färg röd när den hittat indexpositionerna för att sen sätta grå när indexet är större än positionen igen.
            // Det kräver att jag skriver om hela metoden att fungera med arrayer dock.
            string exempelText = "29535123p48723487597645723645";


            //Testa siffrorna 0-9
            char[] arrayMedSiffrorIChar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


            //Console.WriteLine("Aktuell siffra är: " + aktuellSiffra);
            //SökGenomSträngOchReturneraPositionAochB(exempelText, '2');
            //SökGenomArrayOchReturneraPosition1och2(exempelText, aktuellSiffra);
            char[] myCharArray; myCharArray = görStringTillCharArray(exempelText);
            gåGenomSträng1SiffraÅtGången(myCharArray);

            // Uppgiften verkar gå igenom strängen för varje tecken som finns i strängen.
            // Har strängen 20 tecken så är det 20 gången loopen kollar. Man kollar sen på sträng positionen [i]+1 (Där i är hur många gånger man kört igenom strängen sen start) från tidigare iterationer. 
            // Blir [i] == sträng.length så avslutar man metoden.
            int[] SökGenomArrayOchReturneraPosition1och2(List<char> data, char sökOrd)
            {
                int[] array = new int[2] { -1, -2 };
                string temp;
                string fullSträng = "";
                bool isBokstav = false;

                int längdPåHanteradSträng;
                for (int i = 0; i < data.Count; i++)
                {
                    isBokstav = false;
                    Console.WriteLine($"Detta är data[{i}]: {data[i]}");
                    if ((data[i] == sökOrd && array[0].Equals(-1)))
                    {
                        array[0] = i;
                        Console.WriteLine($"array[0] har värdet: {array[0]} ");
                    }
                    else if ((data[i] == sökOrd && array[1] == -2) && array[0] != -1)
                    {
                        array[1] = i;
                        Console.WriteLine($"array[1] har värdet: {array[1]} ");
                        break;
                    }
                    //Denna delen skall nog vara i en övergripande metod högre i arkitekturen
                    else if ((!char.IsDigit(data[i])) && array[0] != -1)
                    {
                        Console.WriteLine("Nu kom det en bokstav. Inte giltlig");
                        isBokstav = true;
                        break;
                    }
                }
                längdPåHanteradSträng = 1 + array[1] - array[0];
                for (int i = 0; i < data.Count; i++)
                {
                    fullSträng += data[i];
                }
                if (!isBokstav)
                {
                    Console.WriteLine($"1: Siffran {sökOrd}");
                    temp = fullSträng.Substring(array[0], längdPåHanteradSträng);
                    Console.WriteLine("Detta är temp: " + temp);
                    Console.WriteLine($"1: Siffran {sökOrd} har position: {array[0]}");
                    Console.WriteLine($"2: Siffran {sökOrd} har position: {array[1]}");

                    return array;
                }
                else
                {
                    return null;
                }
                

            }



            // Tanke: Nu skickar jag in en kortare lista hela tiden. Det resulterar i att indexet alltid blir 0 i kolla siffror metoden. Jag håller nu inte koll på vilka siffror som kommit innan. Dock vet jag vilket index jag börjar på i denna metoden
            // Man skulle kunna skriva ut all text innan man börjar gå igenom strängen och göra den röd ifall det blir match.
            // Hantera returnvärdena som "SökGenomArrayOchReturneraPosition1och2" returnerar och skriv ut text baserat på det.
            void gåGenomSträng1SiffraÅtGången(char[] data)
            {
                char aktuellSiffra;
                List<char> hållText = new List<char>();
                
                for (int indexPåSträng = 0; indexPåSträng < data.Length; indexPåSträng++)
                {
                    //aktuellSiffra = arrayMedSiffrorIChar[indexPåSträng];
                    for (int charPos = 0; charPos < data.Length; charPos++)
                    {

                        if ((charPos + indexPåSträng) >= data.Length)
                        {
                            break;
                        }
                        else
                        {
                            //Console.Write(data[charPos + indexPåSträng]);
                            hållText.Add(data[charPos + indexPåSträng]);
                            //hållText += data[charPos + indexPåSträng].ToString();
                            //SökGenomArrayOchReturneraPosition1och2(data, aktuellSiffra);
                        }
                        //Console.Write($"Detta är vad 'hållText' håller: {hållText} ");
                        //Console.Write(hållText);
                        //SökGenomArrayOchReturneraPosition1och2(data, aktuellSiffra);
                    }
                    // Skriv ut listan och rensa den efter varje hel körning
                    for (int i = 0; i < hållText.Count; i++)
                    {
                        Console.Write(hållText[i]);

                    }
                    Console.Write(' ');

                    aktuellSiffra = hållText[0];
                    // Här skall metoden ligga som letar efter siffrorna
                    // Gör någonting med hålltext här. Ex ta första charen i strängen 
                    if (char.IsDigit(aktuellSiffra))
                    {
                    SökGenomArrayOchReturneraPosition1och2(hållText, aktuellSiffra);

                    }
                    else
                    {
                        Console.WriteLine("Inte en siffra. Fortsätt med nästa");
                    }
                    // Rensa hålltext för att påbörja nästa rad
                    hållText.Clear();
                    Console.WriteLine();
                }

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
            char[] görStringTillCharArray(string sträng)
            {
                char[] tempArray = new char[sträng.Length];
                for (int i = 0; i < sträng.Length; i++)
                    tempArray[i] = sträng[i];

                return tempArray;
            }
        }

    }
    /* void SökIgenomSträng(string strängAttSöka, int aktuellSiffra = 0)
        {
            string tempSträng = "";
            string klarSträng = "";
            bool sättTillRöd = false;
            int count = 0;
            for (int i = 0; i < strängAttSöka.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                if (strängAttSöka[i].Equals('2'))
                {
                    // aktuellSiffra = 2;
                    sättTillRöd = true;

                    Console.WriteLine("aktuell position: " + i);
                    klarSträng += strängAttSöka[i];
                    if (klarSträng[i].Equals('2') && i != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(klarSträng);
                        Console.BackgroundColor = ConsoleColor.Black;
                        //aktuellSiffra += 1;
                    }

                }
                else
                {
                    klarSträng += strängAttSöka[i];
                    Console.BackgroundColor = ConsoleColor.Black;
                }

            }
        } */
    /* void SökGenomSträngOchReturneraPositionAochB(string data, char sökOrd)
    {
        int[] array = new int[2] { -1, -2 };
        string temp;
        char[] tempArray = new char[data.Length];
        int längdPåHanteradSträng;
        string slutetPåSträng;
        for (int i = 0; i < data.Length; i++)
        {


            if ((data[i] == sökOrd && array[0].Equals(-1)))
            {
                array[0] = i;
            }
            else if ((data[i] == sökOrd && array[1] == -2) && array[0] != -1)
            {
                array[1] = i;
            }
            else if (!char.IsDigit(data[i]))
            {
                Console.WriteLine("Nu kom det en bokstav. ");

                // Ta bort allt innan bokstaven
                // data =  data.Substring(1 + array[1] - array[0], data.Length-1 );

            }
        }
        längdPåHanteradSträng = 1 + array[1] - array[0];
        temp = data.Substring(array[0], längdPåHanteradSträng);
        Console.WriteLine($"temp sträng innehåller: {temp}");
        Console.WriteLine($"Array[1] är: {array[1]}");
        Console.WriteLine($"Data.length är: {data.Length}");
        Console.WriteLine("restvärde i sträng är: " + (data.Length - längdPåHanteradSträng));
        slutetPåSträng = data.Substring(array[1] + 1);
        Console.Write(slutetPåSträng);

    } */
}
