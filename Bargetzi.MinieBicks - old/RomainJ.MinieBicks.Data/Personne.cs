using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;

namespace RomainJ.MinieBicks.Data
{
    
    public class Personne
    {
        [Key]
        public Guid IdPersonne { get; set; } = new Guid();

        public string Nom { get; set; }

        public string Prenom { get; set; }

        private Role Role { get; set; }

        public Personne Superieur { get; set; }

        public Personne(String nom, String prenom )
        {
            Nom = nom;
            Prenom = prenom;
        }


        override
        public string ToString()
        {
            return "Id : " + this.IdPersonne + " Nom : " + this.Nom + " Prénom : " + this.Prenom;
        }

        public Personne SelectPersonne(Personne p)
        {
            Personne personne;
            using (var db = new MineBricksContext())
            {
                personne = db.Personne.Where(pe => pe == p).FirstOrDefault();
            }
            return personne;
        }

        public List<Personne> SelectPersonnes()
        {
            List<Personne> personne;
            using (var db = new MineBricksContext())
            {
                personne = db.Personne.ToList();
            }
            return personne;
        }

        public static void InsertPersonne(Personne p)
        {
            using (var db = new MineBricksContext())
            {
                db.Add(p);
                db.SaveChanges();
            }
        }

        public static void UpdatePersonne(Personne p)
        {
            using (var db = new MineBricksContext())
            {
                db.Update(p);
                db.SaveChanges();
            }
        }

        public static void DeletePersonne(Personne p)
        {
            using (var db = new MineBricksContext())
            {
                db.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
