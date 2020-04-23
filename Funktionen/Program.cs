using System;

namespace Funktionen
{
    class Program
    {
        /// <summary>
        /// Berechnet Absolutwert des Parameters
        /// </summary>
        /// <param name="x">double Wert</param>
        /// <returns>Den Betrag des Parameters</returns>
        static double MyAbs(double x)
        {
            if (x<0)
            {
                x *= (-1);
            }
            double betrag = x;
            return betrag;
        }

        /// <summary>
        /// Berechnet Sinus vom Parameter
        /// </summary>
        /// <param name="x">double Wert</param>
        /// <returns>Sinus</returns>
        static double MySin(double x)
        {
            double n = 1, y = x, sin = x;//n - Nenner
            while (MyAbs(y) >= 1e-16)//1e-16=10^15
            {
                y = y * (x * x) / ((n + 1) * (n + 2)) * (-1);
                sin = sin + y;
                //z.B. bei dem 1. Verlauf: sin(x) = x + (- (x*x*x)/2*3) 
                //Das gleicht der Formel: sin(x) = x/1! - x^3/3! = x - x*x*x/2*3
                n = n + 2;//Macht den Schritt (in der Formel: "x/1!-x/3!+..." => 3-1=2)
            }
            return sin;
        }

        /// <summary>
        /// Berechnet Anzahl von  mehrfach vorkommenden Werten in einem sortierten Feld
        /// </summary>
        /// <param name="sortiertesFeld">integer Feld</param>
        /// <returns>Anzahl von verdoppelten Zahlen</returns>
        static int AnzahlDoppelte(int[] sortiertesFeld)
        {
            int anzahl = 0;
            for (int j = 1; j < sortiertesFeld.Length; j++) 
            {
                int k = j - 1;//index vom Element links
                if (sortiertesFeld[j] == sortiertesFeld[k])
                {
                    anzahl++;
                }
            }
            return anzahl;
        }

        static void Main(string[] args)
        {
            #region MyAbs-Test
            Console.WriteLine("Test für MyAbs-Funktion:\n");
            //Genegiert zufällige double Zahl für die 1. Aufgabe
            double zahl;
            Random rnd = new Random();
            int i;
            for (i = 1; i <= 10; i++)
            {
                zahl = rnd.NextDouble() * 10; //*10 damit der Wert größer als 1 wird
                if (i % 2 == 1) //Ungerade Zahlen bekommen '-' als Vorzeichen (werden negativ)
                {
                    zahl *= (-1);
                }
                Console.WriteLine($"{i,2}. zahl: {zahl,14:f8}  ->  Betrag: {MyAbs(zahl),14:f8}");
            }
            Console.WriteLine("\n");
            #endregion

            #region Sinus
            Console.WriteLine("Vergleich für Sinus-Funktion:\n");
            double summ = 0;//Summe der Fehler
            for (double p = -Math.PI; p <= Math.PI; p += (Math.PI * 2) / 20)
            {
                double sin = Math.Sin(p);
                double mySin = MySin(p);
                double diff = sin - mySin;
                summ += MyAbs(diff);
                Console.WriteLine($"{p,12:f6}:  syn(x)= {sin,12:f6},  MySin(x)= {mySin,12:f6},  Diff:  {diff}");
            }
            Console.WriteLine($"Summe der Fehler:  {summ}\n");
            #endregion
           
            #region Sortiertes Feld
            int zaehler = 0; //Zähler für Zeilenumbruch
            //Generiert das Feld mit zufälligen Zahlen 
            int[] zahlen = new int[100]; 
            Random newRnd = new Random();
            for (int a = 0; a < zahlen.Length; a++)
            {
                zahlen[a] = newRnd.Next(0, 100);
            }
            Array.Sort(zahlen);//sortiert das Feld von kleineren zu größeren Zahlen
            //Gibt das ganze sortierte Feld aus
            for (int a = 0; a < zahlen.Length; a++)
            {
                Console.Write($"{zahlen[a],5}");
                zaehler++;
                if (zaehler == 10)
                {
                    Console.WriteLine();
                    zaehler = 0;
                }
            }
            Console.WriteLine($"Anzahl Doppelte: {AnzahlDoppelte(zahlen)}");
            #endregion

            Console.ReadKey();
        }
    }
}
