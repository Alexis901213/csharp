using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RomainJ.MinieBicks.Data
{
    public class Adresse
    {
        

        [Key]
        public int IdAdresse { get; set; }

        public int Numero { get; set; }

        public string Rue { get; set; }

        public string Ville { get; set; }

        public int CodePostal { get; set; }

        public Adresse(int numero, string rue, string ville, int codePostal)
        {
            Numero = numero;
            Rue = rue;
            Ville = ville;
            CodePostal = codePostal;
        }

        public Adresse(int id,int numero, string rue, string ville, int codePostal)
        {
            IdAdresse = id;
            Numero = numero;
            Rue = rue;
            Ville = ville;
            CodePostal = codePostal;
        }

        public static void CreateAdresse(Adresse adresse)
        {
            using (var db = new MineBricksContext())
            {
                db.Add(adresse);
                db.SaveChanges();
            }
        }

        public static void UpdateAdresse(Adresse adresse)
        {
            using (var db = new MineBricksContext())
            {
                db.Update(adresse);
                db.SaveChanges();
            }
        }

        public static void DeleteAdresse(Adresse adresse)
        {
            using (var db = new MineBricksContext())
            {
                db.Remove(adresse);
                db.SaveChanges();
            }
        }
    }
}
