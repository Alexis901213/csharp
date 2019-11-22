using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RomainJ.MinieBicks.Data
{
    public class Role
    {
        public Role(string nom)
        {
            Nom = nom;
        }

        public Role(int id, string nom)
        {
            ID_Role = id;
            Nom = nom;
        }

        [Key]
        public int ID_Role { get; set; }

        public string Nom { get; set; }


    }
}
