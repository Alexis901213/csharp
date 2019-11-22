using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RomainJ.MinieBicks.Data
{
    
    public class Personne
    {
        [Key]
        public int IdPersonne { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public Personne Superieur { get; set; }
                    
        public int NombreCongesAnnuelsCumules { get; set; }

        public int NombreRTTCumules { get; set; }

        [ForeignKey("Role")]
        public int ID_Role { get; set; }

        public virtual Role Role { get; set; }

        [ForeignKey("Adresse")]
        public int ID_Adresse { get; set; }

        public virtual Adresse Adresse { get; set; }

        public Personne(int id ,String nom, String prenom )
        {
            IdPersonne = id;
            Nom = nom;
            Prenom = prenom;
        }

        public Personne(int ID, string nom, string prenom, Role role, Personne superieur, Adresse adresse, int nombreCongesAnnuelsCumules, int nombreRTTCumules)
        {
            IdPersonne = ID;
            Nom = nom;
            Prenom = prenom;
            Role = role;
            Superieur = superieur;
            Adresse = adresse;
            NombreCongesAnnuelsCumules = nombreCongesAnnuelsCumules;
            NombreRTTCumules = nombreRTTCumules;
        }

        public Personne(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        override
        public string ToString()
        {
            
            return  this.Nom + this.Prenom ;
            
        }


        public static void InsertPersonne(Personne p)
        {
            using (var db = new MineBricksContext())
            {
                db.Add(p);
                db.SaveChanges();
            }
        }

        public static Personne SearchUniquePersonne(Guid id)
        {
            
            Personne res = null;

            using (var db = new MineBricksContext())
            {
                var personne = db.Personne.Find(id);

                res = (Personne)personne;
            }
            return (Personne)res;
            
        }

        public static List<Personne> SearchGroupPersonne()
        {
            using (var db = new MineBricksContext())
            {
                
                var personnes = db.Personne.Include(p => p.Role).Include(p => p.Adresse).OrderBy(b => b.IdPersonne).ToList();


                return personnes;
            }
        }


    }
}
