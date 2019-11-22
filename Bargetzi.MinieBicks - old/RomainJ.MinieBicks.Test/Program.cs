using RomainJ.MinieBicks.Data;
using System;

namespace RomainJ.MinieBicks.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p = new Personne("t", "t");

            //Personne.InsertPersonne(p);

            Console.WriteLine(p.ToString());

            Console.WriteLine(p.SelectPersonne(p));

            Console.ReadLine();
        }
    }
}
