using System;
using System.Collections.Generic;
using System.Text;
using RomainJ.MinieBicks.Data;


namespace RomainJ.MinieBicks.lib
{
    public class ControlerPersonne
    {
        public static List<Personne> RechercheToutLesEmployes()
        {
            return Personne.SearchGroupPersonne();
        }

    }
}
