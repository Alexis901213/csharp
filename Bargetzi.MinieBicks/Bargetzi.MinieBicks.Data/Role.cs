using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RomainJ.MinieBicks.Data
{
    class Role
    {
        public Role(string nom)
        {
            Nom = nom;
        }

        [Key]
        public Guid IdRole { get; set; } = new Guid();

        public string Nom { get; set; }


    }
}
