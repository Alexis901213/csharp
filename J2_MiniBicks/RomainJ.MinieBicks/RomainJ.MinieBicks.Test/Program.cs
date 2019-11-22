using RomainJ.MinieBicks.Data;
using System;

namespace RomainJ.MinieBicks.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p = new Personne(1,"Machin", "truc");

           //Personne.InsertPersonne(p);

            

            Console.WriteLine(Personne.SearchGroupPersonne()[0].ToString());

            foreach(Personne pers in Personne.SearchGroupPersonne())
            {
                Console.WriteLine(pers.ToString());
            }

            Console.ReadLine();
        }
    }
}
