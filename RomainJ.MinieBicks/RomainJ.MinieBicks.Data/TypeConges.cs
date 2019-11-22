using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RomainJ.MinieBicks.Data
{
    public class TypeConges
    {
        public TypeConges(int joursConges, string libelle, bool validationObligatoire)
        {
            JoursConges = joursConges;
            Libelle = libelle;
            ValidationObligatoire = validationObligatoire;
        }

        public TypeConges(int idTypeConges, int joursConges, string libelle, bool validationObligatoire)
        {
            IdTypeConges = idTypeConges;
            JoursConges = joursConges;
            Libelle = libelle;
            ValidationObligatoire = validationObligatoire;
        }

        [Key]
        public int IdTypeConges { get; set; }

        public int JoursConges { get; set; }

        public string Libelle { get; set; }

        public bool ValidationObligatoire { get; set; }


    }
}
