namespace Labb1_PLB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string exempelText = "29535123p48723487597645723645";

            LetaOchMarkeraSiffror(exempelText);
            void LetaOchMarkeraSiffror(string sökSträng)
            {
                SökIgenomSträng(sökSträng);

            }

            void SökIgenomSträng(string strängAttSöka, int aktuellSiffra = 0)
            {
                string tempSträng = "";
                string klarSträng = "";
                bool sättTillRöd = false;
                for (int i = 0; i < strängAttSöka.Length; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (strängAttSöka[i].Equals('2'))
                    {
                        aktuellSiffra = 2;
                        sättTillRöd = true;
                        
                        Console.WriteLine("aktuell position: " + i);
                            klarSträng += strängAttSöka[i];
                        if (klarSträng[i].Equals('2') && i !=0)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine(klarSträng);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Hittade siffran");
                            aktuellSiffra += 1;
                        }

                    }
                    else
                    {
                        klarSträng += strängAttSöka[i];
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                }
            }
        }



    }
}