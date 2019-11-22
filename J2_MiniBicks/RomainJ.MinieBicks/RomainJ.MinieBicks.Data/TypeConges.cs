using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace RomainJ.MinieBicks.Data
{
    public class TypeConges
    {
        public TypeConges(int joursConges, string libelle, bool validationObligatoire, string pays)
        {
            JoursConges = joursConges;
            Libelle = libelle;
            ValidationObligatoire = validationObligatoire;
            Pays = pays.ToString();
        }

        public TypeConges(int idTypeConges, int joursConges, string libelle, bool validationObligatoire, string pays)
        {
            IdTypeConges = idTypeConges;
            JoursConges = joursConges;
            Libelle = libelle;
            ValidationObligatoire = validationObligatoire;
            Pays = pays.ToString();
        }

        public static List<TypeConges> SearchGroupTypeConges()
        {
            using (var db = new MineBricksContext())
            {
                var typeConge = db.TypeConges.ToList();
                return typeConge;
            }
        }

        public static void AddTypeConges(TypeConges typeConges)
        {
            using (var db = new MineBricksContext())
            {
                db.Add(typeConges);
                db.SaveChanges();
            }
        }

        public static void UpdateTypeConges(TypeConges typeConges)
        {
            using (var db = new MineBricksContext())
            {
                db.Update(typeConges);
                db.SaveChanges();
            }
        }

        public static void DeleteTypeConges(TypeConges typeConges)
        {
            using (var db = new MineBricksContext())
            {
                db.Remove(typeConges);
                db.SaveChanges();
            }
        }

        [Key]
        public int IdTypeConges { get; set; }

        public int JoursConges { get; set; }

        public string Libelle { get; set; }

        public string Pays { get; set; }

        public bool ValidationObligatoire { get; set; }


    }
}
