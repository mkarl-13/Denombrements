using System;
namespace Denombrements
{
    /// <summary>
    /// Programme permettant à l'utilisateur d'obtenir le résultat de diverses opérations mathématiques telles que les permutations, les arrangements ou les combinaisons.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Module permettant de prendre en charge l'entrée par l'utilisateur d'un nombre, ainsi que de gérer les potentielles exceptions.
        /// </summary>
        static int SaisirNombre()
        {
            int nombre = 0;
            bool correct = false;
            while (!correct)
            {
                try
                {
                    nombre = int.Parse(Console.ReadLine());
                    correct = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Erreur: le nombre que vous avez entré est trop grand !");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur: veuillez entrer un nombre entier !");
                }
            }
            return nombre;
        }

        /// <summary>
        /// Permet de dénombrer le nombre de permutations d'un ensemble de total éléments.
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        static int Permutation(int total)
        {
            int resultat = 1;
            for (int k = 1; k <= total; k++)
            {
                resultat *= k;
            }
            return resultat;
        }

        /// <summary>
        /// Permet de dénombrer le nombre d'arrangements entre un ensemble de total éléments et un ensemble de nombre éléments.
        /// </summary>
        /// <param name="total"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        static int Arrangement(int total, int nombre)
        {
            int resultat = 1;
            for (int k = (total - nombre + 1); k <= total; k++)
            {
                resultat *= k;
            }
            return resultat;
        }

        /// <summary>
        /// Permet de dénombrer le nombre de combinaisons entre un ensemble de total éléments et un ensemble de nombre éléments.
        /// </summary>
        /// <param name="total"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        static long Combinaison(int total, int nombre)
        {
            long calcul1 = 1;
            long calcul2 = 1;
            long resultat;
            for (int k = (total - nombre + 1); k <= total; k++)
            {
                calcul1 *= k;
            }
            for (int k = 1; k <= nombre; k++)
            {
                calcul2 *= k;
            }
            resultat = calcul1 / calcul2;
            return resultat;
        }

        /// <summary>
        /// Classe principale.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int choix = 1;
            while (choix != 0)
            {
                int total = 0;
                int nombre = 0;
                long resultat;
                Console.WriteLine("Permutation ...................... 1");
                Console.WriteLine("Arrangement ...................... 2");
                Console.WriteLine("Combinaison ...................... 3");
                Console.WriteLine("Quitter .......................... 0");
                Console.Write("Choix :                            ");
                choix = SaisirNombre();
                if (choix != 0 && choix <= 3)
                {
                    // Entrée du nombre d'éléments total par l'utilisateur.
                    Console.Write("Nombre total d'éléments à gérer : ");
                    total = SaisirNombre();
                    if (choix != 1)
                    {
                        // Entrée du nombre d'éléments du sous ensemble par l'utilisateur.
                        Console.Write("Nombre d'éléments du sous ensemble : ");
                        nombre = SaisirNombre();
                    }
                }
                switch (choix)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        resultat = Permutation(total);
                        if (resultat <= 0)
                        {
                            Console.WriteLine("Erreur: opération impossible ou valeur hors champ");
                        }
                        else
                        {
                            Console.WriteLine(total + "! = " + resultat);
                        }
                        Console.WriteLine("");
                        break;
                    case 2:
                        resultat = Arrangement(total, nombre);
                        if (resultat <= 0)
                        {
                            Console.WriteLine("Erreur: opération impossible ou valeur hors champ");
                        }
                        else
                        {
                            Console.WriteLine("A(" + total + "/" + nombre + ") = " + resultat);
                        }
                        Console.WriteLine("");
                        break;
                    case 3:
                        resultat = Combinaison(total, nombre);
                        if (resultat <= 0)
                        {
                            Console.WriteLine("Erreur: opération impossible ou valeur hors champ");
                        }
                        else
                        {
                            Console.WriteLine("C(" + total + "/" + nombre + ") = " + resultat);
                        }
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("Erreur : veuillez entrer un nombre entier entre 0 et 3 !");
                        Console.WriteLine("");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}